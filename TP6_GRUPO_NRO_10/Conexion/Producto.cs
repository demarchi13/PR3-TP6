using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_GRUPO_NRO_10
{
    public class Producto
    {
        private int _IdProducto;
        private string _NombreProducto;
        private string _CantidadPorUnidad;
        private double _PrecioUnidad;

        public Producto() { }

        public Producto(int _IdProducto, string _NombreProducto, string _CantidadPorUnidad, float _PrecioUnidad)
        {
            this._IdProducto = _IdProducto;
            this._NombreProducto = _NombreProducto;
            this._CantidadPorUnidad = _CantidadPorUnidad;
            this._PrecioUnidad = _PrecioUnidad;
        }

        public int IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        public string NombreProducto
        {
            get { return _NombreProducto; }
            set { _NombreProducto = value; }
        }

        public string CantidadPorUnidad
        {
            get { return _CantidadPorUnidad; }
            set { _CantidadPorUnidad = value; }
        }

        public double PrecioUnidad
        {
            get { return _PrecioUnidad; }
            set { _PrecioUnidad = value; }
        }
            
    }
}