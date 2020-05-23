using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Examen_HilosYDatos
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        delegate void NotificationsDelegate();

        private void ShowNotifications()
        {
            if (this.InvokeRequired)
            {
                NotificationsDelegate del = new NotificationsDelegate(ShowNotifications);
                Invoke(del);
            }
            else
            {
                //var losqueyaseacabaron = ProductDAO.GetSoldOut();

                //foreach (var elem in losqueyaseacabaron)
                //    altNotifications.Show(this, "Notificación", elem.ProductName + " : " + elem.ProductID);
                userNot1.llenarLista("X");
            }
        }

        private void WaitForNotifications()
        {
            while (true)
            {
                ShowNotifications();
                Thread.Sleep(15000);
                
            }
        }

        ThreadStart start;
        Thread thread;

        //private void FrmVenta_Load(object sender, EventArgs e)
        //{
        //    start = new ThreadStart(WaitForNotifications);
        //    thread = new Thread(start);
        //    thread.Start();
        //}

        //private void btnSurtir_Click(object sender, EventArgs e)
        //{
        //    (new FrmSurtir()).ShowDialog();
        //}

        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            start = new ThreadStart(WaitForNotifications);
            thread = new Thread(start);
            thread.Start();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { thread.Abort(); }
            catch (Exception) { }
        }
        int cont = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            cont++;
            label1.Text = cont + "";
        }
    }
}
