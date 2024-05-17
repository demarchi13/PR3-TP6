using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_NRO_10
{
    public class GestionProductos
    {
        public GestionProductos() { }

        private DataTable ObtenerTabla(String NombreTabla, String consultaSQL)
        {
            DataSet data_set = new DataSet();

            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta(consultaSQL);
            datos.ejecutarLectura();

            DataTable tabla = new DataTable(NombreTabla);
            tabla.Load(datos.Lector);

            data_set.Tables.Add(tabla);

            datos.cerrarConexion();

            return tabla;
        }

        public DataTable ObtenerTodosLosProductos()
        {
            return ObtenerTabla("Productos", "select IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad from Productos");
        }

        public bool ActualizarProducto(Producto objProducto)
        {
            int auxId = objProducto.IdProducto;
            string auxNombreProducto = objProducto.NombreProducto;
            string auxCantidadPorUnidad = objProducto.CantidadPorUnidad;
            double auxPrecioUnidad = objProducto.PrecioUnidad;

            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("update Productos set NombreProducto = @NombreProducto, PrecioUnidad = @PrecioUnidad, CantidadPorUnidad = @CantidadPorUnidad where IdProducto = @IdProducto");
           
            datos.setearParametro("@IdProducto", auxId);
            datos.setearParametro("@NombreProducto", auxNombreProducto);
            datos.setearParametro("@CantidadPorUnidad", auxCantidadPorUnidad);
            datos.setearParametro("@PrecioUnidad", auxPrecioUnidad);

            bool filasAfectadas = datos.ejecutarAccion();

            datos.cerrarConexion();

            return filasAfectadas;
        }
        
        public bool EliminarProducto(Producto objProducto)
        {
            int auxIdProducto = objProducto.IdProducto;

            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("delete from Productos where IdProducto ="+auxIdProducto);           
       
            bool filasAfectadas = datos.ejecutarAccion();
            datos.cerrarConexion();

            return filasAfectadas;
        }
    }


}