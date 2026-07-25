using System;
using System.Data;
using System.Drawing;
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
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
            limpiarControles();
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

        private void limpiarControles()
        {
            cboPropiedad.SelectedIndex = 0;
            txtCliente.Clear();
            dtpEntrada.ResetText();
            dtpSalida.ResetText();
            txtMonto.Clear();
            txtObservaciones.Clear();

            validarParaGuardar();
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
            obtenerPropiedades();
            cargarClientes();
            validarParaGuardar();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite únicamente dígitos numéricos y la tecla de borrado (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada (no la escribe)
            }
        }

        private void obtenerPropiedades()
        {
            try
            {
                string queryObtenerPropiedades = "select * from Propiedades where Codigo like '%Apartamento%' or Codigo like '%Casa%' or Codigo like '%Sala%' order by Codigo asc";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdObtenerPropiedades = new SqlCommand(queryObtenerPropiedades, conectar);
                    SqlDataReader readerObtenerPropiedades = cmdObtenerPropiedades.ExecuteReader();
                    while (readerObtenerPropiedades.Read())
                    {
                        cboPropiedad.Items.Add(readerObtenerPropiedades["Codigo"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algo salió mal.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cboPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPropiedad.SelectedIndex == 0)
            {
                lblVPropiedad.Text = "Debe seleccionar una opcion.";
                lblVPropiedad.Visible = true;
            }
            else
            {
                lblVPropiedad.Visible = false;
            }
            validarParaGuardar();
        }

        private void cargarClientes()
        {
            try
            {
                string queryCargarClientes = "SELECT * from Clientes order by NombreCompleto asc;";

                var sugerencias = new AutoCompleteStringCollection();
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    SqlCommand cmdCargarClientes = new SqlCommand(queryCargarClientes, conexion);
                    SqlDataReader readerCargarClientes = cmdCargarClientes.ExecuteReader();
                    while(readerCargarClientes.Read())
                    {
                        sugerencias.Add(readerCargarClientes["NombreCompleto"].ToString());
                    }
                    txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtCliente.AutoCompleteCustomSource = sugerencias;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algo salió mal.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text == string.Empty || txtCliente.Text.Length < 7)
            {
                lblVCliente.Text = "Debe seleccionar un cliente.";
                lblVCliente.Visible = true;
            }
            else
            {
                lblVCliente.Visible = false;
            }
            validarParaGuardar();
        }

        private void validarParaGuardar()
        {
            if(lblVPropiedad.Visible == true ||
                lblVCliente.Visible == true ||
                lblVFechaEntrada.Visible == true ||
                lblVFechaSalida.Visible == true ||
                lblVMonto.Visible == true)
            {
                btnGuardar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
            }
        }

        private void dtpEntrada_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEntrada.Value.Date < DateTime.Now.Date)
            {
                lblVFechaEntrada.Text = "La fecha de entrada no debe ser menor a la fecha actual.";
                lblVFechaEntrada.Visible = true;
            }
            else
            {
                lblVFechaEntrada.Visible = false;
            }
            validarParaGuardar();
        }

        private void dtpSalida_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSalida.Value.Date < dtpEntrada.Value.Date)
            {
                lblVFechaSalida.Text = "La fecha de salida no debe ser menor a la fecha de entrada.";
                lblVFechaSalida.Visible = true;
            }
            else
            {
                lblVFechaSalida.Visible = false;
            }
            validarParaGuardar();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (txtMonto.Text.Trim() == string.Empty)
            {
                txtMonto.Text = "0";
                txtMonto.SelectionStart = txtMonto.Text.Length;
            }
            else
            {
                if (decimal.Parse(txtMonto.Text) <= 0)
                {
                    lblVMonto.Text = "El valor debe ser un número mayor que 0.";
                    lblVMonto.Visible = true;
                    lblVMonto.Enabled = true;
                }
                else
                {
                    lblVMonto.Visible = false;
                }
            }
            validarParaGuardar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de crear esta reservacion?",
                "Guardar reservacion.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                //Esto estará aqui por mientras se termina la funcion de guardar
                MessageBox.Show(
                    "Reservación creada éxitosamente.",
                    "Éxito.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                limpiarControles();
            }
        }

        private void guardarReservacion()
        {

        }
    }
}
