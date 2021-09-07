using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contacto.ModelBD;

namespace Contacto.Controllers.Celular
{
    public class CelularController : Controller
    {
        private ContactosBDEntities db = new ContactosBDEntities();

        // GET: Celular
        public ActionResult Index()
        {
            var tb_Celular = db.tb_Celular.Include(t => t.tb_medioContacto);
            return View(tb_Celular.ToList());
        }

        // GET: Celular/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Celular tb_Celular = db.tb_Celular.Find(id);
            if (tb_Celular == null)
            {
                return HttpNotFound();
            }
            return View(tb_Celular);
        }

        // GET: Celular/Create
        public ActionResult Create()
        {
            ViewBag.idMedioContacto = new SelectList(db.tb_medioContacto, "idmedioContacto", "correo");
            return View();
        }

        // POST: Celular/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcelular,celular,principal,idMedioContacto")] tb_Celular tb_Celular)
        {
            if (ModelState.IsValid)
            {
                db.tb_Celular.Add(tb_Celular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMedioContacto = new SelectList(db.tb_medioContacto, "idmedioContacto", "correo", tb_Celular.idMedioContacto);
            return View(tb_Celular);
        }

        // GET: Celular/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Celular tb_Celular = db.tb_Celular.Find(id);
            if (tb_Celular == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedioContacto = new SelectList(db.tb_medioContacto, "idmedioContacto", "correo", tb_Celular.idMedioContacto);
            return View(tb_Celular);
        }

        // POST: Celular/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcelular,celular,principal,idMedioContacto")] tb_Celular tb_Celular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Celular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMedioContacto = new SelectList(db.tb_medioContacto, "idmedioContacto", "correo", tb_Celular.idMedioContacto);
            return View(tb_Celular);
        }

        // GET: Celular/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Celular tb_Celular = db.tb_Celular.Find(id);
            if (tb_Celular == null)
            {
                return HttpNotFound();
            }
            return View(tb_Celular);
        }

        // POST: Celular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Celular tb_Celular = db.tb_Celular.Find(id);
            db.tb_Celular.Remove(tb_Celular);
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
