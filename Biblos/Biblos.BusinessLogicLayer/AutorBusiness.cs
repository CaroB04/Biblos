using Biblos.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblos.BusinessLogicLayer
{
    public class AutorBusiness
    {
        BIBLOS contexto = new BIBLOS();

        public List<AUTOR> GetAutores()
        {
            var autores = contexto.AUTOR.ToList();
            return autores;
        }

        public AUTOR GetAutor(int id)
        {
            var autor = contexto.AUTOR.Where(a => a.ID == id).FirstOrDefault();
            return autor;
        }

        public void AddAutor(string nombre)
        {
            AUTOR tempo = new AUTOR();
            tempo.C_NAME = nombre;
            contexto.AUTOR.Add(tempo);
            contexto.SaveChanges();
        }

        public void EditAutor(int id, AUTOR autor)
        {
            var viejo = contexto.AUTOR.Where(a => a.ID == id).FirstOrDefault();
            viejo = autor;
            contexto.SaveChanges();
        }

        public void RemoveAutor(int id)
        {
            var autor = contexto.AUTOR.Where(a => a.ID == id).FirstOrDefault();
            contexto.AUTOR.Remove(autor);
            contexto.SaveChanges();
        }

    }
}
