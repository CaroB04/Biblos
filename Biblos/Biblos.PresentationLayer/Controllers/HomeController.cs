using Biblos.BusinessLogicLayer;
using Biblos.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Biblos.PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        BookBusiness books = new BookBusiness();
        UsersBusiness users = new UsersBusiness();

        public ActionResult Index()
        {
            var libros = books.GetBooks().ToList().Take(6);

            return View(libros);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InicioSesion(USERS usuario)
        {
            string username = string.Empty;
            bool existe = users.ExisteUsuario(usuario, out username);

            if (existe == true)
            {
                Session["UserName"] = username.ToString();
                FormsAuthentication.SetAuthCookie(usuario.EMAIL, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Email o contraseña incorrecta";
                return RedirectToAction("Login", "Home", TempData["error"]);
            }
        }
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(USERS usuario)
        {
            users.AddUser(usuario);
            Session["UserName"] = usuario.C_NAME.ToString();
            FormsAuthentication.SetAuthCookie(usuario.EMAIL, true);

            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}