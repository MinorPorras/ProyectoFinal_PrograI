using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace TecReparacionExamen2PrograII.CLS
{
    public class LoginWeb
    {
        private int ID;
        private static string Nombre;
        private static int Usuarioid;
        private static string Clave;
        private static int Rol;

        private static string NombreRol;

        public LoginWeb(int usuarioid, string clave, int rol)
        {
            Usuarioid = usuarioid;
            Clave = clave;
            Rol = rol;
        }

        public LoginWeb()
        {
        }

        //Getter y setter
        public static string GetNombre()
        {
            return Nombre;
        }
        public static void SetNombre(string nombre) 
        {
            Nombre = nombre;
        }
        public static int GetUsuarioid() 
        {
            return Usuarioid;
        }
        public static void SetUsuarioID(int usuarioID)
        {
            Usuarioid = usuarioID;
        }
        public static string GetClave() 
        {
            return Clave;
        }
        public static void SetClave(string clave)
        {
            Clave = clave;
        }
        public static int GetRol()
        {
            return Rol;
        }
        public static string GetNombreRol() 
        {
            return NombreRol;
        }
        public static string SetNombreRol() 
        {
            if (Rol == 1)
            {
                NombreRol = "Usuario";
            }
            else if (Rol == 2)
            {
                NombreRol = "Tecnico";
            }
            else NombreRol = "Administrador";

            return NombreRol;
        }




        //Metodos
        public static int ObtenerusuarioID()
        {
            int retorno = 0;

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
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())  // lea los datos usuario
                        {
                            retorno = 1;
                            Usuarioid = rdr.GetInt32(0);
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
            }

            return retorno;

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
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", Usuarioid));
                    cmd.Parameters.Add(new SqlParameter("@CLAVE", Clave));

                    retorno = cmd.ExecuteNonQuery();

                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
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

        public static int ObtenerRol()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("obtenerRol", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", Usuarioid));


                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())  // lea los datos usuario
                        {
                            retorno = 1;
                            Rol = rdr.GetInt32(0);
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
            }

            return retorno;

        }

    }
}