using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contacto.ModelBD;

namespace Contacto.Controllers.Contacto
{
    public class ContactoController : Controller
    {
        private ContactosBDEntities db = new ContactosBDEntities();

        // GET: Contacto
        public ActionResult Index()
        {
            var tb_contacto = db.tb_contacto.Include(t => t.tb_usuario).Include(t => t.tb_usuario1);
            return View(tb_contacto.ToList());
        }

        // GET: Contacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_contacto tb_contacto = db.tb_contacto.Find(id);
            if (tb_contacto == null)
            {
                return HttpNotFound();
            }
            return View(tb_contacto);
        }

        // GET: Contacto/Create
        public ActionResult Create()
        {
            ViewBag.cedulaTitular = new SelectList(db.tb_usuario, "cedula", "nombre");
            ViewBag.cedulaContacto = new SelectList(db.tb_usuario, "cedula", "nombre");
            return View();
        }

        // POST: Contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcontacto,cedulaTitular,cedulaContacto")] tb_contacto tb_contacto)
        {
            if (ModelState.IsValid)
            {
                db.tb_contacto.Add(tb_contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedulaTitular = new SelectList(db.tb_usuario, "cedula", "nombre", tb_contacto.cedulaTitular);
            ViewBag.cedulaContacto = new SelectList(db.tb_usuario, "cedula", "nombre", tb_contacto.cedulaContacto);
            return View(tb_contacto);
        }

        // GET: Contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_contacto tb_contacto = db.tb_contacto.Find(id);
            if (tb_contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedulaTitular = new SelectList(db.tb_usuario, "cedula", "nombre", tb_contacto.cedulaTitular);
            ViewBag.cedulaContacto = new SelectList(db.tb_usuario, "cedula", "nombre", tb_contacto.cedulaContacto);
            return View(tb_contacto);
        }

        // POST: Contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcontacto,cedulaTitular,cedulaContacto")] tb_contacto tb_contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedulaTitular = new SelectList(db.tb_usuario, "cedula", "nombre", tb_contacto.cedulaTitular);
            ViewBag.cedulaContacto = new SelectList(db.tb_usuario, "cedula", "nombre", tb_contacto.cedulaContacto);
            return View(tb_contacto);
        }

        // GET: Contacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_contacto tb_contacto = db.tb_contacto.Find(id);
            if (tb_contacto == null)
            {
                return HttpNotFound();
            }
            return View(tb_contacto);
        }

        // POST: Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_contacto tb_contacto = db.tb_contacto.Find(id);
            db.tb_contacto.Remove(tb_contacto);
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
