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
    public partial class ClientesForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");

        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private DataTable tablalocal;

        public ClientesForm()
        {
            InitializeComponent();
            ActivarTabNuevo();
            CargarDatosBD();
            ConfigurarDataGridView(dgvHistorial);
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
        private void btnNuevoCliente_Click(object sender, EventArgs e) => ActivarTabNuevo();
        private void btnClienteHistorial_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlCliente.Visible = true;
            pnlHistorial.Visible = false;
            pnlAccion.Visible = true;

            EstiloTabActivo(btnNuevoCliente);
            EstiloTabInactivo(btnClienteHistorial);
        }
        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlCliente.Visible = false;
            pnlAccion.Visible = false;

            EstiloTabActivo(btnClienteHistorial);
            EstiloTabInactivo(btnNuevoCliente);
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
            txtNombre.Clear();
            txtIdentidad.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtEmpresa.Clear();
            txtRtn.Clear();
        }

        private void CargarDatosBD()
        {
            string query = @"
            SELECT 
                C.NombreCompleto AS [Nombre Completo],
                C.Identidad AS [Identidad],
                C.Telefono AS [Teléfono],
                C.CorreoElectronico AS [Correo Electrónico],
                C.NombreEmpresa AS [Nombre de Empresa],
                C.RTN AS [RTN de Empresa]
                FROM Clientes C
                ORDER BY C.NombreCompleto";

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
                MessageBox.Show("Error al cargar el historial de clientes: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    $"Convert([Nombre Completo], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert(Identidad, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Nombre de Empresa], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Correo Electrónico], 'System.String') LIKE '%{filtro}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los datos: " + ex.Message, "Error de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
