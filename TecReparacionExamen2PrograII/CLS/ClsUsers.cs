using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace TecReparacionExamen2PrograII.CLS
{
    public class ClsUsers
    {
        //Atributos
        private static int ID;
        private static string Nombre;
        private static string Clave;

      //Constructor
        public ClsUsers(string nombre, string clave)
        {
            Nombre = nombre;
            Clave = clave;
        }

        public ClsUsers()
        {
        }



        //  GET / SET
        public static string GetNombre() 
        {
            return Nombre;
        }
        public static void SetNombre(string nombre) 
        {
            Nombre = nombre;
        }
        public static string GetClave() 
        {
            return Clave;
        }

        public static void SetClave(string clave) 
        {
            Clave = clave;
        }

        public static int ValidarLogin()
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("validarUsers", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@CLAVE", Clave));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
                            Nombre = lectura[0].ToString();

                        }
                        else
                        {
                            retorno = -1;
                        }

                    }


                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }
    }
}