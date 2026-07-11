using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_de_Alquiler_y_Reservaciones.Reportes;

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
            CargarDatosUsuario();
            AbrirForm(new DashboardForm());
        }

        private void CargarDatosUsuario()
        {
            string nombre = LoginForm.nombreCompleto;
            
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                nombre = nombre.Trim();
                lblUsuario.Text = nombre;
                lblInicial.Text = nombre.Substring(0, 1).ToUpper();
            }
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

        private void reporteDeContratosVigentesYSuEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteContratosVigentes frm = new ReporteContratosVigentes();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM yyyy");
            lblHora.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void historialDeMantenimientoPorPropiedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialMantenimientoPropiedad frm = new HistorialMantenimientoPropiedad();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void resumenDeSolicitudesDeMantenimientoPorEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResumenMantenimientoEstado frm = new ResumenMantenimientoEstado();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void reporteDeReservacionesPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SeleccionarPeriodoForm formPeriodo = new SeleccionarPeriodoForm())
            {
                if (formPeriodo.ShowDialog() == DialogResult.OK)
                {
                    ReporteReservacionesPeriodo frm = new ReporteReservacionesPeriodo(
                        formPeriodo.FechaInicio,
                        formPeriodo.FechaFin
                    );

                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
        }

        private void estadoDeCuentaPorArrendatarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstadoCuentaArrendatario frm = new EstadoCuentaArrendatario();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void estadísticasDeOcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EstadisticasOcupacionPropiedad frm = new EstadisticasOcupacionPropiedad();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void resumenDeIngresosPorConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SeleccionarPeriodoIngresosForm formPeriodo = new SeleccionarPeriodoIngresosForm())
            {
                if (formPeriodo.ShowDialog() == DialogResult.OK)
                {
                    ResumenIngresosConcepto frm = new ResumenIngresosConcepto(
                        formPeriodo.FechaInicio,
                        formPeriodo.FechaFin
                    );

                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
        }

        private void casasVacacionalesReservadasConPagoEnEfectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCasasReservadasEfectivo frm = new ReporteCasasReservadasEfectivo();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
