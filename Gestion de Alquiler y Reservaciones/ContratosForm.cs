using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Humanizer;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using ProyectoInversion;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class ContratosForm : Form
    {
        private static readonly Color ColorActivo   = ColorTranslator.FromHtml("#C84F24");
        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private class PropiedadDisponible
        {
            public string IdPropiedad { get; set; }
            public string Codigo { get; set; }
            public string Numero { get; set; }
            public override string ToString() => Numero;
        }

        private DataTable _tablaHistorial;

        private Button _tipoActivo = null;

        AutoCompleteStringCollection sugerencias = new AutoCompleteStringCollection();

        public ContratosForm()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDatosDesdeBD();
            ActivarTabNuevo();

            cmbSeleccionCasa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeleccionSala.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCantidadPersonasS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNumeroApartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNumeroLocal.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarPropiedadesDisponibles();
        }

        private void ContratosForm_Load(object sender, EventArgs e)
        {
            if (cmbSeleccionSala != null)
            {
                cmbSeleccionSala.SelectedIndexChanged += (s, args) =>
                {
                    if (cmbSeleccionSala.Text == "Auditorio Los Zorzales")
                        cmbCantidadPersonasS.Text = "200";
                    else
                        cmbCantidadPersonasS.Text = "100";
                };
            }

            CargarArrendatarios();
        }

        private void btnTabNuevo_Click(object sender, EventArgs e)    => ActivarTabNuevo();
        private void btnTabEditar_Click(object sender, EventArgs e)
        {
            ActivarTabEditar();
            CargarContratosParaEdicion();
        }
        private void btnTabHistorial_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlNuevoContrato.Visible = true;
            pnlEditar.Visible = false;
            pnlHistorial.Visible = false;
            pnlAccion.Visible = true;
            pnlActu.Visible = false;

            EstiloTabActivo(btnTabNuevo);
            EstiloTabInactivo(btnTabEditar);
            EstiloTabInactivo(btnTabHistorial);
        }
        private void ActivarTabEditar()
        {
            pnlEditar.Visible = true;
            pnlHistorial.Visible = false;
            pnlNuevoContrato.Visible = false;
            pnlAccion.Visible = false;
            pnlActu.Visible = true;

            EstiloTabActivo(btnTabEditar);
            EstiloTabInactivo(btnTabNuevo);
            EstiloTabInactivo(btnTabHistorial);
        }

        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlEditar.Visible = false;
            pnlNuevoContrato.Visible = false;
            pnlAccion.Visible = false;
            pnlActu.Visible = false;

            EstiloTabActivo(btnTabHistorial);
            EstiloTabInactivo(btnTabNuevo);
            EstiloTabInactivo(btnTabEditar);
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

        // ═══════════════════════════════════════════════════════════
        //  Selector de tipo de propiedad
        // ═══════════════════════════════════════════════════════════
        private void btnTipoApartamento_Click(object sender, EventArgs e) => MostrarFormulario(pnlFormApartamento, btnTipoApartamento);
        private void btnTipoLocal_Click(object sender, EventArgs e)       => MostrarFormulario(pnlFormLocal,       btnTipoLocal);
        private void btnTipoCasa_Click(object sender, EventArgs e)        => MostrarFormulario(pnlFormCasa,        btnTipoCasa);
        private void btnTipoSala_Click(object sender, EventArgs e)        => MostrarFormulario(pnlFormSala,        btnTipoSala);

        private void MostrarFormulario(Panel panelObjetivo, Button btnOrigen)
        {
            // Ocultar todos los sub-formularios
            pnlFormApartamento.Visible = false;
            pnlFormLocal.Visible       = false;
            pnlFormCasa.Visible        = false;
            pnlFormSala.Visible        = false;

            // Restablecer estilo de todos los botones de tipo
            ResetearEstiloTipo(btnTipoApartamento);
            ResetearEstiloTipo(btnTipoLocal);
            ResetearEstiloTipo(btnTipoCasa);
            ResetearEstiloTipo(btnTipoSala);

            // Mostrar sólo el formulario seleccionado
            panelObjetivo.Visible = true;
            panelObjetivo.BringToFront();

            // Marcar botón activo
            btnOrigen.BackColor = ColorActivo;
            btnOrigen.ForeColor = Color.White;
            btnOrigen.FlatAppearance.BorderColor = ColorActivo;
            _tipoActivo = btnOrigen;
        }

        private void ResetearEstiloTipo(Button btn)
        {
            btn.BackColor = Color.FromArgb(250, 250, 250);
            btn.ForeColor = Color.FromArgb(68, 68, 68);
            btn.FlatAppearance.BorderColor = Color.FromArgb(224, 219, 210);
        }

        // ═══════════════════════════════════════════════════════════
        //  Botones de acción (Nuevo Contrato)
        // ═══════════════════════════════════════════════════════════
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPanelControles(pnlFormApartamento);
            LimpiarPanelControles(pnlFormLocal);
            LimpiarPanelControles(pnlFormCasa);
            LimpiarPanelControles(pnlFormSala);

            ValidarParaGenerar();
        }

        private void LimpiarPanelControles(Panel panel)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox txt) txt.Clear();
                if (c is ComboBox cmb) cmb.SelectedIndex = 0;
                if (c is DateTimePicker dtp) dtp.ResetText();
            }
        }
        private void CargarDatosDesdeBD()
        {
            string consulta = @"
        SELECT 
            c.NumeroContrato AS [Numero Contrato],
            cl.NombreCompleto AS Arrendatario,
            p.Codigo AS [Nombre Propiedad],
            c.FechaInicio AS [Fecha Inicio],
            c.FechaFin AS [Fecha Final],
            c.MontoMensual AS Monto,
            ec.Nombre AS Estado
        FROM Contratos c
        INNER JOIN Clientes cl ON c.IdArrendatario = cl.IdCliente
        INNER JOIN Propiedades p ON c.IdPropiedad = p.IdPropiedad
        INNER JOIN EstadosContrato ec ON c.IdEstadoContrato = ec.IdEstadoContrato
        ORDER BY c.FechaFin DESC;";

            try
            {
                // Utilizamos tu clase de conexión centralizada
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                        _tablaHistorial.Clear();
                        adaptador.Fill(_tablaHistorial);

                        // Limpiamos cualquier filtro previo
                        _tablaHistorial.DefaultView.RowFilter = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el historial de contratos: " + ex.Message, 
                    "Error de datos.", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  Historial — DataGridView
        // ═══════════════════════════════════════════════════════════
        private void ConfigurarDataGridView()
        {
            System.Drawing.Color naranjaTitulo = System.Drawing.Color.FromArgb(216, 122, 45);

            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorial.RowTemplate.Height = 28;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            dgvHistorial.EnableHeadersVisualStyles = false;

            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);

            dgvHistorial.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);

            _tablaHistorial = new DataTable();
            _tablaHistorial.Columns.Add("Numero Contrato", typeof(string));
            _tablaHistorial.Columns.Add("Arrendatario", typeof(string));
            _tablaHistorial.Columns.Add("Nombre Propiedad", typeof(string));
            _tablaHistorial.Columns.Add("Fecha Inicio", typeof(DateTime));
            _tablaHistorial.Columns.Add("Fecha Final", typeof(DateTime));
            _tablaHistorial.Columns.Add("Monto", typeof(decimal));
            _tablaHistorial.Columns.Add("Estado", typeof(string));

            dgvHistorial.DataSource = _tablaHistorial;

            if (dgvHistorial.Columns["Fecha Inicio"] != null)
                dgvHistorial.Columns["Fecha Inicio"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvHistorial.Columns["Fecha Final"] != null)
                dgvHistorial.Columns["Fecha Final"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvHistorial.Columns["Monto"] != null)
            {
                dgvHistorial.Columns["Monto"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-HN");
                dgvHistorial.Columns["Monto"].DefaultCellStyle.Format = "C2";
                dgvHistorial.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnBuscarH_Click(object sender, EventArgs e)      => FiltrarHistorial();
        private void txtBusquedaH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) FiltrarHistorial();
        }

        private void FiltrarHistorial()
        {
            string filtro = txtBusquedaH.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(filtro))
            {
                _tablaHistorial.DefaultView.RowFilter = string.Empty;
                return;
            }

            _tablaHistorial.DefaultView.RowFilter =
                $"Convert([Numero Contrato], 'System.String') LIKE '%{filtro}%' OR " +
                $"Convert(Arrendatario, 'System.String') LIKE '%{filtro}%' OR " +
                $"Convert([Nombre Propiedad], 'System.String') LIKE '%{filtro}%' OR " +
                $"Convert(Estado, 'System.String') LIKE '%{filtro}%'";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (_tipoActivo == null)
            {
                MessageBox.Show(
                    "Por favor, seleccione un tipo de contrato.", 
                    "Aviso"
                );
                return;
            }

            TipoContrato tipoSeleccionado = TipoContrato.Apartamento;
            if (_tipoActivo == btnTipoLocal) tipoSeleccionado = TipoContrato.Local;
            else if (_tipoActivo == btnTipoSala) tipoSeleccionado = TipoContrato.Auditorio;
            else if (_tipoActivo == btnTipoCasa) tipoSeleccionado = TipoContrato.CasaPlaya;

            Dictionary<string, string> datosContrato = new Dictionary<string, string>();

            try
            {
                switch (tipoSeleccionado)
                {
                    case TipoContrato.Apartamento:
                        datosContrato = ObtenerDatosApartamento();
                        break;
                    case TipoContrato.Local:
                        datosContrato = ObtenerDatosLocal();
                        break;
                    case TipoContrato.Auditorio:
                        datosContrato = ObtenerDatosSala();
                        break;
                    case TipoContrato.CasaPlaya:
                        datosContrato = ObtenerDatosCasa();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Faltan datos o tienen un formato incorrecto: " + ex.Message, 
                    "Error."
                );
                return;
            }

            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string marcaTiempo = DateTime.Now.Ticks.ToString();

            string rutaDocx = rutaEscritorio + $@"\Contrato_{tipoSeleccionado}_{marcaTiempo}.docx";
            string rutaPdf = rutaEscritorio + $@"\Contrato_{tipoSeleccionado}_{marcaTiempo}.pdf";

            try
            {
                GeneradorContratos generador = new GeneradorContratos();
                generador.GenerarDocumento(tipoSeleccionado, datosContrato, rutaDocx);

                ConvertirWordAPdf(rutaDocx, rutaPdf);

                if (System.IO.File.Exists(rutaDocx))
                {
                    System.IO.File.Delete(rutaDocx);
                }

                MessageBox.Show(
                    "Contrato generado con éxito en PDF en:\n" + rutaPdf, 
                    "Éxito."
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al generar: " + ex.Message, 
                    "Error."
                );
            }
        }
        private Dictionary<string, string> ObtenerDatosApartamento()
        {
            DateTime fechaSeleccionada = dtpFechaArrendamientoA.Value;
            string depositoEnPalabras = "cero"; 
            string precioEnPalabras = "cero";
            if (int.TryParse(txtPrecioAlquilerA.Text, out int precioNumerica))
            {
                precioEnPalabras = precioNumerica.ToWords(new CultureInfo("es-ES"));
            }
            else
            {
                precioEnPalabras = "error_numero_invalido";
            }
            if (int.TryParse(txtDepositoUnitarioA.Text, out int depositoNumerica))
            {
                depositoEnPalabras = depositoNumerica.ToWords(new CultureInfo("es-ES"));
            }
            else
            {
                depositoEnPalabras = "error_numero_invalido";
            }
            return new Dictionary<string, string>
            {
                { "${nombre_arrendatario}", txtNombreArrendatarioA.Text.ToUpper()},
                { "${identidad_arrendatario}", txtIdentidadA.Text },
                { "${numero_departamento}", cmbNumeroApartamento.Text },
                { "${clave_contador}", txtClaveContadorA.Text },
                { "${dia_arrendamiento}", fechaSeleccionada.Day.ToString("00")},
                { "${mes_arrendamiento}", fechaSeleccionada.ToString("MMMM").ToUpper()},
                { "{anio_arrendamiento}", fechaSeleccionada.Year.ToString("0000")},
                { "${precio_unitario}", txtPrecioAlquilerA.Text },
                { "${precio_letras}", precioEnPalabras.ToUpper() },
                { "${dia_mensualidad}", txtDiaMensualidadA.Text },
                { "${deposito_unitario}", txtDepositoUnitarioA.Text },
                { "${deposito_letras}", depositoEnPalabras.ToUpper()},
                { "${dia_actual}", DateTime.Now.Day.ToString() },
                { "${mes_actual}", DateTime.Now.ToString("MMMM") },
                { "${anio_actual}", DateTime.Now.Year.ToString() }
            };
        }

        private Dictionary<string, string> ObtenerDatosLocal()
        {
            DateTime fechaSeleccionada = dtpFechaArrendamientoL.Value;
            string duracionEnPalabras = "cero";

            if (int.TryParse(txtDuracionAlquilerL.Text, out int duracionNumerica))
            {
                duracionEnPalabras = duracionNumerica.ToWords(new CultureInfo("es-ES"));
            }
            else
            {
                duracionEnPalabras = "error_numero_invalido";
            }

            return new Dictionary<string, string>
            {
                { "${nombre_empresa}", txtNombreEmpresaL.Text },
                { "${nombre_arrendatario}", txtNombreArrendatarioL.Text },
                { "${profesion_arrendatario}", txtProfesionArrendatarioL.Text },
                { "${numero_rtn}", txtRTNEmpresaL.Text },
                { "${identidad_arrendatario}", txtIdentidadArrendatarioL.Text },
                { "${nacionalidad_arrendatario}", txtNacionalidadL.Text },
                { "{numero_local}", cmbNumeroLocal.Text },
                { "${duracion_numeros}", txtDuracionAlquilerL.Text },
                { "${duracion_arrendamiento}", duracionEnPalabras.ToUpper()},
                { "${dia_arrendamiento}", fechaSeleccionada.Day.ToString("00")},
                { "${mes_arrendamiento}", fechaSeleccionada.ToString("MMMM").ToUpper()},
                { "${anio_arrendamiento}", fechaSeleccionada.Year.ToString("0000")},
                { "${precio_alquiler}", txtPrecioAlquilerL.Text },
                { "${valores_agregados}", txtValoresAgregadosL.Text },
                { "${deposito_unitario}", txtDepositoUnitarioL.Text },
                { "${dia_creacion}", DateTime.Now.Day.ToString() },
                { "${mes_creacion}", DateTime.Now.ToString("MMMM") },
                { "${anio_creacion}", DateTime.Now.Year.ToString() }
            };
        }

        private Dictionary<string, string> ObtenerDatosSala()
        {
            decimal precioHora = 0;
            decimal.TryParse(txtPrecioHoraS.Text, out precioHora);

            TimeSpan diferencia = dtpHoraFinalS.Value - dtpHoraInicioS.Value;
            double totalHoras = diferencia.TotalHours > 0 ? diferencia.TotalHours : 0;
            txtNumeroHorasS.Text = totalHoras.ToString("0.##");

            decimal precioTotal = (decimal)totalHoras * precioHora;

            return new Dictionary<string, string>
            {
                { "${seleccion}", cmbSeleccionSala.Text.ToUpper() },
                { "${nombre_arrendatario}", txtNombreArrendatarioS.Text.ToUpper() },
                { "${numero_identidad}", txtIdentidadS.Text },
                { "${numero_horas}", totalHoras.ToString("0.##") },
                { "${fecha_arrendamiento}", dtpFechaArrendamientoS.Value.ToString("dd/MM/yyyy") },       
                { "${hora_inicio}", dtpHoraInicioS.Value.ToString("hh:mm tt") },
                { "${hora_final}", dtpHoraFinalS.Value.ToString("hh:mm tt") },
                { "${precio_hora}", precioHora.ToString("N2") },
                { "${cantidad_personas}", cmbCantidadPersonasS.Text },
                { "${dia_creacion}", DateTime.Now.Day.ToString().ToUpper()},
                { "${mes_creacion}", DateTime.Now.ToString("MMMM") },
                { "${anio_creacion}", DateTime.Now.Year.ToString() },
                { "${precio_total}", precioTotal.ToString("N2") }
            };
        }

        private Dictionary<string, string> ObtenerDatosCasa()
        {
            decimal tarifaNoche = 0;
            decimal.TryParse(txtTarifaC.Text, out tarifaNoche);

            decimal deposito = 0;
            decimal.TryParse(txtDepositoC.Text, out deposito);

            TimeSpan diferenciaDias = dtpFechaFinalC.Value.Date - dtpFechaInicialC.Value.Date;
            int totalNoches = diferenciaDias.Days > 0 ? diferenciaDias.Days : 1;
            txtDiasC.Text = totalNoches.ToString();

            decimal totalTarifa = tarifaNoche * totalNoches;

            return new Dictionary<string, string>
                {
                    { "${nombre_huesped}", txtNombreHuespedC.Text.ToUpper() },
                    { "${identidad_huesped}", txtIdentidadHuespedC.Text },
                    { "${seleccion}", cmbSeleccionCasa.Text.ToUpper() },
                    { "${fecha_inicial}", dtpFechaInicialC.Value.ToString("dd/MM/yyyy") },
                    { "${fecha_final}", dtpFechaFinalC.Value.ToString("dd/MM/yyyy") },
                    { "${hora_inicial}", dtpHoraInicialC.Value.ToString("hh:mm tt") },
                    { "${tarifa}", tarifaNoche.ToString("N2") },
                    { "${dias}", totalNoches.ToString() },
                    { "${total_tarifa}", totalTarifa.ToString("N2") },
                    { "${total_personas}", txtTotalPersonasC.Text },
                    { "${deposito}", deposito.ToString("N2") },
                    { "${dia_actual}", DateTime.Now.Day.ToString() },
                    { "${mes_actual}", DateTime.Now.ToString("MMMM") },
                    { "${anio_actual}", DateTime.Now.Year.ToString() }
                };
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvHistorial.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim().ToLower();

                switch (estado)
                {
                    case "vigente":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                        break;
                    case "por vencer":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                        break;
                    case "finalizado":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#8F8686");
                        break;
                    case "cancelado":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                        break;
                }

                e.CellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            }
        }
        private void ConvertirWordAPdf(string rutaOrigenDocx, string rutaDestinoPdf)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = false;
            Microsoft.Office.Interop.Word.Document doc = null;

            try
            {
                doc = wordApp.Documents.Open(rutaOrigenDocx);
                doc.ExportAsFixedFormat(rutaDestinoPdf, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, OpenAfterExport: true);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                }
                if (wordApp != null)
                {
                    wordApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                }
            }
        }

        private void CargarArrendatarios()
        {
            try
            {
                string queryCargarArrendatarios = "SELECT NombreCompleto from Clientes order by NombreCompleto asc;";
                sugerencias.Clear();
                
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    SqlCommand cmdCargarArrendatarios = new SqlCommand(queryCargarArrendatarios, conexion);
                    SqlDataReader readerCargarArrendatarios = cmdCargarArrendatarios.ExecuteReader();
                    while (readerCargarArrendatarios.Read())
                    {
                        sugerencias.Add(readerCargarArrendatarios["NombreCompleto"].ToString());
                    }
                    txtNombreArrendatarioA.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombreArrendatarioA.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtNombreArrendatarioA.AutoCompleteCustomSource = sugerencias;
                    txtNombreArrendatarioL.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombreArrendatarioL.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtNombreArrendatarioL.AutoCompleteCustomSource = sugerencias;
                    txtNombreArrendatarioS.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombreArrendatarioS.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtNombreArrendatarioS.AutoCompleteCustomSource = sugerencias;
                    txtNombreHuespedC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtNombreHuespedC.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtNombreHuespedC.AutoCompleteCustomSource = sugerencias;
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
        private void CargarPropiedadesDisponibles()
        {
            CargarComboPropiedad(cmbNumeroApartamento, "Apartamento");
            CargarComboPropiedad(cmbNumeroLocal, "Local Comercial");
        }
        private void CargarComboPropiedad(ComboBox combo, string nombreTipo)
        {
            combo.Items.Clear();
            combo.Items.Add(new PropiedadDisponible { IdPropiedad = "", Codigo = "", Numero = "--Seleccionar--" });

            // Ajusta "EstadoActual" al nombre real de columna en tu vista si es distinto
            string query = @"
        SELECT p.IdPropiedad, p.Codigo
        FROM Propiedades p
        INNER JOIN TiposPropiedad tp ON p.IdTipoPropiedad = tp.IdTipoPropiedad
        INNER JOIN vw_EstadoActualPropiedad v ON v.IdPropiedad = p.IdPropiedad
        WHERE tp.Nombre = @tipo AND v.EstadoActual = 'Disponible'
        ORDER BY p.Codigo";

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tipo", nombreTipo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string codigo = reader["Codigo"].ToString();
                            combo.Items.Add(new PropiedadDisponible
                            {
                                IdPropiedad = reader["IdPropiedad"].ToString(),
                                Codigo = codigo,
                                Numero = Regex.Match(codigo, @"\d+").Value
                            });
                        }
                    }
                }
            }
            combo.SelectedIndex = 0;
        }
        private string devolverIdentidadArrendatario(string nombre)
        {
            string identidad = string.Empty;
            try
            {
                string queryDevolverIdentidadArrendatario = "SELECT Identidad from Clientes where NombreCompleto = @nombre;";

                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    SqlCommand cmdDevolverIdentidadArrendatario = new SqlCommand(queryDevolverIdentidadArrendatario, conexion);
                    cmdDevolverIdentidadArrendatario.Parameters.AddWithValue("@nombre", nombre);
                    SqlDataReader readerDevolverIdentidadArrendatario = cmdDevolverIdentidadArrendatario.ExecuteReader();
                    while (readerDevolverIdentidadArrendatario.Read())
                    {
                        identidad = readerDevolverIdentidadArrendatario["Identidad"].ToString();
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
            return identidad;
        }
        private void txtNombreArrendatarioA_TextChanged(object sender, EventArgs e)
        {
            txtIdentidadA.Clear();
            if (sugerencias.Contains(txtNombreArrendatarioA.Text))
            {
                txtIdentidadA.Text = devolverIdentidadArrendatario(txtNombreArrendatarioA.Text);
            }

            if (txtIdentidadA.Text.Length < 15)
            {
                lblVNombreA.Text = "Seleccione un arrendatario.";
                lblVNombreA.Visible = true;
            }
            else
            {
                lblVNombreA.Visible = false;
            }

            ValidarParaGenerar();
        }
        private void ValidarParaGenerar()
        {
            if(lblVNombreA.Visible == true ||
                lblVClaveContador.Visible == true || 
                lblVPrecioAlquiler.Visible == true || 
                lblVDepositoUnitario.Visible == true || 
                lblVFechaA.Visible == true ||
                lblVDiaM.Visible == true ||
                lblVNumeroA.Visible == true)
            {
                btnGuardar.Enabled = false;
                btnGenerar.Enabled = false;
            }
            else
            {
                btnGuardar.Enabled = true;
                btnGenerar.Enabled = true;
            }
        }
        private void txtClaveContadorA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecioAlquilerA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDepositoUnitarioA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiaMensualidadA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtClaveContadorA_TextChanged(object sender, EventArgs e)
        {
            if(txtClaveContadorA.Text.Length < 5)
            {
                lblVClaveContador.Text = "Debe ingresar un valor numerico.";
                lblVClaveContador.Visible = true;
            }
            else
            {
                lblVClaveContador.Visible = false;
            }
            ValidarParaGenerar();
        }

        private void dtpFechaArrendamientoA_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaArrendamientoA.Value.Date < DateTime.Now.Date)
            {
                lblVFechaA.Text = "Debe seleccionar una fecha mayor o igual a la actual.";
                lblVFechaA.Visible = true;
            }
            else
            {
                lblVFechaA.Visible = false;
            }
            ValidarParaGenerar();
        }

        private void txtPrecioAlquilerA_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioAlquilerA.Text.Trim() == string.Empty)
            {
                txtPrecioAlquilerA.Text = "0";
                txtPrecioAlquilerA.SelectionStart = txtPrecioAlquilerA.Text.Length;
            }
            else
            {
                if (int.Parse(txtPrecioAlquilerA.Text) <= 0)
                {
                    lblVPrecioAlquiler.Text = "Debe intriducir un monto mayor que 0.";
                    lblVPrecioAlquiler.Visible = true;
                }
                else
                {
                    lblVPrecioAlquiler.Visible = false;
                }
            }
            ValidarParaGenerar();
        }

        private void txtDepositoUnitarioA_TextChanged(object sender, EventArgs e)
        {
            if (txtDepositoUnitarioA.Text.Trim() == string.Empty)
            {
                txtDepositoUnitarioA.Text = "0";
                txtDepositoUnitarioA.SelectionStart = txtDepositoUnitarioA.Text.Length;
            }
            else
            {
                if (int.Parse(txtDepositoUnitarioA.Text) <= 0)
                {
                    lblVDepositoUnitario.Text = "Debe intriducir un monto mayor que 0.";
                    lblVDepositoUnitario.Visible = true;
                }
                else
                {
                    lblVDepositoUnitario.Visible = false;
                }
            }
            ValidarParaGenerar();
        }

        private void cmbNumeroDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNumeroApartamento.SelectedIndex == 0)
            {
                lblVNumeroA.Text = "Debe intriducir un monto mayor que 0.";
                lblVNumeroA.Visible = true;
            }
            else
            {
                lblVNumeroA.Visible = false;
            }
            ValidarParaGenerar();
        }

        private void txtDiaMensualidadA_TextChanged(object sender, EventArgs e)
        {
            if (txtDiaMensualidadA.Text.Trim() == string.Empty)
            {
                txtDiaMensualidadA.Text = "0";
                txtDiaMensualidadA.SelectionStart = txtDiaMensualidadA.Text.Length;
            }
            else
            {
                if (int.Parse(txtDiaMensualidadA.Text) <= 0)
                {
                    lblVDiaM.Text = "Debe intriducir un numero mayor que 0.";
                    lblVDiaM.Visible = true;
                }
                else
                {
                    lblVDiaM.Visible = false;
                }
            }
            ValidarParaGenerar();
        }

        private void txtNombreArrendatarioL_TextChanged(object sender, EventArgs e)
        {
            txtIdentidadArrendatarioL.Clear();
            txtNombreEmpresaL.Clear();
            txtRTNEmpresaL.Clear();

            if (sugerencias.Contains(txtNombreArrendatarioL.Text))
            {
                txtIdentidadArrendatarioL.Text = devolverIdentidadArrendatario(txtNombreArrendatarioL.Text);

                ObtenerDatosEmpresaArrendatario(txtNombreArrendatarioL.Text, out string empresa, out string rtn);
                txtNombreEmpresaL.Text = empresa;
                txtRTNEmpresaL.Text = rtn;
            }
        }

        private void txtNombreArrendatarioS_TextChanged(object sender, EventArgs e)
        {
            txtIdentidadS.Clear();
            if (sugerencias.Contains(txtNombreArrendatarioS.Text))
                txtIdentidadS.Text = devolverIdentidadArrendatario(txtNombreArrendatarioS.Text);
        }

        private void txtNombreHuespedC_TextChanged(object sender, EventArgs e)
        {
            txtIdentidadHuespedC.Clear();
            if (sugerencias.Contains(txtNombreHuespedC.Text))
                txtIdentidadHuespedC.Text = devolverIdentidadArrendatario(txtNombreHuespedC.Text);
        }
        private int ObtenerIdCliente(string identidad)
        {
            int idCliente = 0;
            string query = "SELECT IdCliente FROM Clientes WHERE Identidad = @identidad";
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@identidad", identidad);
                    var result = cmd.ExecuteScalar();
                    if (result != null) idCliente = Convert.ToInt32(result);
                }
            }
            return idCliente;
        }
        private string ObtenerIdPropiedad(string nombrePropiedad)
        {
            string idPropiedad = "";
            string query = "SELECT IdPropiedad FROM Propiedades WHERE Codigo = @codigo";
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@codigo", nombrePropiedad);
                    var result = cmd.ExecuteScalar();
                    if (result != null) idPropiedad = result.ToString();
                }
            }
            return idPropiedad;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_tipoActivo == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de contrato a generar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_tipoActivo == btnTipoSala || _tipoActivo == btnTipoCasa)
            {
                MessageBox.Show(
                    "Las reservaciones de Auditorio, Sala de Juntas y Casas Vacacionales se registran desde el módulo de Reservaciones.\n\n" +
                    "Este apartado solo permite generar el documento en PDF. Para que la reservación quede guardada en la base de datos, créela en Reservaciones.",
                    "Uso del módulo de Reservaciones",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (_tipoActivo == btnTipoApartamento) GuardarApartamento();
                else if (_tipoActivo == btnTipoLocal) GuardarLocal();

                CargarDatosDesdeBD();
                CargarPropiedadesDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarApartamento()
        {
            if (string.IsNullOrWhiteSpace(txtIdentidadA.Text) || cmbNumeroApartamento.SelectedIndex <= 0 ||
                string.IsNullOrWhiteSpace(txtPrecioAlquilerA.Text) || string.IsNullOrWhiteSpace(txtDepositoUnitarioA.Text))
            {
                MessageBox.Show("Todos los campos del apartamento son obligatorios y debe seleccionar un cliente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = ObtenerIdCliente(txtIdentidadA.Text);
            string idPropiedad = ((PropiedadDisponible)cmbNumeroApartamento.SelectedItem).IdPropiedad;
            string numContrato = "APT-" + DateTime.Now.ToString("yyyyMMddHHmm");

            if (idCliente == 0 || string.IsNullOrEmpty(idPropiedad)) { MessageBox.Show("Error al guardar en base de datos."); return; }

            string query = @"INSERT INTO Contratos (NumeroContrato, IdPropiedad, IdArrendatario, FechaInicio, FechaFin, MontoMensual, DepositoGarantia, DiaPagoMensual, IdEstadoContrato, Observaciones) 
                     VALUES (@num, @idProp, @idCli, @inicio, @fin, @monto, @deposito, @dia, 1, 'Contrato generado por sistema')";

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@num", numContrato);
                    cmd.Parameters.AddWithValue("@idProp", idPropiedad);
                    cmd.Parameters.AddWithValue("@idCli", idCliente);
                    cmd.Parameters.AddWithValue("@inicio", dtpFechaArrendamientoA.Value);
                    cmd.Parameters.AddWithValue("@fin", dtpFechaArrendamientoA.Value.AddYears(1)); // Apartamentos asumen 1 año
                    cmd.Parameters.AddWithValue("@monto", Convert.ToDecimal(txtPrecioAlquilerA.Text));
                    cmd.Parameters.AddWithValue("@deposito", Convert.ToDecimal(txtDepositoUnitarioA.Text));
                    cmd.Parameters.AddWithValue("@dia", Convert.ToInt32(txtDiaMensualidadA.Text));
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Contrato de Apartamento guardado exitosamente. Ahora puede Generar el documento.", "Éxito");
        }

        private void GuardarLocal()
        {
            if (string.IsNullOrWhiteSpace(txtIdentidadArrendatarioL.Text) || cmbNumeroLocal.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtDuracionAlquilerL.Text) || string.IsNullOrWhiteSpace(txtPrecioAlquilerL.Text))
            {
                MessageBox.Show("Todos los campos del local comercial son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = ObtenerIdCliente(txtIdentidadArrendatarioL.Text);
            string idPropiedad = ((PropiedadDisponible)cmbNumeroLocal.SelectedItem).IdPropiedad;
            string numContrato = "LOC-" + DateTime.Now.ToString("yyyyMMddHHmm");

            if (idCliente == 0 || string.IsNullOrEmpty(idPropiedad)) { MessageBox.Show("Cliente o Propiedad no encontrados en BD."); return; }

            int mesesDuracion = Convert.ToInt32(txtDuracionAlquilerL.Text);

            string query = @"INSERT INTO Contratos (NumeroContrato, IdPropiedad, IdArrendatario, FechaInicio, FechaFin, MontoMensual, DepositoGarantia, DiaPagoMensual, IdEstadoContrato, Observaciones) 
                     VALUES (@num, @idProp, @idCli, @inicio, @fin, @monto, @deposito, 1, 1, 'Empresa: ' + @empresa)";

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@num", numContrato);
                    cmd.Parameters.AddWithValue("@idProp", idPropiedad);
                    cmd.Parameters.AddWithValue("@idCli", idCliente);
                    cmd.Parameters.AddWithValue("@inicio", dtpFechaArrendamientoL.Value);
                    cmd.Parameters.AddWithValue("@fin", dtpFechaArrendamientoL.Value.AddMonths(mesesDuracion));
                    cmd.Parameters.AddWithValue("@monto", Convert.ToDecimal(txtPrecioAlquilerL.Text));
                    cmd.Parameters.AddWithValue("@deposito", Convert.ToDecimal(txtDepositoUnitarioL.Text));
                    cmd.Parameters.AddWithValue("@empresa", txtNombreEmpresaL.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Contrato de Local guardado exitosamente. Ahora puede Generar el documento.", "Éxito");
        }

        private void GuardarSala()
        {
            if (string.IsNullOrWhiteSpace(txtIdentidadS.Text) || cmbSeleccionSala.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtPrecioHoraS.Text))
            {
                MessageBox.Show("Todos los campos para la sala/auditorio son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = ObtenerIdCliente(txtIdentidadS.Text);
            string idPropiedad = ObtenerIdPropiedad(cmbSeleccionSala.Text);
            string numReserva = "RES-" + DateTime.Now.ToString("yyyyMMddHHmm");

            if (idCliente == 0 || string.IsNullOrEmpty(idPropiedad)) { MessageBox.Show("Error al guardar en base de datos."); return; }

            TimeSpan diferencia = dtpHoraFinalS.Value - dtpHoraInicioS.Value;
            decimal precioHora = Convert.ToDecimal(txtPrecioHoraS.Text);
            decimal total = (decimal)diferencia.TotalHours * precioHora;

            string query = @"INSERT INTO Reservaciones (NumeroReservacion, IdPropiedad, IdCliente, FechaEntrada, FechaSalida, NumeroPersonas, MontoTotal, IdEstadoReservacion) 
                     VALUES (@num, @idProp, @idCli, @entrada, @salida, @personas, @monto, 2)"; // 2 = Confirmada

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@num", numReserva);
                    cmd.Parameters.AddWithValue("@idProp", idPropiedad);
                    cmd.Parameters.AddWithValue("@idCli", idCliente);
                    cmd.Parameters.AddWithValue("@entrada", dtpFechaArrendamientoS.Value.Date + dtpHoraInicioS.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@salida", dtpFechaArrendamientoS.Value.Date + dtpHoraFinalS.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@personas", Convert.ToInt16(cmbCantidadPersonasS.Text));
                    cmd.Parameters.AddWithValue("@monto", total);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Reservación de Sala guardada exitosamente. Ahora puede Generar el documento.", "Éxito");
        }

        private void GuardarCasa()
        {
            if (string.IsNullOrWhiteSpace(txtIdentidadHuespedC.Text) || cmbSeleccionCasa.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(txtTarifaC.Text) || string.IsNullOrWhiteSpace(txtTotalPersonasC.Text))
            {
                MessageBox.Show("Todos los campos para la casa vacacional son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = ObtenerIdCliente(txtIdentidadHuespedC.Text);
            string idPropiedad = ObtenerIdPropiedad(cmbSeleccionCasa.Text);
            string numReserva = "CAS-" + DateTime.Now.ToString("yyyyMMddHHmm");

            if (idCliente == 0 || string.IsNullOrEmpty(idPropiedad)) { MessageBox.Show("Cliente o Propiedad no encontrados en BD."); return; }

            TimeSpan diferenciaDias = dtpFechaFinalC.Value.Date - dtpFechaInicialC.Value.Date;
            int totalNoches = diferenciaDias.Days > 0 ? diferenciaDias.Days : 1;
            decimal total = Convert.ToDecimal(txtTarifaC.Text) * totalNoches;

            string query = @"INSERT INTO Reservaciones (NumeroReservacion, IdPropiedad, IdCliente, FechaEntrada, FechaSalida, NumeroPersonas, MontoTotal, IdEstadoReservacion, Observaciones) 
                     VALUES (@num, @idProp, @idCli, @entrada, @salida, @personas, @monto, 2, 'Depósito: ' + @deposito)";

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@num", numReserva);
                    cmd.Parameters.AddWithValue("@idProp", idPropiedad);
                    cmd.Parameters.AddWithValue("@idCli", idCliente);
                    cmd.Parameters.AddWithValue("@entrada", dtpFechaInicialC.Value.Date + dtpHoraInicialC.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@salida", dtpFechaFinalC.Value.Date + TimeSpan.FromHours(13)); // Check-out 1 PM
                    cmd.Parameters.AddWithValue("@personas", Convert.ToInt16(txtTotalPersonasC.Text));
                    cmd.Parameters.AddWithValue("@monto", total);
                    cmd.Parameters.AddWithValue("@deposito", txtDepositoC.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Reservación de Casa guardada exitosamente. Ahora puede Generar el documento.", "Éxito");
        }
        private void CargarContratosParaEdicion()
        {
            try
            {
                cboSolicitud.Items.Clear();
                cboSolicitud.Items.Add("--Seleccionar--");

                string query = @"
                SELECT c.NumeroContrato 
                FROM Contratos c
                INNER JOIN EstadosContrato ec ON c.IdEstadoContrato = ec.IdEstadoContrato
                WHERE ec.Nombre IN ('Vigente', 'Por Vencer')
                ORDER BY c.FechaCreacion DESC";
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cboSolicitud.Items.Add(reader["NumeroContrato"].ToString());
                        }
                    }
                }
                cboSolicitud.SelectedIndex = 0;

                cmbEstadoActu.Items.Clear();
                cmbEstadoActu.Items.Add("Finalizado");
                cmbEstadoActu.Items.Add("Cancelado");
                cmbEstadoActu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar contratos: " + ex.Message, "Error");
            }
        }

        private void cboSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSolicitud.SelectedIndex == 0)
            {
                txtPropiedadActu.Clear();
                txtClienteEmpresa.Clear();
                txtObservacionesActu.Clear();
                return;
            }

            string query = @"SELECT p.Codigo as Propiedad, cl.NombreCompleto as Cliente, 
                            c.FechaFin, c.Observaciones, ec.Nombre as Estado
                     FROM Contratos c
                     INNER JOIN Propiedades p ON c.IdPropiedad = p.IdPropiedad
                     INNER JOIN Clientes cl ON c.IdArrendatario = cl.IdCliente
                     INNER JOIN EstadosContrato ec ON c.IdEstadoContrato = ec.IdEstadoContrato
                     WHERE c.NumeroContrato = @num";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@num", cboSolicitud.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtPropiedadActu.Text = reader["Propiedad"].ToString();
                            txtClienteEmpresa.Text = reader["Cliente"].ToString();
                            dtpFinalizacionActu.Value = Convert.ToDateTime(reader["FechaFin"]);
                            txtObservacionesActu.Text = reader["Observaciones"].ToString();
                            cmbEstadoActu.Text = reader["Estado"].ToString();
                        }
                    }
                }
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cboSolicitud.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor seleccione un contrato válido para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const int DiasParaPorVencer = 15;

            string estadoSeleccionado = cmbEstadoActu.Text.Trim();
            int idEstado;

            if (estadoSeleccionado.Equals("Finalizado", StringComparison.OrdinalIgnoreCase))
            {
                idEstado = 3; // Finalizado
            }
            else if (estadoSeleccionado.Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
            {
                idEstado = 4; // Cancelado
            }
            else
            {
                int diasRestantes = (dtpFinalizacionActu.Value.Date - DateTime.Now.Date).Days;
                idEstado = diasRestantes <= DiasParaPorVencer ? 2 : 1;
            }

            string query = @"UPDATE Contratos 
                 SET FechaFin = @fin, 
                     IdEstadoContrato = @estado, 
                     Observaciones = @obs 
                 WHERE NumeroContrato = @num";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@fin", dtpFinalizacionActu.Value);
                        cmd.Parameters.AddWithValue("@estado", idEstado);
                        cmd.Parameters.AddWithValue("@obs", txtObservacionesActu.Text);
                        cmd.Parameters.AddWithValue("@num", cboSolicitud.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("¡Contrato actualizado exitosamente!", "Éxito");

                CargarDatosDesdeBD();
                CargarContratosParaEdicion();
                cboSolicitud.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error");
            }
        }
        private void ObtenerDatosEmpresaArrendatario(string nombre, out string empresa, out string rtn)
        {
            empresa = string.Empty;
            rtn = string.Empty;
            string query = "SELECT NombreEmpresa, RTN FROM Clientes WHERE NombreCompleto = @nombre";
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empresa = reader["NombreEmpresa"] == DBNull.Value ? string.Empty : reader["NombreEmpresa"].ToString();
                            rtn = reader["RTN"] == DBNull.Value ? string.Empty : reader["RTN"].ToString();
                        }
                    }
                }
            }
        }
    }
}
