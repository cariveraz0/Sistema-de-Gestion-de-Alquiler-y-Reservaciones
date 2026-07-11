using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class ReporteCasasReservadasEfectivo : ReporteBase
    {
        private DataTable dtCompleto;

        public ReporteCasasReservadasEfectivo()
        {
            InitializeComponent();
            cmbAño.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ReporteCasasReservadasEfectivo_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView(dgvCasas);
            buscarClientes();
            CargarAnios();
            dgvCasas.Enabled = false;
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
        }

        private void buscarClientes()
        {
            cmbClientes.Items.Clear();
            try
            {
                string queryBuscarClientes =
                    "select distinct Cli.NombreCompleto " +
                    "from Reservaciones as Res " +
                    "inner join Propiedades as Prop on Res.IdPropiedad = Prop.IdPropiedad " +
                    "inner join TiposPropiedad as TiPr on Prop.IdTipoPropiedad = TiPr.IdTipoPropiedad " +
                    "inner join Pagos as Pa on Res.IdReservacion = Pa.IdReservacion " +
                    "inner join MetodosPago as MP on Pa.IdMetodoPago = MP.IdMetodoPago " +
                    "inner join Clientes as Cli on Res.IdCliente = Cli.IdCliente " +
                    "where MP.Nombre like '%efectivo%' " +
                    "and TiPr.Nombre like '%casa%' " +
                    "order by Cli.NombreCompleto";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdBuscarClientes = new SqlCommand(queryBuscarClientes, conectar);
                    SqlDataReader readerBuscarClientes = cmdBuscarClientes.ExecuteReader();
                    while (readerBuscarClientes.Read())
                    {
                        cmbClientes.Items.Add(readerBuscarClientes["NombreCompleto"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbClientes.SelectedIndex != -1 && cmbAño.SelectedIndex != -1)
            {
                llenarDGV();
            }
        }

        private void cmbAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex != -1 && cmbAño.SelectedIndex != -1)
            {
                llenarDGV();
            }
        }

        private void llenarDGV()
        {
            dgvCasas.DataSource = null;
            try
            {
                string queryBuscarClientes =
                    "select Res.NumeroReservacion as [N° Reservación], " +
                    "Res.FechaCreacion as [Fecha Creación], Res.FechaEntrada as [Fecha Entrada], " +
                    "Res.FechaSalida as [Fecha Salida], Res.NumeroPersonas as [N° Personas], " +
                    "Res.MontoTotal as [Monto Total] " +
                    "from Reservaciones as Res " +
                    "inner join Propiedades as Prop on Res.IdPropiedad = Prop.IdPropiedad " +
                    "inner join TiposPropiedad as TiPr on Prop.IdTipoPropiedad = TiPr.IdTipoPropiedad " +
                    "inner join Pagos as Pa on Res.IdReservacion = Pa.IdReservacion " +
                    "inner join MetodosPago as MP on Pa.IdMetodoPago = MP.IdMetodoPago " +
                    "inner join Clientes as Cli on Res.IdCliente = Cli.IdCliente " +
                    "where MP.Nombre like '%efectivo%' " +
                    "and TiPr.Nombre like '%casa%' " +
                    "and Cli.NombreCompleto = @cliente " +
                    "and YEAR(Res.FechaCreacion) = @anio";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(queryBuscarClientes, conectar);
                    cmd.Parameters.AddWithValue("@cliente", cmbClientes.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@anio", Convert.ToInt32(cmbAño.SelectedItem));

                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    dtCompleto = new DataTable();
                    adaptador.Fill(dtCompleto);
                }

                dgvCasas.DataSource = dtCompleto;
                dgvCasas.Enabled = true;

                AplicarEstilosColumnas(dgvCasas);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AplicarEstilosColumnas(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn columna in grid.Columns)
            {
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (grid.Columns["Fecha Creación"] != null)
                grid.Columns["Fecha Creación"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (grid.Columns["Fecha Entrada"] != null)
                grid.Columns["Fecha Entrada"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (grid.Columns["Fecha Salida"] != null)
                grid.Columns["Fecha Salida"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (grid.Columns["Monto Total"] != null)
            {
                grid.Columns["Monto Total"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-HN");
                grid.Columns["Monto Total"].DefaultCellStyle.Format = "C2";
                grid.Columns["Monto Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void CargarAnios()
        {
            cmbAño.Items.Clear();
            try
            {
                string queryAños = @"
            SELECT DISTINCT YEAR(FechaCreacion) AS Anio 
            FROM Reservaciones 
            ORDER BY Anio DESC";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    using (SqlCommand cmd = new SqlCommand(queryAños, conectar))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbAño.Items.Add(reader["Anio"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los años: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}