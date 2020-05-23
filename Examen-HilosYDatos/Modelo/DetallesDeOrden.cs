using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public class DetallesDeOrden
    {
        public int OrdenID { get; set; }
        public int IDProducto { get; set; }
        public float PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public  float Descuento { get; set; }
        public DetallesDeOrden(int ordenId,int  idPRoducto, float precioUnit, int canti, float desc)
        {
            OrdenID = ordenId;
            IDProducto = idPRoducto;
            PrecioUnitario = precioUnit;
            Cantidad = canti;
            Descuento = desc;
        }
    }
}
