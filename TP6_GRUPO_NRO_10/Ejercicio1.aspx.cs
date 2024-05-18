﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TP6_GRUPO_NRO_10
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                       
                cargarGrillaProductos();
            }
        }

        public void cargarGrillaProductos()
        {
            GestionProductos objGP = new GestionProductos();
            grdProductos.DataSource = objGP.ObtenerTodosLosProductos();
            grdProductos.DataBind();
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Configura la paginacion del formulario
            grdProductos.PageIndex = e.NewPageIndex;
            cargarGrillaProductos();
        }

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {       
            //Configurar el boton eleiminar de la grilla
            try
            {
                //Obtener el id producto
                string idProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text;                     
                
                //guardar el id en un objeto
                Producto objProducto = new Producto();
                objProducto.IdProducto = Convert.ToInt32(idProducto);

                //Declara el objeto tipo GestionProductos y llama al metodo que recibe un obj tipo Producto
                GestionProductos objGestionProducto = new GestionProductos();
                lblIdProducto.Text = "Id producto seleccionado y eliminado: " + objProducto.IdProducto.ToString();
                objGestionProducto.EliminarProducto(objProducto);
                //Recarga la grilla para que se muestren los cambios
                cargarGrillaProductos();
            }
            catch (Exception ex)
            {
                lblEx.Text = ex.Message;             
            }
        }

        protected void grdProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Configura el boton editar de la grilla
            grdProductos.EditIndex = e.NewEditIndex;
            cargarGrillaProductos();
        }

        protected void grdProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Configura el boton cancelar del boton editar
            grdProductos.EditIndex = -1;
            cargarGrillaProductos();
        }

        protected void grdProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Configurar el boton actualizar del boton editar
            try
            {
                //Buscar y obtener los datos del edit item template
                string aux_idProducto = ((Label)grdProductos.Rows[e.RowIndex].FindControl("lbl_eit_idProducto")).Text;
                string aux_NombreProducto = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_eid_NombreProducto")).Text;
                string aux_CantidadPorUnidad = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_eit_CantidadPorUnidad")).Text;
                string aux_PrecioUnidad = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_eit_PrecioUnidad")).Text;

                //Copiar los datos al objeto
                Producto objProducto = new Producto();
                objProducto.IdProducto = Convert.ToInt32(aux_idProducto);
                objProducto.NombreProducto = aux_NombreProducto;
                objProducto.CantidadPorUnidad = aux_CantidadPorUnidad;
                objProducto.PrecioUnidad = Convert.ToDouble(aux_PrecioUnidad);

                //Declara obj gestion productos y llama al metodo
                GestionProductos objGestionProductos = new GestionProductos();
                if (objGestionProductos.ActualizarProducto(objProducto))
                {
                    lblIdProducto.Text = "Producto actualizado con exito";
                }
                else
                {
                    lblIdProducto.Text = "No se pudo actualizar el producto";
                }

                //Salir del modo edicion
                grdProductos.EditIndex = -1;

                //Actualiza la grilla
                cargarGrillaProductos();
            }
            catch (Exception ex)
            {
                lblEx.Text = ex.Message;
            }
        }
    }
}