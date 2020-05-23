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
    public class ProductoDao
    {
        public List<Producto> MostrarTodo()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                String sentencia = "SELECT * FROM Products";
                Conexion con = new Conexion();
                DataTable dtProductos = con.ejecutarConsulta(sentencia);
                Producto objproducto = null;
                foreach (DataRow fila in dtProductos.Rows)
                {

                    int a = -1;
                    int b = -1;
                    int c = -1;
                    int d = -1;
                    int e = -1;
                    int f = -1;
                    int.TryParse(fila["SupplierID"].ToString(), out a);
                    int.TryParse(fila["CategoryID"].ToString(), out b);
                    int.TryParse(fila["UnitsInStock"].ToString(), out c);
                    int.TryParse(fila["UnitsOnOrder"].ToString(), out d);
                    int.TryParse(fila["ReorderLevel"].ToString(), out e);
                    objproducto = new Producto
                        (
                        Int32.Parse(fila["ProductID"].ToString()),
                        fila["ProductName"].ToString(),
                        a, b,
                        fila["QuantityPerUnit"].ToString(),
                        Convert.ToSingle(fila["UnitPrice"]), c, d, e,

                          byte.Parse(fila["Discontinued"].ToString())

                        );

                    lista.Add(objproducto);

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
        public Producto MostrarUno(int IdProducto)
        {
            Producto objProducto = null;

            try
            {
                String sentencia = "SELECT * FROM products WHERE productid = @p0";
                MySqlCommand cmd = new MySqlCommand(sentencia);
                cmd.Parameters.AddWithValue("@p0", IdProducto);
                Conexion con = new Conexion();
                DataTable dtProductos = con.ejecutarConsulta(cmd);

                //Verificar si la consulta regresó resultados
                // para llenar el objeto
                if (dtProductos != null && dtProductos.Rows.Count > 0)
                {
                    //Se obtiene la fila de la categoria buscada
                    DataRow fila = dtProductos.Rows[0];

                    objProducto = new Producto(
                       int.Parse(fila["ProductID"].ToString()),
                        fila["ProductName"].ToString(),
                        int.Parse(fila["SupplierID"].ToString()),
                        int.Parse(fila["CategoryID"].ToString()),
                        fila["QuantityPerUnit"].ToString(),
                        float.Parse(fila["UnitPrice"].ToString()),
                         int.Parse(fila["UnitsInStock"].ToString()),
                          int.Parse(fila["UnitsOnOrder"].ToString()),
                           int.Parse(fila["ReorderLevel"].ToString()),
                           byte.Parse(fila["Discontinued"].ToString())
                    );
                }
                return objProducto;
            }
            catch (Exception ex)
            {
                return objProducto;
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


        public String agregado = "";
        public int Agregar(Producto producto)
        {

            try

            {

                String sentencia =
                    "INSERT INTO products(ProductID,ProductName,"
                    + "SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued)" +
                    "values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9); SELECT DISTINCT LAST_INSERT_ID() FROM products;";
                MySqlCommand cmd = new MySqlCommand(sentencia);
                Conexion con = new Conexion();
                cmd.Parameters.AddWithValue("@p0", producto.IdProducto);
                cmd.Parameters.AddWithValue("@p1", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@p2", producto.IdProveedror);
                cmd.Parameters.AddWithValue("@p3", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@p4", producto.CantidadXUnidad);
                cmd.Parameters.AddWithValue("@p5", producto.PrecioUnitario);
                cmd.Parameters.AddWithValue("@p6", producto.Existecia);
                cmd.Parameters.AddWithValue("@p7", producto.UnidadesEnPedido);
                cmd.Parameters.AddWithValue("@p8", producto.NivelDeReorden);
                cmd.Parameters.AddWithValue("@p9", producto.Descontinuado);
                con.ejecutarSentencia(cmd, true);
                agregado = con.p + "Agregado";
                return 1;

            }
            catch (Exception ex)
            {
                agregado = ex.ToString();

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

        public bool Eliminar(int IdProducto)
        {

            try
            {
                String sentencia = "DELETE FROM Products WHERE ProductID = @p0";
                Conexion con = new Conexion();
                MySqlCommand cmd = new MySqlCommand(sentencia);
                cmd.Parameters.AddWithValue("@p0", IdProducto);
                //Conexion con = new Conexion();
                //DataTable dtProductos = con.ejecutarConsulta(cmd);
                //return bool.Parse(con.ejecutarSentencia(sentencia, false).ToString());


                con.ejecutarSentencia(cmd, false);

                return true;

            }
            catch (Exception ex)
            {

                return false;

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
        public bool Editar(Producto producto)
        {
            try
            {
                String sentencia =
                    "UPDATE Products SET ProductName = @p1, SupplierID=@p2, CategoryID=@p3," +
                   "QuantityPerUnit= @p4, UnitPrice=@p5, UnitsInStock= @p6, UnitsOnOrder= @p7, ReorderLevel=@p8,Discontinued=@p9 WHERE ProductID =@p0";


                Conexion con = new Conexion();
                MySqlCommand cmd = new MySqlCommand(sentencia);
                //cmd.Parameters.AddWithValue("@p0", IdProducto);
                cmd.Parameters.AddWithValue("@p0", producto.IdProducto);
                cmd.Parameters.AddWithValue("@p1", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@p2", producto.IdProveedror);
                cmd.Parameters.AddWithValue("@p3", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@p4", producto.CantidadXUnidad);
                cmd.Parameters.AddWithValue("@p5", producto.PrecioUnitario);
                cmd.Parameters.AddWithValue("@p6", producto.Existecia);
                cmd.Parameters.AddWithValue("@p7", producto.UnidadesEnPedido);
                cmd.Parameters.AddWithValue("@p8", producto.NivelDeReorden);
                cmd.Parameters.AddWithValue("@p9", producto.Descontinuado);
                ////DataTable dtProductos = con.ejecutarConsulta(cmd);
                ////return bool.Parse(con.ejecutarSentencia(sentencia, false).ToString());
                con.ejecutarSentencia(cmd, false);
                ed = "Editado";
                ed = con.p;
                return true;

            }
            catch (Exception ex)
            {

                ed = ex.ToString();
                return false;
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
        public String ed = "";
        public List<Producto> MostrarPorNombre(String texto)
        {
            List<Producto> lista = new List<Producto>();
          
            texto = texto + "%";
            String busqueda = "%" + texto;
            try
            {
                String sentencia = "SELECT * FROM products WHERE productName like  @p0";
                MySqlCommand cmd = new MySqlCommand(sentencia);
                cmd.Parameters.AddWithValue("@p0", busqueda);
                Conexion con = new Conexion();
                DataTable dtProductos = con.ejecutarConsulta(cmd);
                Producto objproducto = null;
                foreach (DataRow fila in dtProductos.Rows)
                {

                    int a = -1;
                    int b = -1;
                    int c = -1;
                    int d = -1;
                    int e = -1;
                    int f = -1;
                    int.TryParse(fila["SupplierID"].ToString(), out a);
                    int.TryParse(fila["CategoryID"].ToString(), out b);
                    int.TryParse(fila["UnitsInStock"].ToString(), out c);
                    int.TryParse(fila["UnitsOnOrder"].ToString(), out d);
                    int.TryParse(fila["ReorderLevel"].ToString(), out e);
                    objproducto = new Producto
                        (
                        Int32.Parse(fila["ProductID"].ToString()),
                        fila["ProductName"].ToString(),
                        a, b,
                        fila["QuantityPerUnit"].ToString(),
                        Convert.ToSingle(fila["UnitPrice"]), c, d, e,

                          byte.Parse(fila["Discontinued"].ToString())

                        );

                    lista.Add(objproducto);

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
        public Producto MostrarID(String nombre)
        {
            Producto objProducto = null;

            try
            {
                String sentencia = "SELECT * FROM products WHERE productName like @p0";
                MySqlCommand cmd = new MySqlCommand(sentencia);
                cmd.Parameters.AddWithValue("@p0", nombre);
                Conexion con = new Conexion();
                DataTable dtProductos = con.ejecutarConsulta(cmd);

                //Verificar si la consulta regresó resultados
                // para llenar el objeto
                if (dtProductos != null && dtProductos.Rows.Count > 0)
                {
                    //Se obtiene la fila de la categoria buscada
                    DataRow fila = dtProductos.Rows[0];

                    objProducto = new Producto(
                       int.Parse(fila["ProductID"].ToString()),
                        fila["ProductName"].ToString(),
                        int.Parse(fila["SupplierID"].ToString()),
                        int.Parse(fila["CategoryID"].ToString()),
                        fila["QuantityPerUnit"].ToString(),
                        float.Parse(fila["UnitPrice"].ToString()),
                         int.Parse(fila["UnitsInStock"].ToString()),
                          int.Parse(fila["UnitsOnOrder"].ToString()),
                           int.Parse(fila["ReorderLevel"].ToString()),
                           byte.Parse(fila["Discontinued"].ToString())
                    );
                }
                return objProducto;
            }
            catch (Exception ex)
            {
                return objProducto;
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
