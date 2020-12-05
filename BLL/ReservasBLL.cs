using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ReservasBLL
    {

        public int id_reserva { get; set; }
        public int fecha_reserva { get; set; }
        public int mesa_id_mesa { get; set; }
        public int cliente_id_cliente { get; set; }

        public ReservasBLL()
        {
        }

        public ReservasBLL(int id_reserva, int fecha_reserva, int mesa_id_mesa, int cliente_id_cliente)
        {
            this.id_reserva = id_reserva;
            this.fecha_reserva = fecha_reserva;
            this.mesa_id_mesa = mesa_id_mesa;
            this.cliente_id_cliente = cliente_id_cliente;
        }

        public DataTable GetReservasByRut(int rut)
        {
            ReservaDAL resDAL = new ReservaDAL();
            return resDAL.GetReservasByRut(rut);

        }

        public bool InsertReserva(int rut, DateTime fecha, int mesa)
        {
            ReservaDAL resDAL = new ReservaDAL();
            return resDAL.AgregarReserva(rut, fecha, mesa);
        }
        public bool DeleteReserva(int id_reserv)
        {
            ReservaDAL resDAL = new ReservaDAL();
            return resDAL.EliminarReserva(id_reserv);
        }
    }
}
