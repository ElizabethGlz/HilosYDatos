using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Modelo;
using Datos;
namespace Examen_HilosYDatos

{
  public  class Notificacion
    {
        public delegate void notificar(String notifi);
        public event notificar notificando;
        public void notific()
        {

            //for(int i = 0; i <= 20;i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Thread.Sleep(3000);
            //        notificando("numero " + i);
            //    }
            //}
            bool x = true;
            while (x)
            {
                List<Producto> p = new List<Producto>();
                ProductoDao obtnr = new ProductoDao();
                p = obtnr.MostrarTodo();
                for(int i = 0; i < p.Count; i++)
                {
                    if (p.ElementAt(i).Existecia == 0)
                    {
                        Thread.Sleep(3000);
                        notificando("Producto "+ p.ElementAt(i).NombreProducto+" Agotado");
                    }
                }
            
            }
        }
    }
}
