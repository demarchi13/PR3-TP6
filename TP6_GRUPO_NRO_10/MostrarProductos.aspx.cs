using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP6_GRUPO_NRO_10
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Tabla"] != null)
            {

                grdMostrarProductos.DataSource = (DataTable)Session["Tabla"];
                grdMostrarProductos.DataBind();
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Text = "No se selecciono nada de la tabla";
            }
        }
    }
}