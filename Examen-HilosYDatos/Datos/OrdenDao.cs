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
 public   class OrdenDao
    {
        public String agregado = ""; 
        public int Agregar(Orden orden)
        {

            try

            {
                String sentencia =
                            "    INSERT INTO Orders values();";
                MySqlCommand cmd = new MySqlCommand(sentencia);
                Conexion con = new Conexion();
              // cmd.Parameters.AddWithValue("@p0", "");
            
                con.ejecutarSentencia(cmd, true);
                agregado = "Se pudo"+con.p;
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
        public String most = "";
        public List<Orden> MostrarTodo()
        {
            List<Orden> lista = new List<Orden>();

            try
            {
                String sentencia = "SELECT *from Orders";
                Conexion con = new Conexion();
                DataTable dtProductos = con.ejecutarConsulta(sentencia);
                Orden orden = null;
                foreach (DataRow fila in dtProductos.Rows)
                {

                   
                    orden = new Orden
                        (
                        Int32.Parse(fila["OrderID"].ToString())


                        );

                    lista.Add(orden);

                }
                return lista;
            }
            catch (Exception ex)
            {
                most = ex.ToString();
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
