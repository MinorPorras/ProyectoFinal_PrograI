using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TecReparacionExamen2PrograII.CLS;

namespace TecReparacionExamen2PrograII
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            LoginWeb.SetNombre(TextBoxUser.Text);
            LoginWeb.SetClave(TextBoxContraseña.Text);
            LoginWeb.ObtenerusuarioID();
            LoginWeb.ObtenerRol();
            LoginWeb.SetNombreRol();
            if (LoginWeb.ValidarLogin() > 0) 
            {
                Response.Redirect("tecnicos.aspx");
            }
        }
    }
}