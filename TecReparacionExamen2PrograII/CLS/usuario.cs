using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TecReparacionExamen2PrograII.CLS
{
    public class usuario
    {
        public int usuarioID { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }

        //Constructores
        public usuario(string nombre, string correo, string telefono)
        {

            this.nombre = nombre;
            this.correo = correo;
            this.telefono = telefono;
        }

        public usuario()
        {
        }

        //Metodos
        public static int Agregar(string nombre, string correo, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarusuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
        public static int borrar(string codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("borrarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
        public static int modificar(int codigo, string nombre, string correo, string telefono) 
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}