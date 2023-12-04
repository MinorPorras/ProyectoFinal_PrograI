using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TecReparacionExamen2PrograII.CLS
{
    public class equipos
    {
        public int equiposID { get; set; }
        public string tipodeEquipo { get; set; }
        public string modelo { get; set; }
        public int usuarioID { get; set; }

        //Constructores
        public equipos(string tipodeEquipo, string modelo, int usuarioID)
        {
            this.tipodeEquipo = tipodeEquipo;
            this.modelo = modelo;
            this.usuarioID = usuarioID;
        }

        public equipos()
        {
        }

        //Metodos
        public static int Agregar(string tipoDeEquipo, string modelo, string usuarioID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarequipos", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TIPODEEQUIPO", tipoDeEquipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", usuarioID));


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
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("borrarEquipos", Conn)
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
        public static int Modificar(int codigo, string tipoDeEquipo, string modelo, int usuarioID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarequipo", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@TIPODEEQUIPO", tipoDeEquipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", usuarioID));


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