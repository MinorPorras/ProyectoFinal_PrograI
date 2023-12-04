using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TecReparacionExamen2PrograII.CLS
{
    public class reparaciones
    {
        public int reparacionesID { get; set; }
        public int equipoID { get; set; }
        public string fechaSolicitud { get; set; }
        public string estado { get; set; }

        //Constructores
        public reparaciones(int equipoID, string fechaSolicitud, string estado)
        {
            this.equipoID = equipoID;
            this.fechaSolicitud = fechaSolicitud;
            this.estado = estado;
        }

        public reparaciones()
        {
        }

        //Metodos
        public static int Agregar(int equipoID, string fechaSolicitud, string estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", fechaSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));


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
                    SqlCommand cmd = new SqlCommand("borrarReparacion", Conn)
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
        public static int Modificar(int reparacionesID, int equipoID, string fechaSolicitud, string estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarReparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", reparacionesID));
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOSID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", fechaSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));


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