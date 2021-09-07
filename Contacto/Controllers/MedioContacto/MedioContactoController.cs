using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contacto.ModelBD;

namespace Contacto.Controllers.MedioContacto
{
    public class MedioContactoController : Controller
    {
        private ContactosBDEntities db = new ContactosBDEntities();

        // GET: MedioContacto
        public ActionResult Index()
        {
            var tb_medioContacto = db.tb_medioContacto.Include(t => t.tb_usuario);
            return View(tb_medioContacto.ToList());
        }

        // GET: MedioContacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_medioContacto tb_medioContacto = db.tb_medioContacto.Find(id);
            if (tb_medioContacto == null)
            {
                return HttpNotFound();
            }
            return View(tb_medioContacto);
        }

        // GET: MedioContacto/Create
        public ActionResult Create()
        {
            ViewBag.cedulaUsuario = new SelectList(db.tb_usuario, "cedula", "nombre");
            return View();
        }

        // POST: MedioContacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmedioContacto,correo,facebook,instagram,cedulaUsuario")] tb_medioContacto tb_medioContacto)
        {
            if (ModelState.IsValid)
            {
                db.tb_medioContacto.Add(tb_medioContacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedulaUsuario = new SelectList(db.tb_usuario, "cedula", "nombre", tb_medioContacto.cedulaUsuario);
            return View(tb_medioContacto);
        }

        // GET: MedioContacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_medioContacto tb_medioContacto = db.tb_medioContacto.Find(id);
            if (tb_medioContacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedulaUsuario = new SelectList(db.tb_usuario, "cedula", "nombre", tb_medioContacto.cedulaUsuario);
            return View(tb_medioContacto);
        }

        // POST: MedioContacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmedioContacto,correo,facebook,instagram,cedulaUsuario")] tb_medioContacto tb_medioContacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_medioContacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedulaUsuario = new SelectList(db.tb_usuario, "cedula", "nombre", tb_medioContacto.cedulaUsuario);
            return View(tb_medioContacto);
        }

        // GET: MedioContacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_medioContacto tb_medioContacto = db.tb_medioContacto.Find(id);
            if (tb_medioContacto == null)
            {
                return HttpNotFound();
            }
            return View(tb_medioContacto);
        }

        // POST: MedioContacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_medioContacto tb_medioContacto = db.tb_medioContacto.Find(id);
            db.tb_medioContacto.Remove(tb_medioContacto);
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
