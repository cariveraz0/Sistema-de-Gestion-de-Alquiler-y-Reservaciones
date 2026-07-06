using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class ResumenIngresosConcepto : ReporteBase
    {

        private DateTime fechaInicio;
        private DateTime fechaFin;
        private DataGridView dgvIngresos;
        private Chart chartIngresos;
        private Label lblNota;

        public ResumenIngresosConcepto()
    :              this(new DateTime(2026, 1, 1), new DateTime(2026, 12, 31))
        {
        }

        public ResumenIngresosConcepto(DateTime inicio, DateTime fin)
        {
            fechaInicio = inicio;
            fechaFin = fin;

            InitializeComponent();
            label1.BorderStyle = BorderStyle.None;
            CrearControlesReporte();
            CargarIngresos();
        }

        private void CrearControlesReporte()
        {
            Color naranjaTitulo = Color.FromArgb(216, 122, 45);

            label1.Text = "REPORTE RESUMEN DE\nINGRESOS POR CONCEPTO";
            label1.Size = new Size(600, 60);
            label1.Location = new Point(330, 35);
            label1.TextAlign = ContentAlignment.MiddleCenter;

            Label lblPeriodo = new Label();
            lblPeriodo.Text = $"PERIODO: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}";
            lblPeriodo.Location = new Point(25, 115);
            lblPeriodo.Size = new Size(520, 30);
            lblPeriodo.BackColor = naranjaTitulo;
            lblPeriodo.ForeColor = Color.White;
            lblPeriodo.Font = new Font("Montserrat", 10, FontStyle.Bold);
            lblPeriodo.TextAlign = ContentAlignment.MiddleCenter;
            pnlPrincipal.Controls.Add(lblPeriodo);

            dgvIngresos = new DataGridView();
            dgvIngresos.Location = new Point(25, 155);
            dgvIngresos.Size = new Size(520, 198);
            dgvIngresos.ReadOnly = true;
            dgvIngresos.AllowUserToAddRows = false;
            dgvIngresos.RowHeadersVisible = false;
            dgvIngresos.ScrollBars = ScrollBars.None;
            dgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngresos.BackgroundColor = Color.White;
            dgvIngresos.EnableHeadersVisualStyles = false;
            dgvIngresos.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            dgvIngresos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIngresos.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);
            dgvIngresos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngresos.RowTemplate.Height = 28;
            dgvIngresos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresos.MultiSelect = false;
            dgvIngresos.CellFormatting += DgvIngresos_CellFormatting;
            dgvIngresos.SelectionChanged += (s, e) => dgvIngresos.ClearSelection();
            pnlPrincipal.Controls.Add(dgvIngresos);

            Label lblTituloGrafico = new Label();
            lblTituloGrafico.Text = "DISTRIBUCIÓN DE INGRESOS POR CONCEPTOS";
            lblTituloGrafico.Location = new Point(570, 125);
            lblTituloGrafico.Size = new Size(395, 25);
            lblTituloGrafico.BackColor = naranjaTitulo;
            lblTituloGrafico.ForeColor = Color.White;
            lblTituloGrafico.Font = new Font("Montserrat", 8, FontStyle.Bold);
            lblTituloGrafico.TextAlign = ContentAlignment.MiddleCenter;
            pnlPrincipal.Controls.Add(lblTituloGrafico);

            chartIngresos = new Chart();
            chartIngresos.Location = new Point(550, 150);
            chartIngresos.Size = new Size(250, 210);
            chartIngresos.BackColor = pnlPrincipal.BackColor;

            ChartArea area = new ChartArea();
            area.BackColor = pnlPrincipal.BackColor;
            area.BorderColor = pnlPrincipal.BackColor;
            area.Position.Auto = false;
            area.Position.X = 0;
            area.Position.Y = 5;
            area.Position.Width = 100;
            area.Position.Height = 90;
            chartIngresos.ChartAreas.Add(area);

            Series serie = new Series();
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;
            serie.Label = "#PERCENT{P0}";
            chartIngresos.Series.Add(serie);
            chartIngresos.Legends.Clear();

            pnlPrincipal.Controls.Add(chartIngresos);

            Panel pnlLeyenda = new Panel();
            pnlLeyenda.Location = new Point(785, 170);
            pnlLeyenda.Size = new Size(180, 150);
            pnlLeyenda.BackColor = pnlPrincipal.BackColor;
            pnlPrincipal.Controls.Add(pnlLeyenda);

            AgregarLeyenda(pnlLeyenda, "Alquiler de locales comerciales", Color.FromArgb(216, 122, 45), 0);
            AgregarLeyenda(pnlLeyenda, "Alquiler de viviendas", Color.FromArgb(239, 154, 70), 28);
            AgregarLeyenda(pnlLeyenda, "Reservaciones de auditorio", Color.FromArgb(246, 180, 89), 56);
            AgregarLeyenda(pnlLeyenda, "Reservaciones de sala de \njuntas", Color.FromArgb(255, 205, 120), 84);
            AgregarLeyenda(pnlLeyenda, "Propiedades vacacionales", Color.FromArgb(196, 87, 32), 112);

            lblNota = new Label();
            lblNota.Text = "Nota: Los ingresos incluyen todos los pagos recibidos mediante efectivo, tarjeta u otros métodos durante el período seleccionado.";
            lblNota.Location = new Point(45, 385);
            lblNota.Size = new Size(900, 25);
            lblNota.Font = new Font("Montserrat", 9, FontStyle.Bold);
            lblNota.ForeColor = Color.Black;
            lblNota.TextAlign = ContentAlignment.MiddleLeft;
            pnlPrincipal.Controls.Add(lblNota);
        }

        private void AgregarLeyenda(Panel panel, string texto, Color color, int y)
        {
            Panel cuadroColor = new Panel();
            cuadroColor.Location = new Point(0, y + 6);
            cuadroColor.Size = new Size(18, 10);
            cuadroColor.BackColor = color;
            panel.Controls.Add(cuadroColor);

            Label lbl = new Label();
            lbl.Text = texto;
            lbl.Location = new Point(25, y);
            lbl.Size = new Size(155, 25);
            lbl.Font = new Font("Montserrat", 7, FontStyle.Regular);
            lbl.ForeColor = Color.Black;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            panel.Controls.Add(lbl);
        }

        private void CargarIngresos()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"
                    WITH Conceptos AS (
                        SELECT 1 AS Orden, 'Alquiler de locales comerciales' AS Concepto
                        UNION ALL SELECT 2, 'Alquiler de viviendas'
                        UNION ALL SELECT 3, 'Reservaciones de auditorio'
                        UNION ALL SELECT 4, 'Reservaciones de sala de juntas'
                        UNION ALL SELECT 5, 'Propiedades vacacionales'
                    ),
                    Ingresos AS (
                        SELECT 
                            CASE 
                                WHEN tp.Nombre = 'Local Comercial' THEN 'Alquiler de locales comerciales'
                                WHEN tp.Nombre = 'Apartamento' THEN 'Alquiler de viviendas'
                                WHEN tp.Nombre = 'Auditorio' THEN 'Reservaciones de auditorio'
                                WHEN tp.Nombre = 'Sala de Juntas' THEN 'Reservaciones de sala de juntas'
                                WHEN tp.Nombre = 'Casa de Playa/Montaña' THEN 'Propiedades vacacionales'
                                ELSE tp.Nombre
                            END AS Concepto,
                            p.Monto
                        FROM Pagos p
                        LEFT JOIN Reservaciones r ON p.IdReservacion = r.IdReservacion
                        LEFT JOIN Propiedades pr ON r.IdPropiedad = pr.IdPropiedad
                        LEFT JOIN TiposPropiedad tp ON pr.IdTipoPropiedad = tp.IdTipoPropiedad
                        WHERE p.IdReservacion IS NOT NULL
                            AND p.FechaPago >= @FechaInicio
                            AND p.FechaPago < DATEADD(DAY, 1, @FechaFin)

                        UNION ALL

                        SELECT 
                            CASE 
                                WHEN tp.Nombre = 'Local Comercial' THEN 'Alquiler de locales comerciales'
                                WHEN tp.Nombre = 'Apartamento' THEN 'Alquiler de viviendas'
                                WHEN tp.Nombre = 'Auditorio' THEN 'Reservaciones de auditorio'
                                WHEN tp.Nombre = 'Sala de Juntas' THEN 'Reservaciones de sala de juntas'
                                WHEN tp.Nombre = 'Casa de Playa/Montaña' THEN 'Propiedades vacacionales'
                                ELSE tp.Nombre
                            END AS Concepto,
                            p.Monto
                        FROM Pagos p
                        INNER JOIN CuotasContrato cc ON p.IdCuota = cc.IdCuota
                        INNER JOIN Contratos c ON cc.IdContrato = c.IdContrato
                        INNER JOIN Propiedades pr ON c.IdPropiedad = pr.IdPropiedad
                        INNER JOIN TiposPropiedad tp ON pr.IdTipoPropiedad = tp.IdTipoPropiedad
                        WHERE p.IdCuota IS NOT NULL
                          AND p.FechaPago >= @FechaInicio
                          AND p.FechaPago < DATEADD(DAY, 1, @FechaFin)
                    )
                    SELECT c.Concepto, ISNULL(SUM(i.Monto), 0) AS TotalIngresos
                    FROM Conceptos c
                    LEFT JOIN Ingresos i ON c.Concepto = i.Concepto
                    GROUP BY c.Orden, c.Concepto
                    ORDER BY c.Orden;
                ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                decimal totalGeneral = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalGeneral += Convert.ToDecimal(row["TotalIngresos"]);
                }

                DataTable tabla = new DataTable();
                tabla.Columns.Add("CONCEPTO");
                tabla.Columns.Add("TOTAL INGRESOS");
                tabla.Columns.Add("PORCENTAJE");

                chartIngresos.Series[0].Points.Clear();

                Color[] coloresNaranja =
                {
                    Color.FromArgb(216, 122, 45),
                    Color.FromArgb(239, 154, 70),
                    Color.FromArgb(246, 180, 89),
                    Color.FromArgb(255, 205, 120),
                    Color.FromArgb(196, 87, 32)
                };

                int indiceColor = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string concepto = row["Concepto"].ToString();
                    decimal total = Convert.ToDecimal(row["TotalIngresos"]);
                    decimal porcentaje = totalGeneral > 0 ? (total / totalGeneral) * 100 : 0;

                    tabla.Rows.Add(concepto, "L. " + total.ToString("N2"), porcentaje.ToString("N0") + "%");

                    if (total > 0)
                    {
                        int punto = chartIngresos.Series[0].Points.AddXY(concepto, total);
                        chartIngresos.Series[0].Points[punto].Color = coloresNaranja[indiceColor % coloresNaranja.Length];
                    }

                    indiceColor++;
                }

                tabla.Rows.Add("TOTAL GENERAL", "L. " + totalGeneral.ToString("N2"), "100%");

                dgvIngresos.DataSource = tabla;
                dgvIngresos.ClearSelection();
            }
        }

        private void DgvIngresos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string concepto = dgvIngresos.Rows[e.RowIndex].Cells["CONCEPTO"].Value?.ToString();

                if (concepto == "TOTAL GENERAL")
                {
                    e.CellStyle.BackColor = Color.FromArgb(216, 122, 45);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(216, 122, 45);
                    e.CellStyle.SelectionForeColor = Color.White;
                    e.CellStyle.Font = new Font("Montserrat", 8, FontStyle.Bold);
                }
            }
        }
    }
}