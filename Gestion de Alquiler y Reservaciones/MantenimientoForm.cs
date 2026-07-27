using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class MantenimientoForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");

        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private DataTable tablalocal;
        private Dictionary<string, string> PropiedadesDisponibles = new Dictionary<string, string>();
        private Dictionary<string, int> TecnicosDic = new Dictionary<string, int>();
        private Dictionary<string, int> TiposDic = new Dictionary<string, int>();
        private int idMantenimientoSeleccionado = -1;
        private bool LimpiandoCampos = false;

        public MantenimientoForm()
        {
            InitializeComponent();
            ConfigurarDataGridView(dgvHistorial);
            ActivarTabNuevo();
            CargarDatosBD();
            AplicarEstilosColumnas(dgvHistorial);

            cboPropiedad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSolicitud.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
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
        private void AplicarEstilosColumnas(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Costo"] != null)
            {
                grid.Columns["Costo"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-HN");
                grid.Columns["Costo"].DefaultCellStyle.Format = "C2";
                grid.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
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
            pnlEditar.Visible = false;
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
                MessageBox.Show(
                    "Error al cargar el historial de solicitudes de mantenimiento: " + ex.Message, 
                    "Error de datos.", 
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
                    $"Convert(Propiedad, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Número de Solicitud], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Técnico Asignado], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Tipo de Mantenimiento], 'System.String') LIKE '%{filtro}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al filtrar los datos: " + ex.Message, 
                    "Error de filtro.", 
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
            LlenarTipoMantenimiento();
            LlenarTecnicoAsignado();
            LlenarPropiedades();

            LlenarCboSolicitud();
            LlenarCmbEstado();
            CambiarEstadoCampos(false);
            ValidarCamposParaGuardar();
        }

        private void LlenarTipoMantenimiento()
        {
            try
            {
                cboTipo.Items.Clear();
                cboTipo.Items.Add("--Seleccionar--");
                TiposDic.Clear();

                string query = "SELECT IdTipoMantenimiento, Nombre FROM TiposMantenimiento";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["Nombre"].ToString();
                            int id = Convert.ToInt32(reader["IdTipoMantenimiento"]);
                            cboTipo.Items.Add(nombre);
                            TiposDic[nombre] = id;
                        }
                    }
                }
                cboTipo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarTecnicoAsignado()
        {
            try
            {
                cboTecnico.Items.Clear();
                cboTecnico.Items.Add("--Seleccionar--");
                TecnicosDic.Clear();

                string query = "SELECT IdEmpleado, NombreCompleto FROM Empleado WHERE IdEmpleado = 6 OR IdEmpleado = 7";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                            string[] partes = reader["NombreCompleto"].ToString().Split(' ');
                            string nombreMostrado = partes[0] + ' ' + partes[2];

                            cboTecnico.Items.Add(nombreMostrado);
                            TecnicosDic[nombreMostrado] = idEmpleado;
                        }
                    }
                }
                cboTecnico.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarPropiedades()
        {
            try
            {
                cboPropiedad.Items.Clear();
                cboPropiedad.Items.Add("--Seleccionar--");
                PropiedadesDisponibles.Clear();

                string queryLlenarPropiedades = @"
                    SELECT P.IdPropiedad, P.Codigo
                    FROM Propiedades P
                    WHERE NOT EXISTS (
                        SELECT 1 FROM Mantenimiento M
                        INNER JOIN EstadosMantenimiento EM ON M.IdEstadoMantenimiento = EM.IdEstadoMantenimiento
                        WHERE M.IdPropiedad = P.IdPropiedad
                          AND EM.Nombre IN ('Pendiente', 'En Proceso')
                    )
                    ORDER BY P.Codigo";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(queryLlenarPropiedades, conectar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string codigo = reader["Codigo"].ToString();
                            string idPropiedad = reader["IdPropiedad"].ToString();
                            cboPropiedad.Items.Add(codigo);
                            PropiedadesDisponibles[codigo] = idPropiedad;
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

        private void btnGuardar_Click(object sender, EventArgs e) 
        {
            if (cboPropiedad.SelectedIndex <= 0 ||
        cboTecnico.SelectedIndex <= 0 ||
        cboTipo.SelectedIndex <= 0 ||
        string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "Los campos obligatorios no deben de estar vacíos.",
                    "Campos vacíos.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de crear esta solicitud?",
                "Crear Solicitud.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            if (CrearSolicitud())
            {
                MessageBox.Show(
                    "Solicitud creada con éxito.",
                    "Éxito.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                LimpiarCampos();
                LlenarPropiedades();
                LlenarCboSolicitud(); 
                CargarDatosBD();
            }
        }

        private bool CrearSolicitud()
        {
            try
            {
                string idPropiedad = PropiedadesDisponibles[cboPropiedad.SelectedItem.ToString()];
                int idTecnico = TecnicosDic[cboTecnico.SelectedItem.ToString()];
                int idTipo = TiposDic[cboTipo.SelectedItem.ToString()];
                string tipoAbrev = cboTipo.SelectedItem.ToString()
                    .StartsWith("Prev", StringComparison.OrdinalIgnoreCase) ? "PRE" : "COR";
                string fechaStr = DateTime.Now.ToString("yyMMdd");

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();

                    string patron = $"MTC-{tipoAbrev}-{fechaStr}%";
                    SqlCommand cmdCount = new SqlCommand(
                        "SELECT COUNT(*) FROM Mantenimiento WHERE NumeroOrden LIKE @patron", conectar);
                    cmdCount.Parameters.AddWithValue("@patron", patron);
                    int consecutivo = (int)cmdCount.ExecuteScalar() + 1;
                    string numeroOrden = $"MTC-{tipoAbrev}-{fechaStr}-{consecutivo:D2}";

                    string queryInsert = @"
                INSERT INTO Mantenimiento
                    (NumeroOrden, IdPropiedad, IdTipoMantenimiento, IdTecnicoAsignado,
                     Descripcion, FechaSolicitud, FechaProgramada, IdEstadoMantenimiento)
                VALUES
                    (@numeroOrden, @idPropiedad, @idTipo, @idTecnico,
                     @descripcion, CAST(GETDATE() AS DATE), @fechaProgramada,
                     (SELECT IdEstadoMantenimiento FROM EstadosMantenimiento WHERE Nombre = 'Pendiente'))";

                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conectar);
                    cmdInsert.Parameters.AddWithValue("@numeroOrden", numeroOrden);
                    cmdInsert.Parameters.AddWithValue("@idPropiedad", idPropiedad);
                    cmdInsert.Parameters.AddWithValue("@idTipo", idTipo);
                    cmdInsert.Parameters.AddWithValue("@idTecnico", idTecnico);
                    cmdInsert.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
                    cmdInsert.Parameters.AddWithValue("@fechaProgramada", dtpProgramada.Value.Date);

                    cmdInsert.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al crear la solicitud: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }

        private void cboPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPropiedad.SelectedIndex == 0)
            {
                lblOPropiedad.Visible = true;
            }
            else
            {
                lblOPropiedad.Visible = false;
            }

            ValidarCamposParaGuardar();
        }

        private void cboTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTecnico.SelectedIndex == 0)
            {
                lblOTecnico.Visible = true;
            }
            else
            {
                lblOTecnico.Visible = false;
            }

            ValidarCamposParaGuardar();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                lblOTipo.Visible = true;
            }
            else
            {
                lblOTipo.Visible = false;
            }

            ValidarCamposParaGuardar();
        }

        private void dtpProgramada_ValueChanged(object sender, EventArgs e)
        {
            if(dtpProgramada.Value.Date < DateTime.Now.Date)
            {
                lblOFecha.Text = "Seleccione una fecha válida.";
                lblOFecha.Visible = true;
            }
            else
            {
                lblOFecha.Visible = false;
            }

            ValidarCamposParaGuardar();
        }

        private void LlenarCboSolicitud()
        {
            try
            {
                cboSolicitud.Items.Clear();
                cboSolicitud.Items.Add("--Seleccionar--");

                string query = @"
            SELECT M.NumeroOrden
            FROM Mantenimiento M
            INNER JOIN EstadosMantenimiento EM ON M.IdEstadoMantenimiento = EM.IdEstadoMantenimiento
            WHERE EM.Nombre <> 'Completado'
            ORDER BY M.NumeroOrden";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cboSolicitud.Items.Add(reader["NumeroOrden"].ToString());
                        }
                    }
                }
                cboSolicitud.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarCmbEstado()
        {
            try
            {
                cmbEstado.Items.Clear();
                string query = "SELECT Nombre FROM EstadosMantenimiento ORDER BY IdEstadoMantenimiento";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbEstado.Items.Add(reader["Nombre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarDatosEnDB()
        {
            try
            {
                string query = @"
                SELECT M.IdMantenimiento, P.Codigo, Emp.NombreCompleto, M.Costo,
                       M.Descripcion, M.FechaConclusion, Est.Nombre
                FROM Mantenimiento AS M
                INNER JOIN Propiedades AS P ON M.IdPropiedad = P.IdPropiedad
                INNER JOIN Empleado AS Emp ON M.IdTecnicoAsignado = Emp.IdEmpleado
                INNER JOIN EstadosMantenimiento AS Est ON M.IdEstadoMantenimiento = Est.IdEstadoMantenimiento
                WHERE M.NumeroOrden = @orden";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@orden", cboSolicitud.SelectedItem.ToString());
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idMantenimientoSeleccionado = Convert.ToInt32(reader["IdMantenimiento"]);
                            txtPropiedadActu.Text = reader["Codigo"].ToString();
                            txtTecnicoActu.Text = reader["NombreCompleto"].ToString();
                            txtCosto.Text = reader["Costo"] == DBNull.Value ? "0" : reader["Costo"].ToString();
                            txtDescripcionActu.Text = reader["Descripcion"].ToString();
                            dtpConclusion.Value = reader["FechaConclusion"] == DBNull.Value
                                ? DateTime.Now
                                : Convert.ToDateTime(reader["FechaConclusion"]);
                            cmbEstado.Text = reader["Nombre"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Algo salió mal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LimpiandoCampos) return;

            if (cboSolicitud.SelectedIndex <= 0)
            {
                btnActualizarSoli.Enabled = false;
                CambiarEstadoCampos(false);
                idMantenimientoSeleccionado = -1;
            }
            else
            {
                BuscarDatosEnDB();
                CambiarEstadoCampos(true);
                btnActualizarSoli.Enabled = true;
            }
        }
        

        private void CambiarEstadoCampos(bool estado)
        {
            txtPropiedadActu.Enabled = estado;
            txtTecnicoActu.Enabled = estado;
            txtCosto.Enabled = estado;
            txtDescripcionActu.Enabled = estado;
            dtpConclusion.Enabled = estado;
            cmbEstado.Enabled = estado;
        }
        private void LimpiarCampos()
        {
            // Crear mantenimiento
            cboPropiedad.SelectedIndex = 0;
            cboTecnico.SelectedIndex = 0;
            cboTipo.SelectedIndex = 0;
            dtpProgramada.ResetText();
            txtDescripcion.Text = string.Empty;

            // Actualizar mantenimiento
            LimpiandoCampos = true;
            txtPropiedadActu.Text = string.Empty;
            txtTecnicoActu.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txtDescripcionActu.Text = string.Empty;
            dtpConclusion.Value = DateTime.Now;
            cmbEstado.SelectedIndex = -1;
            cboSolicitud.SelectedIndex = -1;
            idMantenimientoSeleccionado = -1;
            CambiarEstadoCampos(false);
            btnActualizarSoli.Enabled = false;
            LimpiandoCampos = false;

            ValidarCamposParaGuardar();
        }

        private void btnLimpiarActu_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void ValidarCamposParaGuardar()
        {
            if (lblOPropiedad.Visible == true ||
                lblOTecnico.Visible == true ||
                lblOTipo.Visible == true ||
                lblOFecha.Visible == true)
            {
                btnGuardar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
            }
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            if(txtCosto.Text.Trim() == string.Empty)
            {
                txtCosto.Text = "0";
                txtCosto.SelectionStart = txtCosto.Text.Length;
            }
            else
            {
                if (decimal.Parse(txtCosto.Text) <= 0)
                {
                    lblVCosto.Text = "El valor debe ser un número mayor que 0.";
                    lblVCosto.Visible = true;
                    btnActualizar.Enabled = true;
                }
                else
                {
                    lblVCosto.Visible = false;
                    btnActualizar.Enabled = false;
                }
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite únicamente dígitos numéricos y la tecla de borrado (Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla presionada (no la escribe)
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizarSoli_Click(object sender, EventArgs e)
        {
            if (cboSolicitud.SelectedIndex <= 0 || idMantenimientoSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione una solicitud válida para actualizar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (cmbEstado.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Seleccione un estado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de actualizar esta solicitud?",
                "Actualizar Solicitud.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            try
            {
                string query = @"
                UPDATE Mantenimiento
                SET Costo = @costo,
                    Descripcion = @descripcion,
                    FechaConclusion = @fechaConclusion,
                    IdEstadoMantenimiento = (SELECT IdEstadoMantenimiento FROM EstadosMantenimiento WHERE Nombre = @estado)
                WHERE IdMantenimiento = @id";

                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmd = new SqlCommand(query, conectar);
                    cmd.Parameters.AddWithValue("@costo", decimal.Parse(txtCosto.Text));
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcionActu.Text.Trim());
                    cmd.Parameters.AddWithValue("@fechaConclusion", dtpConclusion.Value.Date);
                    cmd.Parameters.AddWithValue("@estado", cmbEstado.Text);
                    cmd.Parameters.AddWithValue("@id", idMantenimientoSeleccionado);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Solicitud actualizada con éxito.",
                    "Éxito.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarCampos();
                LlenarCboSolicitud();
                LlenarPropiedades();
                CargarDatosBD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar la solicitud: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}