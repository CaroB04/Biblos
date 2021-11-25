using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblos.DataLayer;
using Biblos.EntityLayer;

namespace Biblos.PresentationLayer.Controllers
{
    public class AUTORsController : Controller
    {
        private BIBLOSEntities db = new BIBLOSEntities();

        // GET: AUTORs
        public ActionResult Index()
        {
            return View(db.AUTOR.ToList());
        }

        // GET: AUTORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTOR aUTOR = db.AUTOR.Find(id);
            if (aUTOR == null)
            {
                return HttpNotFound();
            }
            return View(aUTOR);
        }

        // GET: AUTORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AUTORs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,C_NAME")] AUTOR aUTOR)
        {
            if (ModelState.IsValid)
            {
                db.AUTOR.Add(aUTOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aUTOR);
        }

        // GET: AUTORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTOR aUTOR = db.AUTOR.Find(id);
            if (aUTOR == null)
            {
                return HttpNotFound();
            }
            return View(aUTOR);
        }

        // POST: AUTORs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,C_NAME")] AUTOR aUTOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUTOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aUTOR);
        }

        // GET: AUTORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTOR aUTOR = db.AUTOR.Find(id);
            if (aUTOR == null)
            {
                return HttpNotFound();
            }
            return View(aUTOR);
        }

        // POST: AUTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AUTOR aUTOR = db.AUTOR.Find(id);
            db.AUTOR.Remove(aUTOR);
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
