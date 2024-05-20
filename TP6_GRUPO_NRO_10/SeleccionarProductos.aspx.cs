using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
            string aux_idProducto = ((Label)grdSeleccionarProd.Rows[e.NewSelectedIndex].FindControl("lbl_it_IdProducto")).Text;
            string aux_NombreProducto = ((Label)grdSeleccionarProd.Rows[e.NewSelectedIndex].FindControl("lbl_it_NombreProd")).Text;
            string aux_CantidadPorUnidad = ((Label)grdSeleccionarProd.Rows[e.NewSelectedIndex].FindControl("lbl_it_CantPorUnidad")).Text;
            string aux_PrecioUnidad = ((Label)grdSeleccionarProd.Rows[e.NewSelectedIndex].FindControl("lbl_it_PrecioUnidad")).Text;
            
            lblProdSeleccionado.Text = "Productos agregados: " + aux_NombreProducto;

           //Crear la tabla invocando a la funcion crear tabla
            if (Session["Tabla"] == null)
            {
                Session["Tabla"] = CrearTabla();
            }
            
            //Asignamos uno cada vez que se selecciona
            int unidades = 1;
            //Recorro la tabla
            DataTable aux_tabla = (DataTable)Session["Tabla"];
            foreach (DataRow fila in aux_tabla.Rows)
            {
                // Obtener el valor del idProducto de la fila actual
                int idProducto = Convert.ToInt32(fila["IDProducto"]);
                //Comparamos idProducto ingresado con idProducto de las filas
                if (idProducto == (Convert.ToInt32(aux_idProducto)))
                {
                    //Lo sumamos cada vez que lo encuentre y reemplazamos el valor
                    unidades+=Convert.ToInt32(fila["Unidades"]);
                    fila["Unidades"] = Convert.ToString(unidades);             
                }         
            }
            
            //Rellena las filas 
            if (unidades<2)
            {
                AgregarFila((DataTable)Session["Tabla"], aux_idProducto, aux_NombreProducto, aux_CantidadPorUnidad, aux_PrecioUnidad, unidades);
                
            }
            else
            {
                Session["Tabla"] = aux_tabla;
            }
        }

        public DataTable CrearTabla()
        {
            DataTable tabla = new DataTable();

            DataColumn columna = new DataColumn("IDProducto", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("NombreProducto", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("CantidadPorUnidad", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("PrecioUnidad", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("Unidades", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            return tabla;
        }

        public void AgregarFila(DataTable tabla, string IdProducto, string NombreProducto, string CantidadPorUnidad, string PrecioUnidad,int unidades)
        {
            DataRow fila = tabla.NewRow();
            fila["IdProducto"] = IdProducto;
            fila["NombreProducto"] = NombreProducto;
            fila["CantidadPorUnidad"] = CantidadPorUnidad;
            fila["PrecioUnidad"] = PrecioUnidad;
            fila["Unidades"] = Convert.ToString(unidades);

            tabla.Rows.Add(fila);
        }
    }
}