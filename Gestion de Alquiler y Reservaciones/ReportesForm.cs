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
    public partial class ReportesForm : BaseForm
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        private void btnReporteDeContratosVigentesYSuEstado_Click(object sender, EventArgs e)
        {
            if (!ValidarAccesoReporte("Contratos")) return;
            ReporteContratosVigentes frm = new ReporteContratosVigentes();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnHistorialDeMantenimientoPorPropiedad_Click(object sender, EventArgs e)
        {
            if (!ValidarAccesoReporte("Mantenimiento")) return;
            HistorialMantenimientoPropiedad frm = new HistorialMantenimientoPropiedad();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnResumenDeSolicitudesDeMantenimientoPorEstado_Click(object sender, EventArgs e)
        {
            if (!ValidarAccesoReporte("Mantenimiento")) return;
            ResumenMantenimientoEstado frm = new ResumenMantenimientoEstado();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnReporteDeReservacionesPorPeríodo_Click(object sender, EventArgs e)
        {
            if (!ValidarAccesoReporte("Reservaciones")) return;
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

        private void btnCasasVacacionalesReservadasConPagoEnEfectivo_Click(object sender, EventArgs e)
        {
            if (!ValidarAccesoReporte("Reservaciones")) return;
            ReporteCasasReservadasEfectivo frm = new ReporteCasasReservadasEfectivo();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnEstadoDeCuentaPorArrendatario_Click(object sender, EventArgs e)
        {
            if (!ValidarAccesoReporte("Pagos")) return;
            EstadoCuentaArrendatario frm = new EstadoCuentaArrendatario();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnEstadísticasDeOc_Click(object sender, EventArgs e)
        {
            if (!ValidarAccesoReporte("Propiedades")) return;
            EstadisticasOcupacionPropiedad frm = new EstadisticasOcupacionPropiedad();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnResumenDeIngresosPorConcepto_Click(object sender, EventArgs e)
        {
            if (!ValidarAccesoReporte("Administracion")) return;
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
        private bool ValidarAccesoReporte(string categoria)
        {
            if (!PermisosHelper.TieneAccesoReporte(LoginForm.cargo, categoria))
            {
                MessageBox.Show(
                    "No tiene acceso a este reporte.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
            return true;
        }
    }
}
