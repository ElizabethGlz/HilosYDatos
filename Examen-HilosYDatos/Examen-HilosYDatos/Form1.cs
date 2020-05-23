using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Datos;
using System.Threading;
using WindowsFormsApplication1;
namespace Examen_HilosYDatos
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();

            cboBusqueda.MaxDropDownItems = 5;
     
        }


        List<Producto> li = new List<Producto>();
        //LOAD LOAD     LOAD    LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            ProductoDao p = new ProductoDao();
            li = p.MostrarTodo();
            cmbProductos.DataSource = li;
            cmbProductos.DisplayMember = "IdProducto";
          CheckForIllegalCrossThreadCalls = false;
            iniciar = new ThreadStart(CreandoNot);
            hilo= new Thread(iniciar
                );
            hilo.Start();
            this.Text = "Venta de productos";
            
        }

        private void rbnClave_Click(object sender, EventArgs e)
        {

        }

        private void rbnNombre_Click(object sender, EventArgs e)
        {


        }

        private void rbnNombre_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void rbnNombre_MouseCaptureChanged(object sender, EventArgs e)
        {

        }
        List<Nota> nota = new List<Nota>();
        List<Nota> nota2 = new List<Nota>();
        float total = 0;
      //  List<Orden> ordenes = new List<Orden>();
        int cont = 0;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int i = cmbProductos.SelectedIndex;
            Producto n = li.ElementAt(i);

            Nota x = new Nota(n.IdProducto, n.NombreProducto, (int)(numCantidad.Value), n.PrecioUnitario);
            Nota y = new Nota(n.IdProducto, (int)(numCantidad.Value), n.PrecioUnitario);
            n.Existecia = n.Existecia - y.Cantidad;
            nota2.Add(y);
            total += x.Importe;
            lblTotal.Text = total + "";
            nota.Add(x);
            numCantidad.Value = 0;
            cmbProductos.SelectedIndex = 0;
            cont++;
            txtBuqueda.Text = "";
            cboBusqueda.DataSource = null;
            actualizarNota();
        }
        public void actualizarNota()
        {
            dgvNota.DataSource = null;
            dgvNota.DataSource = nota;
            dgvNota.RowHeadersWidth = 160;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int i = dgvNota.CurrentRow.Index;
            total -= nota.ElementAt(i).Importe;
            lblTotal.Text = total + "";
            nota.RemoveAt(i);
            actualizarNota();
        }

        private void cmbProductos_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Orden o = new Orden(1);
            OrdenDao od = new OrdenDao();
            od.Agregar(o);

            List<Orden> or = new List<Orden>();
            cont = or.Count;

            or = od.MostrarTodo();

            Orden orX = null;
            for (int i = 0; i < or.Count; i++)
            {
                orX = (Orden)(or.ElementAt(i));
            }

            int cl = orX.IDOrden;
            for (int i = 0; i < nota2.Count; i++)
            {
                Nota n = nota2.ElementAt(i);

                DetallesDeOrden ddO = new DetallesDeOrden(cl, n.Clave,
                    n.Precio, n.Cantidad, 0
                    );
                DetallesDeOrdenDao ddao = new DetallesDeOrdenDao();
                ddao.Agregar(ddO);
               

            }
            for (int i = 0; i < li.Count; i++)
            {
                ProductoDao editar = new ProductoDao();
                editar.Editar(li.ElementAt(i));
            }
            dgvNota.DataSource = null;
            nota = null;
            nota2 = null;
             nota = new List<Nota>();
             nota2 = new List<Nota>();
            lblTotal.Text = "0";
            total = 0;
        }
        List<Producto> produc = new List<Producto>();
        private void txtBuqueda_KeyDown(object sender, KeyEventArgs e)
        {
            ProductoDao p = new ProductoDao();
            String x = txtBuqueda.Text;

            produc = p.MostrarPorNombre(x);

            cboBusqueda.DataSource = null;
            cboBusqueda.DataSource = produc;
            cboBusqueda.DisplayMember = "NombreProducto";
            cboBusqueda.DroppedDown = true;

            if (txtBuqueda.Text.Trim() == "")
            {
                cboBusqueda.DataSource = null;
            }

        }

        private void cmbProductos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ProductoDao pp = new ProductoDao();
            int i = cmbProductos.SelectedIndex;
            Producto n = li.ElementAt(i);


            txtBuqueda.Text = pp.MostrarUno(n.IdProducto).NombreProducto;
            numCantidad.Maximum = n.Existecia;
            cboBusqueda.DataSource = null;
        }

        private void cboBusqueda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ProductoDao pp = new ProductoDao();
            int h = cboBusqueda.SelectedIndex;

            int x = pp.MostrarID(produc.ElementAt(h).NombreProducto).IdProducto;
            numCantidad.Maximum = pp.MostrarID(produc.ElementAt(h).NombreProducto).Existecia;

            int i = 0;
            for (int j = 0; j < li.Count; j++)
            {

                if (li.ElementAt(j).IdProducto == x)
                {
                    i = j;

                    break;
                }
            }
            cmbProductos.SelectedIndex = i;
            txtBuqueda.Text = li.ElementAt(i).NombreProducto;
            cboBusqueda.DataSource = null;
        }

        private void txtBuqueda_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbBusqueda2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbBusqueda2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void cmbBusqueda2_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbBusqueda2_TextUpdate(object sender, EventArgs e)
        {

        }

        private void txtBuqueda_KeyUp(object sender, KeyEventArgs e)
        {
            ProductoDao p = new ProductoDao();
            String x = txtBuqueda.Text;

            produc = p.MostrarPorNombre(x);

            cboBusqueda.DataSource = null;
            cboBusqueda.DataSource = produc;
            cboBusqueda.DisplayMember = "NombreProducto";
            if (txtBuqueda.Text.Trim() == "")
            {
                cboBusqueda.DataSource = null;
            }
        }
        int sec = 0;
        int m = 0;
        private void timerNote_Tick(object sender, EventArgs e)
        {
          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { hilo.Abort(); }
            catch (Exception) { }
        }
        //uso de hilos
        //delegate void NotificationsDelegate();
        delegate void Notificaciones();
        int indice = 0;
        private void MostrarNot()
        {
            if (this.InvokeRequired)
            {
                Notificaciones delegado = new Notificaciones(MostrarNot);
                Invoke(delegado);
            }
            else
            {
            
                productosAgotados();
                
                if (indice < terminados.Count)
                {
                    winNoti.llenarLista(terminados.ElementAt(indice).NombreProducto);
                }else
                {
                    indice = 0;
                    winNoti.limpiarLista();
                }
              


            }
        }
        private void CreandoNot()
        {
            while (true)
            {
             
                MostrarNot();
          
                Thread.Sleep(10000);
              
                winNoti.Visible = false;
                Thread.Sleep(10000);
                indice++;
                winNoti.Visible = true;
            }
        }
        List<Producto> terminados=new List<Producto>();
       public void productosAgotados()
        {
            for(int i = 0; i < li.Count; i++)
            {
                if (li.ElementAt(i).Existecia == 0)
                {
                    terminados.Add(li.ElementAt(i));
                }
            }
        }


        ThreadStart iniciar;
        Thread hilo;

        private void winNoti_Load(object sender, EventArgs e)
        {

        }
    }
}
