using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Examen_HilosYDatos
{
    public partial class userNot : UserControl
    {
        private int intervalo = 1000;
        public int Intervalo { get { return intervalo; } set { intervalo = value; } }
        public userNot()
        {
            InitializeComponent();
          
            cont = 0;
        }
        int cont = 0;
        public void llenarLista(String text)
        {
            Lista.Items.Add(text);
            pnlCerrar.Visible = true;
            pnlMostrar.Visible = true;
            Lista.Visible = true;

        }
        public void limpiarLista()
        {
            Lista.DataSource = null;
        }
        private void pnlMostrar_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tmrDuracion_Tick(object sender, EventArgs e)
        {
        
        }

        private void pctBCerrar_Click(object sender, EventArgs e)
        {
            pnlCerrar.Visible = false;
            pnlMostrar.Visible = false;
            Lista.Visible = false;
        }

        private void userNot_Load(object sender, EventArgs e)
        {
           
        }

        private void pnlCerrar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
