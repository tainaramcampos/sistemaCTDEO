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
    public class TurmasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Turmas
        public ActionResult Index()
        {
            var turmas = db.Turmas.Include(t => t.Modalidade);
            return View(turmas.ToList());
        }

        // GET: Turmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }
        

        // GET: Turmas/Create
        public ActionResult Create()
        {
            Turma turma = new Turma();
            ViewData["Modalidades"] = db.Modalidade.ToList();
            return View(turma);
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TurmaId,Nome,ModalidadeId,Turno,Horario,ListadeDias")] Turma turma)
        {
            turma.Dias = string.Join(",", turma.ListadeDias.ToArray()); //adicionando lista de strings numa string única
            
            ViewData["Modalidades"] = db.Modalidade.ToList();
            if (ModelState.IsValid)
            {
               // turma.Dias.ToString();
                db.Turmas.Add(turma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModalidadeId = new SelectList(db.Modalidade, "ModalidadeId", "Nome", turma.ModalidadeId);
            return View(turma);
        }

        // GET: Turmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModalidadeId = new SelectList(db.Modalidade, "ModalidadeId", "Nome", turma.ModalidadeId);
            return View(turma);
        }

        // POST: Turmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TurmaId,Nome,ModalidadeId,Dias,Horario")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModalidadeId = new SelectList(db.Modalidade, "ModalidadeId", "Nome", turma.ModalidadeId);
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turma turma = db.Turmas.Find(id);
            db.Turmas.Remove(turma);
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
