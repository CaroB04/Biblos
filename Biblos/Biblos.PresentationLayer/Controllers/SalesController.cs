using Biblos.BusinessLogicLayer;
using Biblos.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblos.PresentationLayer.Controllers
{
    public class SalesController : Controller
    {
        SalesBusiness ventas = new SalesBusiness();
        BookBusiness libros = new BookBusiness();
        UsersBusiness usuarios = new UsersBusiness();

        // GET: Sales
        public ActionResult Index()
        {
            var model = ventas.GetSales();

            return View(model);
        }

        public ActionResult VentasDelDia()
        {
            var model = ventas.GetSalesOfTheDay();

            return View(model);
        }

        // GET: Sales/Create
        public ActionResult Comprar(int id)
        {
            if (Session["UserName"] != null || User.Identity.IsAuthenticated)
            {
                var venta = libros.GetBook(id);

                return View(venta);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Comprado(int idLibro)
        {
            SALES sales = new SALES();

            int idUsuario = usuarios.UsuarioActual(Session["UserName"].ToString());

            try
            {
                DateTime horaActual = DateTime.Now;

                sales.BOOK = idLibro;
                sales.CLIENT = idUsuario;
                sales.QUANTITY = 1;
                sales.DATE_SALE = horaActual;
                ventas.AddSale(sales);
                libros.BougthBook(idLibro, 1);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
