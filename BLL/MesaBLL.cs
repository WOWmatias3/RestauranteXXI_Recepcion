using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class MesaBLL
    {
        int id_mesa { get; set; }
        string nombresala { get; set; }
        int capacidad { get; set; }
        string status { get; set; }

        public MesaBLL()
        {
        }

        public MesaBLL(int id_mesa, string nombresala, int capacidad, string status)
        {
            this.id_mesa = id_mesa;
            this.nombresala = nombresala;
            this.capacidad = capacidad;
            this.status = status;
        }

        public DataTable getmesasvacias()
        {
            MesaDAL mesa = new MesaDAL();
            DataTable ord = mesa.mesasvacias();
            return ord;
        }
        public DataTable GetlAllMesas()
        {
            MesaDAL mesaDAL = new MesaDAL();
            return mesaDAL.GetMesas();
        }

    }
}
