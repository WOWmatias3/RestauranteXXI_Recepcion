using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BoletaDAL
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

        public BoletaDAL()
        {
        }

        public BoletaDAL(int id_boleta, DateTime fecha_bol, string medio_pago, int subtotal, int descuentos, int total, int mesa_id, int garzon_id, int cliente_id)
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

        public bool InsertBoleta(int num_mesa,int id_garzon,int id_cliente)
        {
            try
            {

                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("Insert_boleta", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("id_mesa", OracleDbType.Int32).Value = num_mesa;
                com.Parameters.Add("id_garzon", OracleDbType.Int32).Value = id_garzon;
                com.Parameters.Add("id_cli", OracleDbType.Int32).Value = id_cliente;

                com.ExecuteNonQuery();

                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
