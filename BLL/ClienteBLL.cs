using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {
        int id_cliente { get; set; }
        string nombre { get; set; }
        string apellido { get; set; }
        string e_mail { get; set; }

        public ClienteBLL()
        {
        }
        public ClienteBLL(int id_cliente, string nombre, string apellido, string e_mail)
        {
            this.id_cliente = id_cliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.e_mail = e_mail;
        }

        public bool getCliente(int rut)
        {
            ClienteDAL cliDAL = new ClienteDAL();
            return cliDAL.CheckCliente(rut);
        }

    }
}
