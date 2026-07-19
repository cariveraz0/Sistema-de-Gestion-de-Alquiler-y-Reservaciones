using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class PagosForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");

        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private DataTable tablalocal;

        public PagosForm()
        {
            InitializeComponent();
            ActivarTabNuevo();
            ConfigurarDataGridView(dgvHistorial);
            CargarDatosBD();
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
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
        }
        private void btnPagos_Click(object sender, EventArgs e) => ActivarTabNuevo();
        private void btnHistorial_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlPagos.Visible = true;
            pnlHistorial.Visible = false;
            pnlAccion.Visible = true;
            pnlPagodeCuota.Visible = false;

            EstiloTabActivo(btnPagos);
            EstiloTabInactivo(btnHistorial);
        }
        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlPagos.Visible = false;
            pnlAccion.Visible = false;
            pnlPagodeCuota.Visible = false;

            EstiloTabActivo(btnHistorial);
            EstiloTabInactivo(btnPagos);
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
        private void CargarDatosBD()
        {
            string query = @"
            SELECT
                    pg.NumeroRecibo AS [Número de Recibo],
                    pg.FechaPago AS [Fecha de Pago],
                    cl.NombreCompleto AS Cliente,
                    prop.Codigo         AS Propiedad,
                    'Cuota'            AS Tipo,
                    c.NumeroContrato + ' - Cuota ' + CAST(cc.NumeroCuota AS VARCHAR(3)) AS Referencia,
                    pg.Monto,
                    mp.Nombre          AS Metodo
                FROM Pagos pg
                INNER JOIN CuotasContrato cc ON cc.IdCuota = pg.IdCuota
                INNER JOIN Contratos c       ON c.IdContrato = cc.IdContrato
                INNER JOIN Clientes cl       ON cl.IdCliente = c.IdArrendatario
                INNER JOIN Propiedades prop  ON prop.IdPropiedad = c.IdPropiedad
                INNER JOIN MetodosPago mp    ON mp.IdMetodoPago = pg.IdMetodoPago
                WHERE pg.IdCuota IS NOT NULL
                UNION ALL
                SELECT
                    pg.NumeroRecibo,
                    pg.FechaPago,
                    cl.NombreCompleto AS Cliente,
                    prop.Codigo         AS Propiedad,
                    'Reservación'      AS Tipo,
                    r.NumeroReservacion AS Referencia,
                    pg.Monto,
                    mp.Nombre          AS Metodo
                FROM Pagos pg
                INNER JOIN Reservaciones r  ON r.IdReservacion = pg.IdReservacion
                INNER JOIN Clientes cl      ON cl.IdCliente = r.IdCliente
                INNER JOIN Propiedades prop ON prop.IdPropiedad = r.IdPropiedad
                INNER JOIN MetodosPago mp   ON mp.IdMetodoPago = pg.IdMetodoPago
                WHERE pg.IdReservacion IS NOT NULL
                ORDER BY FechaPago DESC;";

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
                MessageBox.Show("Error al cargar el historial de pagos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    $"Convert(Cliente, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Número de Recibo], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert(Propiedad, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert(Tipo, 'System.String') LIKE '%{filtro}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los datos: " + ex.Message, "Error de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
