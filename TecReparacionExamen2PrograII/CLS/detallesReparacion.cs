using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TecReparacionExamen2PrograII.CLS
{
    public class detallesReparacion
    {
        public int detallereparacionID { get; set; }
        public int reparacionID { get; set; }
        public string descripcion { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }

        //Constructores
        public detallesReparacion(int reparacionID, string descripcion, string fechaInicio, string fechaFinal)
        {

            this.reparacionID = reparacionID;
            this.descripcion = descripcion;
            this.fechaInicio = fechaInicio;
            this.fechaFinal = fechaFinal;
        }

        public detallesReparacion()
        {
        }

        //Metodos
        public static int Agregar(int reparacionID, string descripcion, string fechaInicio, string fechaFinal)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarDetalle", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionID));
                    cmd.Parameters.Add(new SqlParameter("@DESC", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@fECHAINICIO", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFINAL", fechaFinal));


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
                    SqlCommand cmd = new SqlCommand("borrarDetalleRep", Conn)
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

        public static int Modificar(int detallereparacionID, int reparacionID, string descripcion, string fechaInicio, string fechaFinal)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarDetalleRep", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", detallereparacionID));
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionID));
                    cmd.Parameters.Add(new SqlParameter("@DESC", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFIN", fechaFinal));


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