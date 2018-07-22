using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationCTDEO.Context;
using WebApplicationCTDEO.Models;

namespace WebApplicationCTDEO.Controllers
{
    public class AlunosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Alunos
        public ActionResult Index()
        {
            var alunos = db.Alunos.Include(a => a.Mae).Include(a => a.Pai).Include(a => a.Reponsavel);
            return View(alunos.ToList());
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
        public ActionResult Create()
        {
            ViewBag.MaeCPF = new SelectList(db.Pais, "CPF", "Nome");
            ViewBag.PaiCPF = new SelectList(db.Pais, "CPF", "Nome");
            ViewBag.RespCPF = new SelectList(db.Pais, "CPF", "Nome");
            ViewBag.Turmas = new SelectList(db.Turmas, "TurmaId", "Nome");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoId,Nome,Genero,DatadeNascimento,Procedencia,CPF,RG,OrgaoExp,DatadeExp,Endereco,Numero,Complemento,Bairro,Municipio,Comunidade,CEP,TelefoneResidencial,Celular,MaeCPF,PaiCPF,EscolhaResponsavel,RespCPF,InstituicaodeEnsino,RededeEnsino,CRE,BolsadeEstudos,TipodeInstituicao,Serie,Turno,Transporte,RegistroFed,TipodeBolsaAtleta")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaeCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.MaeCPF);
            ViewBag.PaiCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.PaiCPF);
            ViewBag.RespCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.RespCPF);
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.MaeCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.MaeCPF);
            ViewBag.PaiCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.PaiCPF);
            ViewBag.RespCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.RespCPF);
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoId,Nome,Genero,DatadeNascimento,Procedencia,CPF,RG,OrgaoExp,DatadeExp,Endereco,Numero,Complemento,Bairro,Municipio,Comunidade,CEP,TelefoneResidencial,Celular,MaeCPF,PaiCPF,EscolhaResponsavel,RespCPF,InstituicaodeEnsino,RededeEnsino,CRE,BolsadeEstudos,TipodeInstituicao,Serie,Turno,Transporte,RegistroFed,TipodeBolsaAtleta")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaeCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.MaeCPF);
            ViewBag.PaiCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.PaiCPF);
            ViewBag.RespCPF = new SelectList(db.Pais, "CPF", "Nome", aluno.RespCPF);
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
