﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplicationCTDEO.Context;
using WebApplicationCTDEO.Models;

namespace WebApplicationCTDEO.Controllers
{
    public class AlunosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Alunos
        public ActionResult IndexAlunos()
        {
            return View(db.Alunos.ToList());
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        [HttpGet]
        public ActionResult Cadastrar()
        {
            ViewData["Turmas"] = db.Turmas.ToList();
            ViewData["Modalidades"] = db.Modalidade.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "AlunoId,Nome,Genero,DatadeNascimento,Procedencia,CPF,RG,OrgaoExp,DatadeExp,Endereco,Numero,Complemento,Bairro,Municipio,Comunidade,CEP,TelefoneResidencial,Celular,InstituicaodeEnsino,RededeEnsino,CRE,BolsadeEstudos,TipodeInstituicao,Serie,Turno,Transporte,RegistroFed,TipodeBolsaAtleta, IdsdeTurmas")] Aluno aluno,
            [Bind(Include = "AlunoId,PaisSeparados,NMoraComPais,JustificativaNMoraCPais,Sustento,TrabalhadoresNaFamilia,RendaMensal,TipodeBeneficio,Residencia,QtasCriancasEstudando,Fumantes,Alcoolismo,EnvolvidocomDrogas,ComoConheceu,OutroProjetoqParticipa")] AlunoSocial alunoSocial
           /* [Bind(Include = "CPF,Nome,Profissao,GraudeParentesco, IsResponsavel")] Familiar familiar*/)

        {
            //reenviar dados caso a página tenha que ser recarregada
            ViewData["Modalidades"] = db.Modalidade.ToList();
            ViewData["Turmas"] = db.Turmas.ToList();
            Turma turmaModel = new Turma();

            if (ModelState.IsValid)
            {

                using (var context = new DatabaseContext())
                {
                    if (aluno.IdsdeTurmas != null) //se tiver alguma turma na lista, salvar na tabela
                {
                    //lista para receber os códigos de turmas selecionadas
                    List<string> stringTurmas = new List<string>();
                    stringTurmas = aluno.IdsdeTurmas.Split(',').ToList(); //adiciona a string de ids de turmas numa lista
                    stringTurmas.Remove(""); //remove os itens em branco


                        foreach (var item in stringTurmas)
                        {
                            int id = Int32.Parse(item); //convertendo os ids de string pra int

                            //resagatando as turmas existentes
                            var turma = context.Turmas.Include("Alunos")
                            .Where(s => s.TurmaId == id).FirstOrDefault<Turma>();

                            //attach
                            if (context.Entry(turma).State == EntityState.Detached)
                                context.Turmas.Attach(turma);

                            //adicionando na lista de alunos
                            aluno.Turmas.Add(turma);
                        }
                    }
                    context.Alunos.Add(aluno);
                    context.AlunoSocial.Add(alunoSocial);
                    //salvar familiar
                    context.SaveChanges();
                    }

                return RedirectToAction("IndexAlunos");
            }
            
            return View(aluno);
        }


        public PartialViewResult CreateStudent()
        {
            return PartialView();
        }


        public PartialViewResult CreateFamiliar()
        {
            return PartialView();
        }


        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            return View();
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewData["Turmas"] = db.Turmas.ToList();
            ViewData["Modalidades"] = db.Modalidade.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoId,Nome,Genero,DatadeNascimento,Procedencia,CPF,RG,OrgaoExp,DatadeExp,Endereco,Numero,Complemento,Bairro,Municipio,Comunidade,CEP,TelefoneResidencial,Celular,InstituicaodeEnsino,RededeEnsino,CRE,BolsadeEstudos,TipodeInstituicao,Serie,Turno,Transporte,RegistroFed,TipodeBolsaAtleta,IdsdeTurmas")] Aluno aluno)
        {
            ViewData["Turmas"] = db.Turmas.ToList();
            ViewData["Modalidades"] = db.Modalidade.ToList();
            
            if (ModelState.IsValid)
            {

                using (var context = new DatabaseContext())
                {
                    if (aluno.IdsdeTurmas != null) //se tiver alguma turma na lista, salvar na tabela
                    {
                            //lista para receber os códigos de turmas selecionadas
                            List<string> stringTurmas = new List<string>();
                            stringTurmas = aluno.IdsdeTurmas.Split(',').ToList(); //adiciona a string de ids de turmas numa lista
                            stringTurmas.Remove(""); //remove os itens em branco


                            foreach (var item in stringTurmas)
                            {
                                int id = Int32.Parse(item); //convertendo os ids de string pra int

                                //resagatando as turmas existentes
                                var turma = context.Turmas.Include("Alunos")
                                .Where(s => s.TurmaId == id).FirstOrDefault<Turma>();

                                //attach
                                if (context.Entry(turma).State == EntityState.Detached)
                                    context.Turmas.Attach(turma);

                                //adicionando na lista de alunos
                                aluno.Turmas.Add(turma);
                            }
                    }
                    context.Alunos.Add(aluno);
                    //context.Alunos.Attach(aluno);
                    context.Entry(aluno).State = EntityState.Modified;
                    context.SaveChanges();
                }

            return RedirectToAction("IndexAlunos");
        }
            
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
