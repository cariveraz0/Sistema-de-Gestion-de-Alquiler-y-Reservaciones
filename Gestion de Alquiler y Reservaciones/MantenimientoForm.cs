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
    public partial class MantenimientoForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");

        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private DataTable tablalocal;

        public MantenimientoForm()
        {
            InitializeComponent();
            ConfigurarDataGridView(dgvHistorial);
            ActivarTabNuevo();
            CargarDatosBD();

            cboPropiedad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPropiedadActu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSolicitud.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTecnicoActu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
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
        private void btnSolicitud_Click(object sender, EventArgs e) => ActivarTabNuevo();
        private void btnActualizar_Click(object sender, EventArgs e) => ActivarTabEditar();
        private void btnHistorial_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlNueva.Visible = true;
            pnlHistorial.Visible = false;
            pnlEditar.Visible = false;
            pnlAccion.Visible = true;
            pnlActualizar.Visible = false;

            EstiloTabActivo(btnSolicitud);
            EstiloTabInactivo(btnActualizar);
            EstiloTabInactivo(btnHistorial);
        }
        private void ActivarTabEditar()
        {
            pnlEditar.Visible = true;
            pnlHistorial.Visible = false;
            pnlNueva.Visible = false;
            pnlAccion.Visible = false;
            pnlActualizar.Visible = true;

            EstiloTabActivo(btnActualizar);
            EstiloTabInactivo(btnSolicitud);
            EstiloTabInactivo(btnHistorial);

        }
        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlNueva.Visible = false;
            pnlEditar.Visible= false;
            pnlAccion.Visible = false;
            pnlActualizar.Visible = false;

            EstiloTabActivo(btnHistorial);
            EstiloTabInactivo(btnActualizar);
            EstiloTabInactivo(btnSolicitud);
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
                M.NumeroOrden AS [Número de Solicitud],
                P.Codigo AS [Propiedad],
                T.Nombre AS [Tipo de Mantenimiento],
                E.NombreCompleto AS [Técnico Asignado],
                M.Descripcion AS [Descripción],
                M.FechaProgramada AS [Fecha Programada],
                M.FechaConclusion AS [Fecha de Conclusión],
                M.Costo,
                EM.Nombre AS [Estado]
                FROM Mantenimiento M
                INNER JOIN Propiedades P ON M.IdPropiedad = P.IdPropiedad
                INNER JOIN EstadosMantenimiento EM ON M.IdEstadoMantenimiento = EM.IdEstadoMantenimiento
                INNER JOIN TiposMantenimiento T ON M.IdTipoMantenimiento = T.IdTipoMantenimiento
                INNER JOIN Empleado E ON M.IdTecnicoAsignado = E.IdEmpleado";

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
                MessageBox.Show("Error al cargar el historial de solicitudes de mantenimiento: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    $"Convert(Propiedad, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Número de Solicitud], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Técnico Asignado], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Tipo de Mantenimiento], 'System.String') LIKE '%{filtro}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los datos: " + ex.Message, "Error de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHistorial.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim().ToLower();

                switch (estado)
                {
                    case "en proceso":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                        break;
                    case "pendiente":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                        break;
                    case "completado":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#8F8686");
                        break;
                    case "cancelado":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                        break;
                }

                e.CellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            }
        }

        private void MantenimientoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
