using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class EstadisticasOcupacionPropiedad : ReporteBase
    {
        private List<string> listaPropiedadesReservadas = new List<string>();

        public EstadisticasOcupacionPropiedad()
        {
            InitializeComponent();
            cmbTiposPropiedad.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EstadisticasOcupacionPropiedad_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView(dgvInformacion);
            CargarTiposPropiedad();

            if (cmbTiposPropiedad.SelectedIndex == -1)
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
                btnConsultar.Enabled = false;
                dgvInformacion.Enabled = false;
            }
        }
        private void ConfigurarDataGridView(DataGridView grid)
        {
            Color naranjaTitulo = ColorTranslator.FromHtml("#D87A2D");

            grid.RowHeadersVisible = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeColumns = true;               
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(225, 225, 225);
            grid.DefaultCellStyle.SelectionBackColor = grid.DefaultCellStyle.BackColor;
            grid.DefaultCellStyle.SelectionForeColor = grid.DefaultCellStyle.ForeColor;

            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = grid.AlternatingRowsDefaultCellStyle.BackColor;
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void CargarTiposPropiedad()
        {
            try
            {
                // Obtenemos los tipos reales de la base de datos para no quemar IDs fijos
                string query = "SELECT IdTipoPropiedad, Nombre FROM TiposPropiedad";
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dtOriginal = new DataTable();
                    adapter.Fill(dtOriginal);

                    // Estructura personalizada para el ComboBox (Nombre visible e IDs de mapeo)
                    DataTable dtCombo = new DataTable();
                    dtCombo.Columns.Add("Nombre", typeof(string));
                    dtCombo.Columns.Add("Ids", typeof(string)); // Cadena de IDs separados por coma (ej: "4,5")

                    string idApartamento = "";
                    string idCasa = "";
                    string idAuditorio = "";
                    string idSala = "";

                    // Buscamos dinámicamente los IDs correspondientes por su nombre en la base de datos
                    foreach (DataRow row in dtOriginal.Rows)
                    {
                        string nombre = row["Nombre"].ToString().Trim();
                        string id = row["IdTipoPropiedad"].ToString();

                        if (nombre.Equals("Apartamento", StringComparison.OrdinalIgnoreCase)) idApartamento = id;
                        else if (nombre.Equals("Casa de Playa/Montaña", StringComparison.OrdinalIgnoreCase)) idCasa = id;
                        else if (nombre.Equals("Auditorio", StringComparison.OrdinalIgnoreCase)) idAuditorio = id;
                        else if (nombre.Equals("Sala de Juntas", StringComparison.OrdinalIgnoreCase)) idSala = id;
                        // "Local Comercial" no se procesa, cumpliendo con la exclusión solicitada
                    }

                    // Construimos las opciones deseadas
                    if (!string.IsNullOrEmpty(idApartamento))
                        dtCombo.Rows.Add("Apartamentos", idApartamento);

                    if (!string.IsNullOrEmpty(idCasa))
                        dtCombo.Rows.Add("Casas de Playa/Montaña", idCasa);

                    // Fusionamos Auditorio y Sala de Juntas en una sola opción comercial
                    if (!string.IsNullOrEmpty(idAuditorio) && !string.IsNullOrEmpty(idSala))
                        dtCombo.Rows.Add("Auditorio/Salas de Juntas", $"{idAuditorio},{idSala}");
                    else if (!string.IsNullOrEmpty(idAuditorio))
                        dtCombo.Rows.Add("Auditorio", idAuditorio);
                    else if (!string.IsNullOrEmpty(idSala))
                        dtCombo.Rows.Add("Salas de Juntas", idSala);

                    cmbTiposPropiedad.DisplayMember = "Nombre";
                    cmbTiposPropiedad.ValueMember = "Ids";
                    cmbTiposPropiedad.DataSource = dtCombo;

                    cmbTiposPropiedad.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de propiedad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTiposPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTiposPropiedad.SelectedIndex != -1)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
                btnConsultar.Enabled = true;
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha inicial no debe ser mayor a la fecha final", "Rango de fecha inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTiposPropiedad.SelectedValue != null)
            {
                string idsString = cmbTiposPropiedad.SelectedValue.ToString();
                dgvInformacion.Enabled = true;

                listaPropiedadesReservadas = buscarTipoPropiedades(idsString);
                llenargrafico();
                llenardgv(idsString);
            }
        }

        private List<string> buscarTipoPropiedades(string idsString)
        {
            List<string> propiedades = new List<string>();
            try
            {
                // 1. Alineamos la consulta para usar FechaInicio y FechaFin (Lógica de traslape)
                string queryBuscarTipoPropiedades = $@"
            WITH Ocupaciones AS (
                SELECT IdPropiedad, FechaEntrada AS FechaInicio, FechaSalida AS FechaFin FROM Reservaciones
                UNION ALL
                SELECT IdPropiedad, FechaInicio, FechaFin FROM Contratos
            )
            SELECT P.Codigo 
            FROM Ocupaciones AS O 
            INNER JOIN Propiedades AS P ON O.IdPropiedad = P.IdPropiedad 
            WHERE P.IdTipoPropiedad IN ({idsString}) 
            AND CAST(O.FechaInicio AS DATE) <= @hasta 
            AND CAST(O.FechaFin AS DATE) >= @desde";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdBuscarTipoPropiedades = new SqlCommand(queryBuscarTipoPropiedades, conectar);
                    cmdBuscarTipoPropiedades.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);

                    DateTime fechaHastaFinDelDia = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                    cmdBuscarTipoPropiedades.Parameters.AddWithValue("@hasta", fechaHastaFinDelDia);

                    SqlDataReader readerBuscarTipoPropiedades = cmdBuscarTipoPropiedades.ExecuteReader();
                    while (readerBuscarTipoPropiedades.Read())
                    {
                        propiedades.Add(readerBuscarTipoPropiedades["Codigo"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return propiedades;
        }

        private void llenargrafico()
        {
            try
            {
                chartOcupacionPropiedades.Series.Clear();
                chartOcupacionPropiedades.Titles.Clear();

                Title titulo = chartOcupacionPropiedades.Titles.Add($"Ocupación en {cmbTiposPropiedad.Text}");
                titulo.Font = new Font("Montserrat", 11, FontStyle.Bold);

                Series seriePastel = new Series("Ocupación");
                seriePastel.ChartType = SeriesChartType.Pie;
                chartOcupacionPropiedades.Series.Add(seriePastel);

                Dictionary<string, int> conteoPropiedades = new Dictionary<string, int>();
                foreach (string propiedad in listaPropiedadesReservadas)
                {
                    if (conteoPropiedades.ContainsKey(propiedad))
                        conteoPropiedades[propiedad]++;
                    else
                        conteoPropiedades.Add(propiedad, 1);
                }

                string[] coloresHex = { "#E6B340", "#D67A31", "#FFC69C", "#C84F24" };
                int colorIndex = 0;

                foreach (KeyValuePair<string, int> resultado in conteoPropiedades)
                {
                    int nuevoPuntoIndex = seriePastel.Points.AddXY(resultado.Key, resultado.Value);
                    DataPoint punto = seriePastel.Points[nuevoPuntoIndex];

                    punto.Color = ColorTranslator.FromHtml(coloresHex[colorIndex % coloresHex.Length]);
                    colorIndex++;

                    punto.LegendText = resultado.Key;
                    punto.Label = "#PERCENT{P0}";
                }

                seriePastel.IsValueShownAsLabel = true;
                seriePastel.Font = new Font("Montserrat", 10, FontStyle.Bold);

                chartOcupacionPropiedades.Legends[0].Docking = Docking.Bottom;
                chartOcupacionPropiedades.Legends[0].Alignment = StringAlignment.Center;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenardgv(string idsString)
        {
            try
            {
                // 2. Aplicamos la misma lógica exacta en el DGV para que los datos coincidan 100% con el pastel
                string queryLlenarDGV = $@"
            WITH Ocupaciones AS (
                SELECT IdPropiedad, FechaEntrada AS FechaInicio, FechaSalida AS FechaFin FROM Reservaciones
                UNION ALL
                SELECT IdPropiedad, FechaInicio, FechaFin FROM Contratos
            )
            SELECT P.IdPropiedad AS [ID Propiedad], P.Codigo AS [Nombre de Propiedad], COUNT(O.IdPropiedad) as Cantidad 
            FROM Propiedades AS P
            LEFT JOIN Ocupaciones AS O 
                ON O.IdPropiedad = P.IdPropiedad 
                AND CAST(O.FechaInicio AS DATE) <= @hasta
                AND CAST(O.FechaFin AS DATE) >= @desde
            WHERE P.IdTipoPropiedad IN ({idsString}) 
            GROUP BY P.IdPropiedad, P.Codigo
            ORDER BY [Cantidad] DESC";

                DataTable dtInformacion = new DataTable();
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdLlenarDGV = new SqlCommand(queryLlenarDGV, conectar);
                    cmdLlenarDGV.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);

                    DateTime fechaHastaFinDelDia = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                    cmdLlenarDGV.Parameters.AddWithValue("@hasta", fechaHastaFinDelDia);

                    SqlDataAdapter adaptador = new SqlDataAdapter(cmdLlenarDGV);
                    adaptador.Fill(dtInformacion);
                }
                dgvInformacion.DataSource = dtInformacion;

                if (dgvInformacion.Columns["Cantidad"] != null)
                {
                    dgvInformacion.Columns["Cantidad"].HeaderText =
                        cmbTiposPropiedad.Text.Equals("Apartamentos", StringComparison.OrdinalIgnoreCase)
                            ? "Rotación de Inquilinos"
                            : "Cantidad de Reservaciones";

                    dgvInformacion.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}