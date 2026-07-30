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
        private string nombres = string.Empty;

        public MenuPrincipalForm()
        {
            InitializeComponent();
            btnPrincipal.Click += CambiarTitulo_Click;
            btnPropiedades.Click += CambiarTitulo_Click;
            btnContratos.Click += CambiarTitulo_Click;
            btnReservaciones.Click += CambiarTitulo_Click;
            btnClientes.Click += CambiarTitulo_Click;
            btnMantenimiento.Click += CambiarTitulo_Click;
            btnReportes.Click += CambiarTitulo_Click;
            btnPagos.Click += CambiarTitulo_Click;
        }
        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            AbrirForm(new DashboardForm());
        }

        private void CambiarTitulo_Click(object sender, EventArgs e)
        {
            if (sender is Button botonPresionado)
            {
                lblTitulo.Text = botonPresionado.Text;

                if (botonPresionado.Name == "btnPrincipal")
                {
                    lblSubtitulo.Visible = true;
                }
                else
                {
                    lblSubtitulo.Visible = false;
                }
            }
        }

        private void CargarDatosUsuario()
        {
            lblInicial.Text = LoginForm.nombreCompleto.Substring(0, 1).ToUpper();
            string[] nombrePartes = LoginForm.nombreCompleto.Split(' ');
            nombres = nombrePartes[0] + " " + nombrePartes[2];
            lblUsuario.Text = nombres;
            lblCargo.Text = LoginForm.cargo;
        }

        private void AbrirForm(Form formNuevo)
        {
            string nombreForm = formNuevo.GetType().Name;

            if (!PermisosHelper.TieneAcceso(LoginForm.cargo, nombreForm))
            {
                MessageBox.Show(
                    "No tiene acceso a este módulo.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                formNuevo.Dispose();
                return;
            }

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
            //ContratosForm frm = new ContratosForm();
            //frm.ShowDialog();
            //this.Close();
            AbrirForm(new ContratosForm());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM yyyy");
            lblHora.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirForm(new ReportesForm());
        }

        private void btnReservaciones_Click(object sender, EventArgs e)
        {
            AbrirForm(new ReservacionesForm());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirForm(new ClientesForm());
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            AbrirForm(new MantenimientoForm());
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            AbrirForm(new PagosForm());
        }
    }
}
