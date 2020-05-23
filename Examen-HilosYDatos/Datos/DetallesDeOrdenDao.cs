using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using MySql.Data.MySqlClient;
namespace Datos
{
   public class DetallesDeOrdenDao
    {
        public String agr = "";
        public int Agregar(DetallesDeOrden Detalle)
        {

            try

         {
        String sentencia =
                    "INSERT INTO `order details`(OrderID,ProductId,"
                    + "UnitPrice,Quantity,Discount)" +
                    "values(@p0,@p1,@p2,@p3,@p4);";
                MySqlCommand cmd = new MySqlCommand(sentencia);
                Conexion con = new Conexion();
                cmd.Parameters.AddWithValue("@p0", Detalle.OrdenID);
                cmd.Parameters.AddWithValue("@p1", Detalle.IDProducto);
                cmd.Parameters.AddWithValue("@p2", Detalle.PrecioUnitario);
                cmd.Parameters.AddWithValue("@p3", Detalle.Cantidad);
                cmd.Parameters.AddWithValue("@p4", Detalle.Descuento);
                con.ejecutarSentencia(cmd, true);
                agr = con.p;
                return 1;

            }
            catch (Exception ex)
            {
                agr = ex.ToString();

                return 0;
            }
            finally
            {
                //Solo intentar cerrar la conexión cuando si se encuentra abierta
                if (Conexion.conexion != null)
                {
                    Conexion.conexion.Close();
                }
            }
        }
        public List<DetallesDeOrden> MostrarTodo()
        {
            List<DetallesDeOrden> lista = new List<DetallesDeOrden>();

            try
            {
                String sentencia = "SELECT * `Order details`";
                Conexion con = new Conexion();
                DataTable dtProductos = con.ejecutarConsulta(sentencia);
                DetallesDeOrden detalle= null;
                foreach (DataRow fila in dtProductos.Rows)
                {

                    int a = -1;
                    int b = -1;
                    int c = -1;
                    int d = -1;
                    int e = -1;
                    int f = -1;
                    int.TryParse(fila["Quantity"].ToString(), out a);
                    int.TryParse(fila["CategoryID"].ToString(), out b);
                    int.TryParse(fila["UnitsInStock"].ToString(), out c);
                    int.TryParse(fila["UnitsOnOrder"].ToString(), out d);
                    int.TryParse(fila["ReorderLevel"].ToString(), out e);
                    detalle = new DetallesDeOrden
                        (
                        Int32.Parse(fila["OrderID"].ToString()), Int32.Parse(fila["ProductID"].ToString()),
                        Convert.ToSingle(fila["UnitPrice"]),a, Convert.ToSingle(fila["descount"])


                        );

                    lista.Add(detalle);

                }
                return lista;
            }
            catch (Exception ex)
            {
                return lista;
            }
            finally
            {
                //Solo intentar cerrar la conexión cuando si se encuentra abierta
                if (Conexion.conexion != null)
                {
                    Conexion.conexion.Close();
                }
            }

        }
    }
}
