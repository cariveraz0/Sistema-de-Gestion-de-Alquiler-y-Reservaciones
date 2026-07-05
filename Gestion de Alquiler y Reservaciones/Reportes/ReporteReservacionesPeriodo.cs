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

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class ReporteReservacionesPeriodo : ReporteBase
    {
        private DataGridView dgvReservaciones;
        private Label lblTotal, lblConfirmadas, lblFinalizadas, lblPendientes, lblCanceladas, lblMontoTotal;
        private DateTime fechaInicio;
        private DateTime fechaFin;

        public ReporteReservacionesPeriodo()
    :       this(new DateTime(2026, 6, 1), new DateTime(2026, 6, 30))
        {
        }

        public ReporteReservacionesPeriodo(DateTime inicio, DateTime fin)
        {
            fechaInicio = inicio;
            fechaFin = fin;

            InitializeComponent();
            CrearControlesReporte();
            CargarReporteReservaciones();
        }

        private void CrearControlesReporte()
        {
            Color naranjaTitulo = Color.FromArgb(216, 122, 45);
            Label lblPeriodo = new Label();
            lblPeriodo.Text = $"PERIODO CONSULTADO: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}";
            lblPeriodo.Location = new Point(60, 95);
            lblPeriodo.Size = new Size(860, 25);
            lblPeriodo.BackColor = naranjaTitulo;
            lblPeriodo.ForeColor = Color.White;
            lblPeriodo.Font = new Font("Arial", 10, FontStyle.Bold);
            lblPeriodo.TextAlign = ContentAlignment.MiddleCenter;
            pnlPrincipal.Controls.Add(lblPeriodo);

            dgvReservaciones = new DataGridView();
            dgvReservaciones.Location = new Point(60, 130);
            dgvReservaciones.Size = new Size(860, 180);
            dgvReservaciones.RowHeadersVisible = false;
            dgvReservaciones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservaciones.RowTemplate.Height = 28;
            dgvReservaciones.ReadOnly = true;
            dgvReservaciones.AllowUserToAddRows = false;
            dgvReservaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservaciones.BackgroundColor = Color.White;
            dgvReservaciones.EnableHeadersVisualStyles = false;
            dgvReservaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 91, 43);
            dgvReservaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvReservaciones.DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            dgvReservaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(225, 225, 225);
            dgvReservaciones.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            pnlPrincipal.Controls.Add(dgvReservaciones);


            Panel pnlResumen = new Panel();
            pnlResumen.Location = new Point(60, 340);
            pnlResumen.Size = new Size(860, 85);
            pnlResumen.BackColor = Color.FromArgb(230, 230, 230);
            pnlPrincipal.Controls.Add(pnlResumen);

            Label lblTituloResumen = new Label();
            lblTituloResumen.Text = "RESUMEN DEL PERIODO";
            lblTituloResumen.Location = new Point(0, 0);
            lblTituloResumen.Size = new Size(860, 25);
            lblTituloResumen.BackColor = naranjaTitulo;
            lblTituloResumen.ForeColor = Color.White;
            lblTituloResumen.Font = new Font("Arial", 9, FontStyle.Bold);
            lblTituloResumen.TextAlign = ContentAlignment.MiddleCenter;
            pnlResumen.Controls.Add(lblTituloResumen);

            lblTotal = CrearLabelResumen("TOTAL:\n0", 0, 110);
            lblConfirmadas = CrearLabelResumen("CONFIRMADAS:\n0", 135, 125);
            lblFinalizadas = CrearLabelResumen("FINALIZADAS:\n0", 275, 125);
            lblPendientes = CrearLabelResumen("PENDIENTES:\n0", 415, 125);
            lblCanceladas = CrearLabelResumen("CANCELADAS:\n0", 555, 125);
            lblMontoTotal = CrearLabelResumen("TOTAL MONTO:\nL. 0.00", 690, 150);

            pnlResumen.Controls.Add(lblTotal);
            pnlResumen.Controls.Add(lblConfirmadas);
            pnlResumen.Controls.Add(lblFinalizadas);
            pnlResumen.Controls.Add(lblPendientes);
            pnlResumen.Controls.Add(lblCanceladas);
            pnlResumen.Controls.Add(lblMontoTotal);

            Label lblNota = new Label();
            lblNota.Text = "Nota: Este reporte incluye todas las reservaciones realizadas dentro del rango de fechas seleccionado.";
            lblNota.Location = new Point(60, 430);
            lblNota.Size = new Size(860, 22);
            lblNota.Font = new Font("Arial", 9, FontStyle.Bold);
            lblNota.ForeColor = Color.Black;
            lblNota.TextAlign = ContentAlignment.MiddleLeft;
            pnlPrincipal.Controls.Add(lblNota);
        }

        private Label CrearLabelResumen(string texto, int x, int ancho)
        {
            return new Label
            {
                Text = texto,
                Location = new Point(x, 32),
                Size = new Size(ancho, 40),
                Font = new Font("Arial", 8, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private void CargarReporteReservaciones()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"
                   SELECT 
                    ROW_NUMBER() OVER (ORDER BY r.FechaEntrada) AS [#],
                    c.NombreCompleto AS [Cliente],
                    p.Codigo AS [Espacio Reservado],
                FORMAT(r.FechaEntrada, 'dd/MM/yyyy') AS [Fecha de Reserva],
                 CASE 
                    WHEN CAST(r.FechaEntrada AS DATE) = CAST(r.FechaSalida AS DATE)
                    THEN FORMAT(r.FechaEntrada, 'hh:mm tt') + ' - ' + FORMAT(r.FechaSalida, 'hh:mm tt')
                       ELSE FORMAT(r.FechaEntrada, 'dd/MM/yyyy') + ' - ' + FORMAT(r.FechaSalida, 'dd/MM/yyyy')
                    END AS [Hora / Día],
                    CASE 
                    WHEN er.Nombre = 'Completada' THEN 'Finalizada'
                       ELSE er.Nombre
                 END AS [Estado],
                'L. ' + FORMAT(r.MontoTotal, 'N2') AS [Monto Cobrado],
                 r.MontoTotal
                FROM Reservaciones r
               INNER JOIN Clientes c ON r.IdCliente = c.IdCliente
                INNER JOIN Propiedades p ON r.IdPropiedad = p.IdPropiedad
                    INNER JOIN EstadosReservacion er ON r.IdEstadoReservacion = er.IdEstadoReservacion
                WHERE r.FechaEntrada >= @FechaInicio
                AND r.FechaEntrada < DATEADD(DAY, 1, @FechaFin)
                ORDER BY r.FechaEntrada;
                ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvReservaciones.RowHeadersVisible = false;
                dgvReservaciones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvReservaciones.DataBindingComplete += (s, e) =>
                {
                    if (dgvReservaciones.Columns.Count > 0 && dgvReservaciones.Columns[0] != null)
                    {
                        dgvReservaciones.Columns[0].Width = 35;
                        dgvReservaciones.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvReservaciones.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                };

                dgvReservaciones.DataSource = dt;
                dgvReservaciones.RowHeadersVisible = false;

               


                if (dgvReservaciones.Columns.Contains("MontoTotal"))
                {
                    dgvReservaciones.Columns["MontoTotal"].Visible = false;
                }

                CargarResumen(dt);
            }
        }

        private void CargarResumen(DataTable dt)
        {
            int confirmadas = 0, finalizadas = 0, pendientes = 0, canceladas = 0;
            decimal totalMonto = 0;

            foreach (DataRow row in dt.Rows)
            {
                string estado = row["Estado"].ToString();

                if (estado == "Confirmada") confirmadas++;
                else if (estado == "Finalizada") finalizadas++;
                else if (estado == "Pendiente") pendientes++;
                else if (estado == "Cancelada") canceladas++;

                totalMonto += Convert.ToDecimal(row["MontoTotal"]);
            }

            lblTotal.Text = "TOTAL:\n" + dt.Rows.Count;
            lblConfirmadas.Text = "CONFIRMADAS:\n" + confirmadas;
            lblFinalizadas.Text = "FINALIZADAS:\n" + finalizadas;
            lblPendientes.Text = "PENDIENTES:\n" + pendientes;
            lblCanceladas.Text = "CANCELADAS:\n" + canceladas;
            lblMontoTotal.Text = "TOTAL MONTO:\nL. " + totalMonto.ToString("N2");
        }
    }
}
