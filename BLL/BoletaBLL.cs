using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BoletaBLL
    {

        int id_boleta { get; set; }
        DateTime fecha_bol { get; set; }
        string medio_pago { get; set; }
        int subtotal { get; set; }
        int descuentos { get; set; }
        int total { get; set; }
        int mesa_id { get; set; }
        int garzon_id { get; set; }
        int cliente_id { get; set; }

        public BoletaBLL()
        {
        }

        public BoletaBLL(int id_boleta, DateTime fecha_bol, string medio_pago, int subtotal, int descuentos, int total, int mesa_id, int garzon_id, int cliente_id)
        {
            this.id_boleta = id_boleta;
            this.fecha_bol = fecha_bol;
            this.medio_pago = medio_pago;
            this.subtotal = subtotal;
            this.descuentos = descuentos;
            this.total = total;
            this.mesa_id = mesa_id;
            this.garzon_id = garzon_id;
            this.cliente_id = cliente_id;
        }

        public bool insertBoleta(int idmesa,int idgarzon,int idcliente)
        {
            BoletaDAL bolDAL = new BoletaDAL();
            return bolDAL.InsertBoleta(idmesa,idgarzon,idcliente); 
            
        }


    }
}
