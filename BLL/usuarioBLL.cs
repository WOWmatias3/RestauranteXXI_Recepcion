using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class usuarioBLL
    {
        int id_usuario { get; set; }
        string nom_usuario { get; set; }
        string clave { get; set; }
        string rol { get; set; }

        public usuarioBLL()
        {
        }
        public usuarioBLL(int id_usuario, string nom_usuario, string clave, string rol)
        {
            this.id_usuario = id_usuario;
            this.nom_usuario = nom_usuario;
            this.clave = clave;
            this.rol = rol;
        }

        public bool getLogin(string nombreuser, string password)
        {
            usuarioDAL usrdal = new usuarioDAL();
            return usrdal.getLogin(nombreuser, password);
        }

        public bool CreateCliente(int rut, string nombre, string apellido, string email)
        {
            usuarioDAL usrDAL = new usuarioDAL();
            return usrDAL.CreateUser(rut,nombre,apellido,email);
        }
        public DataTable getGarzones()
        {
            usuarioDAL usrDAL = new usuarioDAL();
            return usrDAL.getGarzones();
        }
    }
}
