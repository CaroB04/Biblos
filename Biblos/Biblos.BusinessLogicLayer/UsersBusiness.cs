using Biblos.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblos.BusinessLogicLayer
{
    public class UsersBusiness
    {
        BIBLOS biblos = new BIBLOS();

        public USERS GetUser(int id)
        {
            var user = biblos.USERS.Where(u => u.ID == id).FirstOrDefault();
            return user;
        }

        public List<USERS> GetUsers()
        {
            var users = biblos.USERS.ToList();
            return users;
        }

        public void AddUser(USERS usuario)
        {
            usuario.C_ROLE = "Usuario";

            biblos.USERS.Add(usuario);
            biblos.SaveChanges();
        }

        public void MakeAdmin(int id)
        {
            USERS tempo = biblos.USERS.Where(u => u.ID == id).FirstOrDefault();
            tempo.C_ROLE = "Admin";
            biblos.SaveChanges();
        }

        public bool ExisteUsuario(USERS usuario, out string nombre)
        {
            nombre = string.Empty;
            var existe = biblos.USERS.Where(y => y.EMAIL.Equals(usuario.EMAIL) && y.C_PASSWORD.Equals(usuario.C_PASSWORD)).FirstOrDefault();


            if (existe != null)
            {
                nombre = existe.C_NAME;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int UsuarioActual(string nombre)
        {
            var tempuser = biblos.USERS.Where(u => u.C_NAME == nombre).FirstOrDefault();

            return tempuser.ID;
        }
    }
}
