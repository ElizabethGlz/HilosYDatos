using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public class Producto
    {

        public int IdProducto { get; set; }
        public String NombreProducto { get; set; }
        public int IdProveedror { get; set; }
        public int IdCategoria { get; set; }
        public String CantidadXUnidad { get; set; }
        public float PrecioUnitario { get; set; }
        public int Existecia { get; set; }
        public int UnidadesEnPedido { get; set; }
        public int NivelDeReorden { get; set; }
        public byte Descontinuado { get; set; }
        public Producto() { }
        public Producto(int IdProducto, String NombreProducto, int IdProveedor)
        {
            this.IdProducto = IdProducto;
            this.NombreProducto = NombreProducto;
            this.IdProveedror = IdProveedor;
        }
        public Producto(int IdProducto, String NombreProducto, byte descontinuado)
        {
            this.IdProducto = IdProducto;
            this.NombreProducto = NombreProducto;
            this.Descontinuado = descontinuado;
        }
        public Producto(int IdProducto, String NombreProducto, int IdProveedor, int IdCategoria,

String CantidadXUnidad,
            float PrecioUnitario, int Existencia, int UnidadesEnPedido, int NivelDeReourde, byte

Descontinuado)
        {
            this.IdProducto = IdProducto;
            this.NombreProducto = NombreProducto;
            this.IdProveedror = IdProveedor;
            this.IdCategoria = IdCategoria;
            this.CantidadXUnidad = CantidadXUnidad;
            this.PrecioUnitario = PrecioUnitario;
            this.Existecia = Existencia;


        }
    }
}
