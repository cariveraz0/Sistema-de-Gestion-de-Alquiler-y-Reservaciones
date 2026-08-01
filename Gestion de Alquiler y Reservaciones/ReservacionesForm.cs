using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class ReservacionesForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");

        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private DataTable tablalocal;
        private Dictionary<string, PropiedadInfo> PropiedadesReservacion = new Dictionary<string, PropiedadInfo>();
        private Dictionary<string, int> ClientesDic = new Dictionary<string, int>();  
        private int IdReservacionSeleccionada = -1;
        private bool LimpiandoCamposActu = false;

        public class PropiedadInfo
        {
            public string IdPropiedad { get; set; }
            public string TipoPropiedad { get; set; }
            public decimal PrecioAlquiler { get; set; }
        }

        public ReservacionesForm()
        {
            InitializeComponent();
            ActivarTabNuevo();
            ConfigurarDataGridView(dgvHistorial);
            CargarDatosBD();
            AplicarEstilosColumnas(dgvHistorial);

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
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
        }
        private void AplicarEstilosColumnas(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Monto Total"] != null)
            {
                grid.Columns["Monto Total"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-HN");
                grid.Columns["Monto Total"].DefaultCellStyle.Format = "C2";
                grid.Columns["Monto Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnNuevaReservacion_Click(object sender, EventArgs e) => ActivarTabNuevo();
        private void btnActualizarReservacion_Click(object sender, EventArgs e) => ActivarTabEditar();
        private void btnHistorialReservaciones_Click(object sender, EventArgs e) => ActivarTabHistorial();


        private void ActivarTabNuevo()
        {
            pnlReservacion.Visible = true;
            pnlHistorial.Visible = false;
            pnlEditar.Visible = false;
            pnlAccion.Visible = true;
            pnlActualizar.Visible = false;

            EstiloTabActivo(btnNuevaReservacion);
            EstiloTabInactivo(btnActualizarReservacion);
            EstiloTabInactivo(btnHistorialReservaciones);
        }
        private void ActivarTabEditar()
        {
            pnlEditar.Visible = true;
            pnlHistorial.Visible = false;
            pnlReservacion.Visible = false;
            pnlAccion.Visible = false;
            pnlActualizar.Visible = true;

            EstiloTabActivo(btnActualizarReservacion);
            EstiloTabInactivo(btnNuevaReservacion);
            EstiloTabInactivo(btnHistorialReservaciones);
        }
        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlReservacion.Visible = false;
            pnlEditar.Visible = false;
            pnlAccion.Visible = false;
            pnlActualizar.Visible = false;

            EstiloTabActivo(btnHistorialReservaciones);
            EstiloTabInactivo(btnActualizarReservacion);
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
            LimpiarControles();
        }
        private void CargarDatosBD()
        {
            string query = @"
            SELECT 
                R.NumeroReservacion AS [Número de Reservación],
                P.Codigo AS [Propiedad],
                C.NombreCompleto AS [Arrendatario],
                FORMAT(R.FechaEntrada, 'dd/MM/yyyy') + ' al ' + FORMAT(R.FechaSalida, 'dd/MM/yyyy') AS [Período],
                R.NumeroPersonas AS [Cant. Personas],
                R.MontoTotal AS [Monto Total],
                E.Nombre AS [Estado],
                R.Observaciones AS [Observaciones]
            FROM Reservaciones R
            INNER JOIN Propiedades P ON R.IdPropiedad = P.IdPropiedad
            INNER JOIN EstadosReservacion E ON R.IdEstadoReservacion = E.IdEstadoReservacion
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

        private void LimpiarControles()
        {
            cboPropiedad.SelectedIndex = 0;
            txtCliente.Clear();
            dtpEntrada.ResetText();
            dtpSalida.ResetText();
            txtMonto.Clear();
            txtPersonas.Clear();
            txtObservaciones.Clear();

            validarAntesDeGuardar();
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHistorial.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim().ToLower();

                switch (estado)
                {
                    case "en curso":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#0c6b22");
                        break;
                    case "pendiente":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#E6B340");
                        break;
                    case "completada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#9E8A73");
                        break;
                    case "cancelada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#C84F24");
                        break;
                    case "confirmada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#d67a31");
                        break;
                }

                e.CellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            }
        }

        private void ReservacionesForm_Load(object sender, EventArgs e)
        {
            ObtenerPropiedades();
            CargarClientes();
            LlenarCboReservacion();
            LlenarCboEstadoReservacion();
            CambiarEstadoCamposActu(false);
            validarAntesDeGuardar();
            cboReservacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvHistorial.Columns["Observaciones"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            validarAntesDeActualizar();
        }

        private void ObtenerPropiedades()
        {
            try
            {
                cboPropiedad.Items.Clear();
                cboPropiedad.Items.Add("--Seleccionar--");
                PropiedadesReservacion.Clear();

                string query = @"
                    SELECT P.IdPropiedad, P.Codigo, T.Nombre AS TipoPropiedad, ISNULL(P.PrecioAlquiler, 0) AS PrecioAlquiler
                    FROM Propiedades P
                    INNER JOIN TiposPropiedad T ON P.IdTipoPropiedad = T.IdTipoPropiedad
                    WHERE T.Nombre IN ('Auditorio', 'Sala de Juntas', 'Casa de Playa/Montaña')
                    ORDER BY P.Codigo";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string codigo = reader["Codigo"].ToString();
                            cboPropiedad.Items.Add(codigo);

                            PropiedadesReservacion[codigo] = new PropiedadInfo
                            {
                                IdPropiedad = reader["IdPropiedad"].ToString(),
                                TipoPropiedad = reader["TipoPropiedad"].ToString(),
                                PrecioAlquiler = Convert.ToDecimal(reader["PrecioAlquiler"])
                            };
                        }
                    }
                }
                cboPropiedad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPropiedad.SelectedIndex == 0)
            {
                lblVPropiedad.Text = "Debe seleccionar una opcion.";
                lblVPropiedad.Visible = true;
                txtMonto.Clear();
            }
            else
            {
                lblVPropiedad.Visible = false;
            }
            ValidarFechasYMonto();
        }

        private void CargarClientes()
        {
            try
            {
                ClientesDic.Clear();
                string query = "SELECT IdCliente, NombreCompleto FROM Clientes ORDER BY NombreCompleto ASC";

                var sugerencias = new AutoCompleteStringCollection();
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["NombreCompleto"].ToString();
                            int idCliente = Convert.ToInt32(reader["IdCliente"]);
                            sugerencias.Add(nombre);
                            ClientesDic[nombre] = idCliente;
                        }
                    }
                    txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtCliente.AutoCompleteCustomSource = sugerencias;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text == string.Empty || !ClientesDic.ContainsKey(txtCliente.Text))
            {
                lblVCliente.Text = "Debe seleccionar un cliente válido.";
                lblVCliente.Visible = true;
            }
            else
            {
                lblVCliente.Visible = false;
            }
            validarAntesDeGuardar();
        }

        private void validarAntesDeGuardar()
        {
            if(lblVPropiedad.Visible == true ||
                lblVCliente.Visible == true ||
                lblVFechaEntrada.Visible == true ||
                lblVFechaSalida.Visible == true ||
                lblVDisponibilidad.Visible == true)
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
            ValidarFechasYMonto();
        }

        private void dtpSalida_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechasYMonto();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de crear esta reservacion?",
                "Guardar reservacion.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            if (GuardarReservacion())
            {
                MessageBox.Show(
                    "Reservación creada éxitosamente.",
                    "Éxito.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                LimpiarControles();
                CargarDatosBD();
                LlenarCboReservacion();
            }
        }

        private bool GuardarReservacion()
        {
            try
            {
                if (!VerificarDisponibilidad())
                {
                    MessageBox.Show(
                        "La propiedad seleccionada ya tiene una reservación en esas fechas.",
                        "Fechas no disponibles.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return false;
                }

                string idPropiedad = PropiedadesReservacion[cboPropiedad.SelectedItem.ToString()].IdPropiedad;
                int idCliente = ClientesDic[txtCliente.Text];
                string propiedadLimpia = idPropiedad.Replace("-", "");
                string fechaEntradaStr = dtpEntrada.Value.ToString("yyMMdd");

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    string patron = $"RES-{propiedadLimpia}-{fechaEntradaStr}%";
                    SqlCommand cmdCount = new SqlCommand(
                        "SELECT COUNT(*) FROM Reservaciones WHERE NumeroReservacion LIKE @patron", conectar);
                    cmdCount.Parameters.AddWithValue("@patron", patron);
                    int consecutivo = (int)cmdCount.ExecuteScalar() + 1;
                    string numeroReservacion = consecutivo == 1
                        ? $"RES-{propiedadLimpia}-{fechaEntradaStr}"
                        : $"RES-{propiedadLimpia}-{fechaEntradaStr}";

                    string queryInsert = @"
                INSERT INTO Reservaciones
                    (NumeroReservacion, IdPropiedad, IdCliente, FechaEntrada, FechaSalida,
                     NumeroPersonas, MontoTotal, IdEstadoReservacion, Observaciones)
                VALUES
                    (@numero, @idPropiedad, @idCliente, @fechaEntrada, @fechaSalida,
                     @personas, @monto,
                     (SELECT IdEstadoReservacion FROM EstadosReservacion WHERE Nombre = 'Pendiente'),
                     @observaciones)";

                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conectar);
                    cmdInsert.Parameters.AddWithValue("@numero", numeroReservacion);
                    cmdInsert.Parameters.AddWithValue("@idPropiedad", idPropiedad);
                    cmdInsert.Parameters.AddWithValue("@idCliente", idCliente);
                    cmdInsert.Parameters.AddWithValue("@fechaEntrada", dtpEntrada.Value);
                    cmdInsert.Parameters.AddWithValue("@fechaSalida", dtpSalida.Value);
                    cmdInsert.Parameters.AddWithValue("@monto", decimal.Parse(txtMonto.Text));
                    cmdInsert.Parameters.AddWithValue("@personas", decimal.Parse(txtPersonas.Text));
                    cmdInsert.Parameters.AddWithValue("@observaciones",
                        string.IsNullOrWhiteSpace(txtObservaciones.Text) ? (object)DBNull.Value : txtObservaciones.Text.Trim());

                    cmdInsert.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la reservación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void LlenarCboReservacion()
        {
            try
            {
                cboReservacion.Items.Clear();
                cboReservacion.Items.Add("--Seleccionar--");

                string query = @"
            SELECT R.NumeroReservacion
            FROM Reservaciones R
            INNER JOIN EstadosReservacion E ON R.IdEstadoReservacion = E.IdEstadoReservacion
            WHERE E.Nombre IN ('Pendiente', 'Confirmada', 'En Curso')
            ORDER BY R.NumeroReservacion";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cboReservacion.Items.Add(reader["NumeroReservacion"].ToString());
                        }
                    }
                }
                cboReservacion.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarCboEstadoReservacion()
        {
            try
            {
                cboEstado.Items.Clear();
                string query = "SELECT Nombre FROM EstadosReservacion ORDER BY IdEstadoReservacion";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cboEstado.Items.Add(reader["Nombre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarReservacionEnDB()
        {
            try
            {
                string query = @"
            SELECT R.IdReservacion, P.Codigo, C.NombreCompleto, R.FechaEntrada, R.FechaSalida, R.NumeroPersonas,
                   R.MontoTotal, R.Observaciones, E.Nombre
            FROM Reservaciones R
            INNER JOIN Propiedades P ON R.IdPropiedad = P.IdPropiedad
            INNER JOIN Clientes C ON R.IdCliente = C.IdCliente
            INNER JOIN EstadosReservacion E ON R.IdEstadoReservacion = E.IdEstadoReservacion
            WHERE R.NumeroReservacion = @numero";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@numero", cboReservacion.SelectedItem.ToString());
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IdReservacionSeleccionada = Convert.ToInt32(reader["IdReservacion"]);
                            txtPropiedadActu.Text = reader["Codigo"].ToString();
                            txtClienteActu.Text = reader["NombreCompleto"].ToString();
                            txtFechaEntrada.Text = Convert.ToDateTime(reader["FechaEntrada"]).ToString("dd/MM/yyyy HH:mm");
                            txtFechaSalida.Text = Convert.ToDateTime(reader["FechaSalida"]).ToString("dd/MM/yyyy HH:mm");
                            txtMontoPagarActu.Text = reader["MontoTotal"] == DBNull.Value ? "0" : reader["MontoTotal"].ToString();
                            txtPersonasActu.Text = reader["NumeroPersonas"] == DBNull.Value ? "0" : reader["NumeroPersonas"].ToString();
                            txtObservacionesActu.Text = reader["Observaciones"] == DBNull.Value ? string.Empty : reader["Observaciones"].ToString();
                            cboEstado.Text = reader["Nombre"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboReservacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LimpiandoCamposActu) return;

            if (cboReservacion.SelectedIndex == 0)
            {
                btnActualizar.Enabled = false;
                CambiarEstadoCamposActu(false);
                IdReservacionSeleccionada = -1;
                lblVReservacion.Text = "Seleccione una reservación.";
                lblVReservacion.Visible = true;
            }
            else
            {
                BuscarReservacionEnDB();
                CambiarEstadoCamposActu(true);
                btnActualizar.Enabled = true;
                lblVReservacion.Visible = false;
            }

            validarAntesDeActualizar();
        }
        private void CambiarEstadoCamposActu(bool estado)
        {
            txtObservacionesActu.Enabled = estado;
            cboEstado.Enabled = estado;
        }
        private void LimpiarCamposActu()
        {
            LimpiandoCamposActu = true;
            txtPropiedadActu.Clear();
            txtClienteActu.Clear();
            txtFechaEntrada.Clear();
            txtFechaSalida.Clear();
            txtMontoPagarActu.Clear();
            txtPersonasActu.Clear();
            txtObservacionesActu.Clear();
            cboEstado.SelectedIndex = 0;
            cboReservacion.SelectedIndex = 0;
            IdReservacionSeleccionada = -1;
            CambiarEstadoCamposActu(false);
            btnActualizar.Enabled = false;
            LimpiandoCamposActu = false;
        }

        private void btnLimpiarActu_Click(object sender, EventArgs e)
        {
            LimpiarCamposActu();
            validarAntesDeActualizar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cboReservacion.SelectedIndex <= 0 || IdReservacionSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una reservación válida para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboEstado.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de actualizar esta reservación?",
                "Actualizar Reservación.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            try
            {
                string query = @"
            UPDATE Reservaciones
            SET Observaciones = @observaciones,
                IdEstadoReservacion = (SELECT IdEstadoReservacion FROM EstadosReservacion WHERE Nombre = @estado)
            WHERE IdReservacion = @id";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@observaciones",
                        string.IsNullOrWhiteSpace(txtObservacionesActu.Text) ? (object)DBNull.Value : txtObservacionesActu.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", cboEstado.Text);
                    cmd.Parameters.AddWithValue("@id", IdReservacionSeleccionada);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Reservación actualizada con éxito.", "Éxito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCamposActu();
                LlenarCboReservacion();
                CargarDatosBD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la reservación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool VerificarDisponibilidad()
        {
            if (cboPropiedad.SelectedIndex <= 0) return true; // aún no hay propiedad seleccionada

            try
            {
                string idPropiedad = PropiedadesReservacion[cboPropiedad.SelectedItem.ToString()].IdPropiedad;

                string query = @"
                SELECT COUNT(*) 
                FROM Reservaciones R
                INNER JOIN EstadosReservacion E ON R.IdEstadoReservacion = E.IdEstadoReservacion
                WHERE R.IdPropiedad = @idPropiedad
                  AND E.Nombre <> 'Cancelada'
                  AND R.FechaEntrada < @fechaSalida
                  AND R.FechaSalida > @fechaEntrada";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@idPropiedad", idPropiedad);
                    cmd.Parameters.AddWithValue("@fechaEntrada", dtpEntrada.Value);
                    cmd.Parameters.AddWithValue("@fechaSalida", dtpSalida.Value);
                    int conflictos = (int)cmd.ExecuteScalar();
                    return conflictos == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void validarAntesDeActualizar()
        {
            if (lblVReservacion.Visible == true)
            {
                btnActualizar.Enabled = false;
            }
            else
            {
                btnActualizar.Enabled = true;
            }
        }

        private void ValidarFechasYMonto()
        {
            bool hayError = false;

            if (dtpEntrada.Value < DateTime.Now)
            {
                lblVFechaEntrada.Text = "La entrada no puede ser en el pasado.";
                lblVFechaEntrada.Visible = true;
                hayError = true;
            }
            else
            {
                lblVFechaEntrada.Visible = false;
            }

            if (dtpSalida.Value <= dtpEntrada.Value)
            {
                lblVFechaSalida.Text = "La salida debe ser posterior a la entrada.";
                lblVFechaSalida.Visible = true;
                hayError = true;
            }
            else
            {
                lblVFechaSalida.Visible = false;
            }

            if (cboPropiedad.SelectedIndex > 0 && !hayError)
            {
                string codigo = cboPropiedad.SelectedItem.ToString();
                var info = PropiedadesReservacion[codigo];
                TimeSpan diferencia = dtpSalida.Value - dtpEntrada.Value;
                decimal montoFinal = 0;

                if (info.TipoPropiedad == "Auditorio" || info.TipoPropiedad == "Sala de Juntas")
                {
                    if (dtpEntrada.Value.Date != dtpSalida.Value.Date)
                    {
                        lblVFechaSalida.Text = "Los eventos deben iniciar y terminar el mismo día.";
                        lblVFechaSalida.Visible = true;
                        hayError = true;
                    }
                    else
                    {
                        decimal horas = (decimal)Math.Ceiling(diferencia.TotalHours);
                        if (horas == 0) horas = 1;
                        montoFinal = horas * info.PrecioAlquiler;
                    }
                }
                else if (info.TipoPropiedad == "Casa de Playa/Montaña")
                {
                    int dias = (int)Math.Ceiling(diferencia.TotalDays);
                    if (dias == 0) dias = 1;
                    montoFinal = dias * info.PrecioAlquiler;
                }

                if (!hayError)
                {
                    txtMonto.Text = montoFinal.ToString("F2");
                }
                else
                {
                    txtMonto.Clear();
                }
            }
            else
            {
                txtMonto.Clear();
            }

            if (!hayError && cboPropiedad.SelectedIndex > 0)
            {
                if (!VerificarDisponibilidad())
                {
                    lblVDisponibilidad.Text = "La propiedad ya está reservada en ese horario.";
                    lblVDisponibilidad.Visible = true;
                }
                else
                {
                    lblVDisponibilidad.Visible = false;
                }
            }
            else
            {
                lblVDisponibilidad.Visible = false;
            }

            validarAntesDeGuardar();
        }

        private void txtPersonas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
