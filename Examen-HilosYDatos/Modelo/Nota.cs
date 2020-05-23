using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Nota
    {
        public int Clave { get; set; }
        public String Nombre { get; set; }
        public float Precio{ get; set; }
        public int Cantidad { get; set; }
        public float Importe { get; set; }
     
        public Nota(int clave, String nombre, int cantidad, float precio)
        {
            Clave = clave;
            Precio = precio;
            Nombre = nombre;
            Cantidad = cantidad;
            calcularImporte();

        }
        public Nota(int clave, int cantidad, float precio)
        {
            Clave = clave;
            Precio = precio;
           
            Cantidad = cantidad;
            calcularImporte();

        }
        public void calcularImporte()
        {
            Importe = Precio * Cantidad;
        }
    }
}
