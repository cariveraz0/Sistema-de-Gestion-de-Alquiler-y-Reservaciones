using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Humanizer;
using Microsoft.Data.SqlClient;
using ProyectoInversion;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class ContratosForm : Form
    {
        // Color activo (naranja principal)
        private static readonly Color ColorActivo   = ColorTranslator.FromHtml("#C84F24");
        // Color inactivo (gris claro)
        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");

        // Tabla fuente del historial (para filtrar sin perder datos)
        private DataTable _tablaHistorial;

        // Tipo de propiedad seleccionado actualmente
        private Button _tipoActivo = null;

        public ContratosForm()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDatosDesdeBD();
            ActivarTabNuevo();

            cmbSeleccionCasa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeleccionSala.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCantidadPersonasS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNumeroDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNumeroLocal.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ═══════════════════════════════════════════════════════════
        //  Carga
        // ═══════════════════════════════════════════════════════════
        private void ContratosForm_Load(object sender, EventArgs e)
        {
            // Punto de extensión para carga de datos reales
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
        }

        // ═══════════════════════════════════════════════════════════
        //  Pestañas principales
        // ═══════════════════════════════════════════════════════════
        private void btnTabNuevo_Click(object sender, EventArgs e)    => ActivarTabNuevo();
        private void btnTabHistorial_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlNuevoContrato.Visible = true;
            pnlHistorial.Visible     = false;
            pnlAccion.Visible        = true;

            EstiloTabActivo(btnTabNuevo);
            EstiloTabInactivo(btnTabHistorial);
        }

        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible     = true;
            pnlNuevoContrato.Visible = false;
            pnlAccion.Visible        = false;

            EstiloTabActivo(btnTabHistorial);
            EstiloTabInactivo(btnTabNuevo);
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
        }

        private void LimpiarPanelControles(Panel panel)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox txt) txt.Clear();
                if (c is ComboBox cmb) cmb.SelectedIndex = -1;
                if (c is DateTimePicker dtp) dtp.Value = DateTime.Today;
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
                MessageBox.Show("Error al cargar el historial de contratos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Formato Moneda de Honduras (como en tu reporte)
                dgvHistorial.Columns["Monto"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-HN");
                dgvHistorial.Columns["Monto"].DefaultCellStyle.Format = "C2";
                dgvHistorial.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        // ═══════════════════════════════════════════════════════════
        //  Historial — Búsqueda
        // ═══════════════════════════════════════════════════════════
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
                MessageBox.Show("Por favor, seleccione un tipo de contrato.", "Aviso");
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
                MessageBox.Show("Faltan datos o tienen un formato incorrecto: " + ex.Message, "Error");
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

                MessageBox.Show("Contrato generado con éxito en PDF en:\n" + rutaPdf, "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar: " + ex.Message, "Error");
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
                { "${numero_departamento}", cmbNumeroDepartamento.Text },
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
    }
}
