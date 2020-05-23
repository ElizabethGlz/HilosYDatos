using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class usrNot : UserControl
    {
        private int intervalo = 1000;
        public int Intervalo { get { return intervalo; } set { intervalo = value; } }
        
        public usrNot()
        {
            InitializeComponent();
            //Lista.Items.Add(text);
            cont = 0;
        }
        int cont = 0;
        private void tmrDuracion_Tick(object sender, EventArgs e)
        {
            cont++;
            if (cont == 10)
            {
                pnlCerrar.Visible = false;
                pnlMostrar.Visible = false;
            }else
            {
                cont = 0;
            }
        }

        private void pctBCerrar_Click(object sender, EventArgs e)
        {
            pnlCerrar.Visible = false;
            pnlMostrar.Visible = false;
        }

        private void usrNot_Load(object sender, EventArgs e)
        {
            tmrDuracion.Interval = intervalo;
        }
    }
}
