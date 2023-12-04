using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TecReparacionExamen2PrograII.CLS
{
    public class asignaciones
    {
        public int asignacionesID { get; set; }
        public int reparacionesID { get; set; }
        public int tecnicoID { get; set; }
        public string fechaAsignacion { get; set; }

        //Constructores
        public asignaciones(int reparacionesID, int tecnicoID, string fechaAsignacion)
        {
            this.reparacionesID = reparacionesID;
            this.tecnicoID = tecnicoID;
            this.fechaAsignacion = fechaAsignacion;
        }

        public asignaciones()
        {
        }

        //Metodos
        public static int Agregar(int reparacionesID, int tecnicoID, string fechaAsignacion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionesID));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", tecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", fechaAsignacion));


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
                    SqlCommand cmd = new SqlCommand("borrarAsignacion", Conn)
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

        public static int Modificar(int asignacionesID, int reparacionesID, int tecnicoID, string fechaAsignacion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("modificarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", asignacionesID));
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionesID));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", tecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", fechaAsignacion));


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