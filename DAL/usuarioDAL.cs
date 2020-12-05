using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class usuarioDAL
    {
        int id_usuario { get; set;}
        string nom_usuario { get; set; }
        string clave { get; set; }
        string rol { get; set; }

        public usuarioDAL()
        {
        }
        public usuarioDAL(int id_usuario, string nom_usuario, string clave, string rol)
        {
            this.id_usuario = id_usuario;
            this.nom_usuario = nom_usuario;
            this.clave = clave;
            this.rol = rol;
        }

        private string encriptador(string palabra)
        {
            SHA256 sha = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha.ComputeHash(encoding.GetBytes(palabra));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public bool getLogin(string nomuser,string pass) {
            try
            {

                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("get_userpass", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("USERNAME", OracleDbType.Varchar2).Value = nomuser;
                OracleParameter output = com.Parameters.Add("my_cursor", OracleDbType.RefCursor);
                output.Direction = System.Data.ParameterDirection.ReturnValue;
                com.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();
                string shaword = encriptador(pass);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        nom_usuario = reader[1].ToString();
                        clave = reader[2].ToString();
                        rol = reader[3].ToString();
                        if (nom_usuario == nomuser && clave == shaword && rol == "Garzon")
                        {
                            con.Close();
                            return true;
                        }

                    }
                }
                con.Close();

                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public DataTable getGarzones()
        {
            try
            {
                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("GetGarzones", con);
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

        public bool CreateUser(int rut,string nombre, string apellido, string email)
        {
            try
            {

                OracleConnection con = new Conexion().conexion();
                con.Open();

                OracleCommand com = new OracleCommand("Insert_Cliente", con);
                com.BindByName = true;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add("id_cliente", OracleDbType.Varchar2).Value = rut;
                com.Parameters.Add("nombre", OracleDbType.Varchar2).Value = nombre;
                com.Parameters.Add("apellido", OracleDbType.Varchar2).Value = apellido;
                com.Parameters.Add("email", OracleDbType.Varchar2).Value = email;
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
