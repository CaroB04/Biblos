using Biblos.BusinessLogicLayer;
using Biblos.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblos.PresentationLayer.Controllers
{
    public class BookController : Controller
    {
        BIBLOS biblos = new BIBLOS();
        BookBusiness books = new BookBusiness();

        // GET: Book
        public ActionResult Index()
        {
            var libro = books.GetBooks();

            return View(libro);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var libro = books.GetBook(id);

            return View(libro);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.AUTOR = new SelectList(biblos.AUTOR, "ID", "C_NAME");

            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BOOK libro)
        {
            try
            {
                books.AddBook(libro);

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.IdAutor = new SelectList(biblos.AUTOR, "ID", "C_NAME");
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
