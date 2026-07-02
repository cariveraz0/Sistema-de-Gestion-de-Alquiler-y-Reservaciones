using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class MenuPrincipalForm : Form
    {
        private Form formActivo = null;
        private Button botonActual = null;

        public MenuPrincipalForm()
        {
            InitializeComponent();
        }
        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {
            //AbrirForm(new DashboardForm());
        }

        private void AbrirForm(Form formNuevo)
        {
            if (formActivo != null)
            {
                formActivo.Close();
                formActivo = null;
            }

            formNuevo.TopLevel = false;
            formNuevo.FormBorderStyle = FormBorderStyle.None;
            formNuevo.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formNuevo);
            formNuevo.BringToFront();
            formNuevo.Show();

            formActivo = formNuevo;
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            AbrirForm(new DashboardForm());
        }

        private void btnPropiedades_Click(object sender, EventArgs e)
        {
            AbrirForm(new PropiedadesForm());
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            ContratosForm frm = new ContratosForm();
            frm.ShowDialog();
            this.Close();
            AbrirForm(new ContratoForm());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
