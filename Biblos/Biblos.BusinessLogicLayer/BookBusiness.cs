using Biblos.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblos.BusinessLogicLayer
{
    public class BookBusiness
    {
        BIBLOS biblos = new BIBLOS();

        public List<BOOK> GetBooks()
        {
            var libros = biblos.BOOK.Where(c => c.STOCK > 0).OrderByDescending(b => b.ID).ToList();
            return libros;
        }

        public BOOK GetBook(int id)
        {
            var libro = biblos.BOOK.Where(c => c.ID == id).FirstOrDefault();
            return libro;
        }

        public void BougthBook(int id, int quantity)
        {
            var libro = biblos.BOOK.Where(c => c.ID == id).FirstOrDefault();
            libro.STOCK -= quantity;
            biblos.SaveChanges();
        }

        public void AddBook(BOOK libro)
        {
            //var libro = new BOOK();
            //libro.ISBN = isbn;
            //libro.TITLE = titulo;
            //libro.DATE_PUBLICATION = DateTime.Parse(fecha);
            //libro.EDITORIAL = editorial;
            //libro.AUTOR = autor;
            //libro.STOCK = stock;

            biblos.BOOK.Add(libro);
            biblos.SaveChanges();
        }
    }
}
