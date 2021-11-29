using Biblos.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblos.BusinessLogicLayer
{
    public class SalesBusiness
    {
        BIBLOS biblos = new BIBLOS();

        public void AddSale(SALES ventas)
        {
            //SALES ventas = new SALES();
            //ventas.BOOK = idlibro;
            //ventas.QUANTITY = cantidad;
            //ventas.CLIENT = idcliente;
            //ventas.DATE_SALE = DateTime.Now;

            biblos.SALES.Add(ventas);
            biblos.SaveChanges();
        }

        public List<SALES> GetSalesOfTheDay()
        {
            var finDelDia = DateTime.Today.AddHours(23).AddMinutes(59);
            var ventasDelDia = biblos.SALES.Where(s => s.DATE_SALE >= DateTime.Today && s.DATE_SALE <= finDelDia).ToList();
            return ventasDelDia;
        }

        public List<SALES> GetSales()
        {
            var ventas = biblos.SALES.ToList();
            return ventas;
        }

        public SALES GetSale(int id)
        {
            var venta = biblos.SALES.Where(s => s.ID == 9).FirstOrDefault();
            return venta;
        }
    }
}
