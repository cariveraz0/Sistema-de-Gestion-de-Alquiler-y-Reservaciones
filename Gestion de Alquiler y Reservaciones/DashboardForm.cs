using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class DashboardForm : BaseForm
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            CargarIndicadoresDashboard();
        }

        private void panelKPI1_Paint_1(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI2_Paint_1(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI3_Paint_1(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI4_Paint_1(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void CargarIndicadoresDashboard()
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                // Contratos Vigentes
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Contratos c
            INNER JOIN EstadosContrato e ON c.IdEstadoContrato = e.IdEstadoContrato
            WHERE e.Nombre = 'Vigente'", cn))
                {
                    label13.Text = cmd.ExecuteScalar().ToString();
                }

                // Contratos Por Vencer
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Contratos c
            INNER JOIN EstadosContrato e ON c.IdEstadoContrato = e.IdEstadoContrato
            WHERE e.Nombre = 'Por Vencer'", cn))
                {
                    label19.Text = cmd.ExecuteScalar().ToString() + " próximos a vencer";
                }

                // Reservaciones activas de este mes
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Reservaciones r
            INNER JOIN EstadosReservacion er ON r.IdEstadoReservacion = er.IdEstadoReservacion
            WHERE er.Nombre <> 'Cancelada'
              AND MONTH(r.FechaEntrada) = MONTH(GETDATE())
              AND YEAR(r.FechaEntrada)  = YEAR(GETDATE())", cn))
                {
                    label15.Text = cmd.ExecuteScalar().ToString();
                }

                // Mantenimientos pendientes
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Mantenimiento m
            INNER JOIN EstadosMantenimiento em ON m.IdEstadoMantenimiento = em.IdEstadoMantenimiento
            WHERE em.Nombre = 'Pendiente'", cn))
                {
                    label17.Text = cmd.ExecuteScalar().ToString();
                }
            }
        }
    }
}
