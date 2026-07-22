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
    public partial class ReservacionesForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");

        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private DataTable tablalocal;

        public ReservacionesForm()
        {
            InitializeComponent();
            ActivarTabNuevo();
            ConfigurarDataGridView(dgvHistorial);
            CargarDatosBD();

            cboPropiedad.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void ConfigurarDataGridView(DataGridView grid)
        {
            System.Drawing.Color naranjaTitulo = System.Drawing.Color.FromArgb(216, 122, 45);

            grid.RowHeadersVisible = false;
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.RowTemplate.Height = 28;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 8, FontStyle.Bold);

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 7, FontStyle.Regular);
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
        }

        private void btnNuevaReservacion_Click(object sender, EventArgs e) => ActivarTabNuevo();
        private void btnHistorialReservaciones_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlReservacion.Visible = true;
            pnlHistorial.Visible = false;
            pnlAccion.Visible = true;

            EstiloTabActivo(btnNuevaReservacion);
            EstiloTabInactivo(btnHistorialReservaciones);
        }
        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlReservacion.Visible = false;
            pnlAccion.Visible = false;

            EstiloTabActivo(btnHistorialReservaciones);
            EstiloTabInactivo(btnNuevaReservacion);
        }

        private void EstiloTabActivo(Button btn)
        {
            btn.BackColor = ColorActivo;
            btn.ForeColor = Color.White;
        }

        private void EstiloTabInactivo(Button btn)
        {
            btn.BackColor = ColorInactivo;
            btn.ForeColor = TextoInactivo;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboPropiedad.SelectedValue = -1;
            txtCliente.Clear();
            dtpEntrada.Value = DateTime.Now;
            dtpSalida.Value = DateTime.Now;
            txtMonto.Clear();
            txtObservaciones.Clear();
        }
        private void CargarDatosBD()
        {
            string query = @"
            SELECT 
                R.NumeroReservacion AS [Número de Reservación],
                P.Codigo AS [Propiedad],
                C.NombreCompleto AS [Arrendatario],
                R.FechaEntrada AS [Fecha de Entrada],
                R.FechaSalida AS [Fecha de Salida],
                R.NumeroPersonas AS [Número de Personas],
                R.MontoTotal AS [Monto Total],
                E.Nombre AS [Estado],
                R.Observaciones AS [Observaciones]
                FROM Reservaciones R
                INNER JOIN Propiedades P ON R.IdPropiedad = P.IdPropiedad
                INNER JOIN EstadosReservacion E ON R.IdEstadoReservacion= E.IdEstadoReservacion
                INNER JOIN Clientes C ON R.IdCliente = C.IdCliente
                ORDER BY R.FechaEntrada";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                        tablalocal = new DataTable();

                        adaptador.Fill(tablalocal);
                        dgvHistorial.DataSource = tablalocal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el historial de reservaciones: " + ex.Message, 
                    "Error de datos", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FiltrarHistorial();
                e.SuppressKeyPress = true;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarHistorial();
        }

        private void FiltrarHistorial()
        {
            if (tablalocal == null) return;

            string filtro = txtBuscar.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(filtro))
            {
                tablalocal.DefaultView.RowFilter = string.Empty;
                return;
            }

            try
            {
                tablalocal.DefaultView.RowFilter =
                    $"Convert(Arrendatario, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Número de Reservación], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert(Propiedad, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert(Observaciones, 'System.String') LIKE '%{filtro}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al filtrar los datos: " + ex.Message, 
                    "Error de filtro", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                );
            }
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHistorial.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim().ToLower();

                switch (estado)
                {
                    case "en curso":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                        break;
                    case "pendiente":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                        break;
                    case "completada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#8F8686");
                        break;
                    case "cancelada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                        break;
                    case "confirmada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#87A96B");
                        break;
                }

                e.CellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            }
        }

        private void ReservacionesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
