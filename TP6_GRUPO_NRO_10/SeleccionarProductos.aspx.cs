using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_NRO_10
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        //Declaramos el obj de la clase GestionProductos para llamar a los metodos
        GestionProductos objGP = new GestionProductos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Muestra la grilla al cargar el formulario por primera vez
                objGP.cargarGrillaProductos(grdSeleccionarProd);
            }
        }

        protected void grdSeleccionarProd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Configurar el evento para permitir la paginacion
            grdSeleccionarProd.PageIndex = e.NewPageIndex;
            objGP.cargarGrillaProductos(grdSeleccionarProd);
            
        }

        protected void grdSeleccionarProd_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Buscar los datos en el item template de la fila seleccionada y los guarda
            //dentro de las variables auxiliares

            //string aux_idProducto = ((Label)grdSeleccionarProd.Rows[e.NewSelectedIndex].FindControl("lbl_it_IdProducto")).Text;
            string aux_NombreProducto = ((Label)grdSeleccionarProd.Rows[e.NewSelectedIndex].FindControl("lbl_it_NombreProd")).Text;
            //string aux_CantidadPorUnidad = ((Label)grdSeleccionarProd.Rows[e.NewSelectedIndex].FindControl("lbl_it_CantPorUnidad")).Text;
            //string aux_PrecioUnidad = ((Label)grdSeleccionarProd.Rows[e.NewSelectedIndex].FindControl("lbl_it_PrecioUnidad")).Text;

            lblProdSeleccionado.Text = "Producto Seleccionado: " + aux_NombreProducto;
        }
    }
}