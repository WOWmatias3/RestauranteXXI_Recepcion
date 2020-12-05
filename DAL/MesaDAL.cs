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
    public class MesaDAL
    {
        int id_mesa { get; set; }
        string nombresala { get; set; }
        int capacidad { get; set; }
        string status { get; set; }

        public MesaDAL()
        {
        }

        public MesaDAL(int id_mesa, string nombresala, int capacidad, string status)
        {
            this.id_mesa = id_mesa;
            this.nombresala = nombresala;
            this.capacidad = capacidad;
            this.status = status;
        }

        public DataTable mesasvacias()
        {
            try
            {
                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("GetMesasDispo", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter output = com.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                com.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                con.Close();
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public DataTable GetMesas()
        {
            try
            {
                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("get_allmesas", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
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
    }
}
