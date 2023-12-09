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
        private static string usuarioID;
        private static string Nombre;
        private static string Clave;
        private static string Rol;

      //Constructor
        public ClsUsers(string usuarioid, string clave, string nombre, string rol)
        {
            usuarioID = usuarioid;
            Clave = clave;
            Nombre = nombre;
            Rol = rol;
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
        public static string GetusuarioID() 
        {
            return usuarioID;
        }
        public static void SetusuarioID(string usuarioid) 
        {
            usuarioID = usuarioid;
        }
        public static string GetClave() 
        {
            return Clave;
        }
        public static void SetClave(string clave) 
        {
            Clave = clave;
        }
        public static string GetRol()
        {
            return Rol;
        }
        public static void SetRol(string rol)
        {
            Rol = rol;
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
                    SqlCommand cmd = new SqlCommand("validarLogin", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", usuarioID));
                    cmd.Parameters.Add(new SqlParameter("@CLAVE", Clave));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
                            usuarioID = lectura[0].ToString();

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

        public static int obtenerIDusuario() 
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("obtenerusuarioID", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", Nombre));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
                            usuarioID = lectura[0].ToString();

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

        public static int obtenerRol()
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("obtenerRol", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", usuarioID));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
                            Rol = lectura[0].ToString();

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