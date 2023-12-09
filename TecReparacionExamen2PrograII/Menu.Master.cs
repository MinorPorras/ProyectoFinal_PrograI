using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TecReparacionExamen2PrograII.CLS;

namespace TecReparacionExamen2PrograII
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rol = "";
            if (ClsUsers.GetRol() == "1") 
            {
                rol = "Usuario";
            }
            if (ClsUsers.GetRol() == "2")
            {
                rol = "Tecnico";
            }
            if (ClsUsers.GetRol() == "3")
            {
                rol = "Admin";
            }
            LabelUsuario.Text = $"Usuario: {ClsUsers.GetNombre()}   Rol: {rol}";
        }
    }
}