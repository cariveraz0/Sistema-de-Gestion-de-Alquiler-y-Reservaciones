using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class ReporteBase : Form
    {
        private bool esCierrePermitido = false;
        private object da;
        public ReporteBase()
        {
            InitializeComponent();
            
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
        }

        private void ReporteContratosVigentes_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1000, 700);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            esCierrePermitido = true;
            this.Close();
        }

        private void ReporteBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!esCierrePermitido && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}
