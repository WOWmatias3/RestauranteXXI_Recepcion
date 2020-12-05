using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaDAL
    {
        public int id_reserva { get; set; }
        public int fecha_reserva { get; set; }
        public int mesa_id_mesa { get; set; }
        public int cliente_id_cliente { get; set; }

        public ReservaDAL()
        {
        }

        public ReservaDAL(int id_reserva, int fecha_reserva, int mesa_id_mesa, int cliente_id_cliente)
        {
            this.id_reserva = id_reserva;
            this.fecha_reserva = fecha_reserva;
            this.mesa_id_mesa = mesa_id_mesa;
            this.cliente_id_cliente = cliente_id_cliente;
        }

        public DataTable GetReservasByRut (int rut_cliente)
        {
            try
            {
                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("GetReservasByRut", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("rut_cli", OracleDbType.Int32).Value = rut_cliente;
                OracleParameter output = com.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                com.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AgregarReserva(int rut,DateTime fechahora, int id_mesa)
        {
            try
            {

                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("Insert_reserva", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("id_cliente", OracleDbType.Int32).Value = rut;
                com.Parameters.Add("fecha", OracleDbType.Date).Value = fechahora;
                com.Parameters.Add("mesa_id", OracleDbType.Int32).Value = id_mesa;
                com.ExecuteNonQuery();

                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarReserva(int id_res)
        {
            try
            {

                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("Delete_reserva", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("id_reserv", OracleDbType.Int32).Value = id_res;

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
