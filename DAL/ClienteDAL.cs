using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL
    {
        int id_cliente { get; set; }
        string nombre { get; set; }
        string apellido { get; set; }
        string e_mail { get; set;}

        public ClienteDAL()
        {
        }
        public ClienteDAL(int id_cliente, string nombre, string apellido, string e_mail)
        {
            this.id_cliente = id_cliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.e_mail = e_mail;
        }

        public bool CheckCliente(int rut)
        {
            try
            {
                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("GetCliente", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("rut_cli", OracleDbType.Int32).Value = rut;
                OracleParameter output = com.Parameters.Add("my_cursor", OracleDbType.Int32);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                com.ExecuteNonQuery();

                con.Close();
                if (Int32.Parse( output.Value.ToString()) == 1) {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
