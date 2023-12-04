using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TecReparacionExamen2PrograII
{
    public partial class Reparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM reparaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagridRep.DataSource = dt;
                            datagridRep.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CLS.reparaciones.Agregar(int.Parse(TextBoxEquipoID.Text), TextBoxFecha.Text, DropDownListEstado.Text) > 0) 
            {
                LlenarGrid();
            }
            TextBoxID.Text = "";
            TextBoxEquipoID.Text = "";
            TextBoxFecha.Text = "";
            DropDownListEstado.SelectedIndex = 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CLS.reparaciones.Modificar(int.Parse(TextBoxID.Text), int.Parse(TextBoxEquipoID.Text), TextBoxFecha.Text, DropDownListEstado.Text) > 0) 
            {
                LlenarGrid();
            }
            TextBoxID.Text = "";
            TextBoxEquipoID.Text = "";
            TextBoxFecha.Text = "";
            DropDownListEstado.SelectedIndex = 0;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CLS.reparaciones.Borrar(int.Parse(TextBoxID.Text)) > 0) 
            {
                LlenarGrid();
            }
            TextBoxID.Text = "";
            TextBoxEquipoID.Text = "";
            TextBoxFecha.Text = "";
            DropDownListEstado.SelectedIndex = 0;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(TextBoxID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM reparaciones WHERE reparacionesID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagridRep.DataSource = dt;
                        datagridRep.DataBind();  // actualizar el grid view
                    }
                }
            }
            TextBoxID.Text = "";
            TextBoxEquipoID.Text = "";
            TextBoxFecha.Text = "";
            DropDownListEstado.SelectedIndex = 0;
        }
    }
}