using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProyectoInversion;
using Humanizer;
using System.Globalization;

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
            CargarDatosEjemplo();
            // Al abrir, mostramos la pestaña "Nuevo Contrato" activa
            ActivarTabNuevo();
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

        // ═══════════════════════════════════════════════════════════
        //  Historial — DataGridView
        // ═══════════════════════════════════════════════════════════
        private void ConfigurarDataGridView()
        {
            _tablaHistorial = new DataTable();
            _tablaHistorial.Columns.Add("No.",          typeof(int));
            _tablaHistorial.Columns.Add("Tipo",          typeof(string));
            _tablaHistorial.Columns.Add("Arrendatario",  typeof(string));
            _tablaHistorial.Columns.Add("Propiedad",     typeof(string));
            _tablaHistorial.Columns.Add("Fecha Inicio",  typeof(DateTime));
            _tablaHistorial.Columns.Add("Fecha Fin",     typeof(DateTime));
            _tablaHistorial.Columns.Add("Monto (L.)",    typeof(decimal));
            _tablaHistorial.Columns.Add("Estado",        typeof(string));

            dgvHistorial.DataSource = _tablaHistorial;

            // Formato de columnas de fecha
            if (dgvHistorial.Columns["Fecha Inicio"] != null)
                dgvHistorial.Columns["Fecha Inicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvHistorial.Columns["Fecha Fin"] != null)
                dgvHistorial.Columns["Fecha Fin"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Formato moneda
            if (dgvHistorial.Columns["Monto (L.)"] != null)
                dgvHistorial.Columns["Monto (L.)"].DefaultCellStyle.Format = "N2";

            // Ancho fijo para "No."
            if (dgvHistorial.Columns["No."] != null)
            {
                dgvHistorial.Columns["No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvHistorial.Columns["No."].Width = 50;
            }
        }

        private void CargarDatosEjemplo()
        {
            _tablaHistorial.Rows.Add(1, "Apartamento",     "Carlos Mejía",       "Apto. 3B - Torre Norte",    new DateTime(2025, 1, 1),  new DateTime(2025, 12, 31), 8500m,  "Activo");
            _tablaHistorial.Rows.Add(2, "Local Comercial", "Distribuidora XYZ",  "Local 12 - Plaza Central",  new DateTime(2024, 6, 1),  new DateTime(2025, 5, 31),  15000m, "Vencido");
            _tablaHistorial.Rows.Add(3, "Casa Playa",      "Marta Rodríguez",    "Casa El Paraíso - Tela",    new DateTime(2026, 3, 15), new DateTime(2026, 3, 22),  4200m,  "Activo");
            _tablaHistorial.Rows.Add(4, "Sala de Juntas",  "Empresa Soluciones", "Auditorio A - Edificio G",  new DateTime(2026, 6, 10), new DateTime(2026, 6, 10),  2500m,  "Completado");
            _tablaHistorial.Rows.Add(5, "Apartamento",     "Jorge Pineda",       "Apto. 7A - Residencial Sur", new DateTime(2025, 8, 1), new DateTime(2026, 7, 31),  7200m,  "Activo");
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
                $"Convert(Tipo, 'System.String') LIKE '%{filtro}%' OR " +
                $"Convert(Arrendatario, 'System.String') LIKE '%{filtro}%' OR " +
                $"Convert(Propiedad, 'System.String') LIKE '%{filtro}%' OR ";
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
            string rutaFinal = rutaEscritorio + $@"\Contrato_{tipoSeleccionado}_{DateTime.Now.Ticks}.docx";

            try
            {
                GeneradorContratos generador = new GeneradorContratos();
                generador.GenerarDocumento(tipoSeleccionado, datosContrato, rutaFinal);
                MessageBox.Show("Contrato generado con éxito en:\n" + rutaFinal, "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar: " + ex.Message, "Error");
            }
        }

        private Dictionary<string, string> ObtenerDatosApartamento()
        {
            DateTime fechaSeleccionada = dtpFechaArrendamientoA.Value;
            return new Dictionary<string, string>
            {
                { "${nombre_arrendatario}", txtNombreArrendatarioA.Text },
                { "${identidad_arrendatario}", txtIdentidadA.Text },
                { "${numero_departamento}", cmbNumeroDepartamento.Text },
                { "${clave_contador}", txtClaveContadorA.Text },
                { "${dia_arrendamiento}", fechaSeleccionada.Day.ToString("00")},
                { "${mes_arrendamiento}", fechaSeleccionada.ToString("MMMM").ToUpper()},
                { "{anio_arrendamiento}", fechaSeleccionada.Year.ToString("0000")},
                { "${precio_unitario}", txtPrecioAlquilerA.Text },
                { "${dia_mensualidad}", txtDiaMensualidadA.Text },
                { "${deposito_unitario}", txtDepositoUnitarioA.Text },
                { "${dia_actual}", DateTime.Now.Day.ToString() },
                { "${mes_actual}", DateTime.Now.ToString("MMMM") },
                { "${anio_actual}", DateTime.Now.Year.ToString() }
                //Recordar ${precio_letras} y ${deposito_letras} con Humanizer
            };
        }

        private Dictionary<string, string> ObtenerDatosLocal()
        {
            DateTime fechaSeleccionada = dtpFechaArrendamientoL.Value;
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
                { "${dia_arrendamiento}", fechaSeleccionada.Day.ToString("00")},
                { "${mes_arrendamiento}", fechaSeleccionada.ToString("MMMM").ToUpper()},
                { "${anio_arrendamiento}", fechaSeleccionada.Year.ToString("0000")},
                { "${precio_alquiler}", txtPrecioAlquilerL.Text },
                { "${valores_agregados}", txtValoresAgregadosL.Text },
                { "${deposito_unitario}", txtDepositoUnitarioL.Text },
                { "${dia_creacion}", DateTime.Now.Day.ToString() },
                { "${mes_creacion}", DateTime.Now.ToString("MMMM") },
                { "${anio_creacion}", DateTime.Now.Year.ToString() }
                //${duracion_arrendamiento} con Humanizer y agregar combobox de no. local
            };
        }

        private Dictionary<string, string> ObtenerDatosSala()
        {
            int numHoras = 0;
            decimal precioHora = 0;
            int.TryParse(txtNumeroHorasS.Text, out numHoras);
            decimal.TryParse(txtPrecioHoraS.Text, out precioHora);
            decimal precioTotal = numHoras * precioHora;

            return new Dictionary<string, string>
            {
                { "${seleccion}", cmbSeleccionSala.Text },
                { "${nombre_arrendatario}", txtNombreArrendatarioS.Text },
                { "${numero_identidad}", txtIdentidadS.Text },
                { "${numero_horas}", numHoras.ToString() },
                { "${fecha_arrendamiento}", dtpFechaArrendamientoS.Value.ToString() },
                { "${hora_inicio}", dtpHoraInicioS.Value.ToString()},
                { "${hora_final}", dtpHoraFinalS.Value.ToString() },
                { "${precio_hora}", precioHora.ToString() },
                { "${cantidad_personas}", cmbCantidadPersonasS.Text },
                { "${dia_creacion}", DateTime.Now.Day.ToString() },
                { "${mes_creacion}", DateTime.Now.ToString("MMMM") },
                { "${anio_creacion}", DateTime.Now.Year.ToString() }
                //Hacer que "${precio_total}" sea la multiplicacion de preciohora y numerohoras
                //Arreglar numero de personas, mostrar 200 Auditorio, 100 para Sala de Juntas
            };
        }

        private Dictionary<string, string> ObtenerDatosCasa()
        {
            return new Dictionary<string, string>
            {
                { "${nombre_huesped}", txtNombreHuespedC.Text },
                { "${identidad_huesped}", txtIdentidadHuespedC.Text },
                { "${seleccion}", cmbSeleccionCasa.Text },
                { "${fecha_inicial}", dtpFechaInicialC.Value.ToString() },
                { "${fecha_final}", dtpFechaFinalC.Value.ToString() },
                { "${hora_inicial}", dtpHoraInicialC.Value.ToString() },
                { "${dias}", txtDiasC.Text },
                { "${tarifa}", txtTarifaC.Text },
                { "${total_personas}", txtTotalPersonasC.Text },
                { "${dia_actual}", DateTime.Now.Day.ToString() },
                { "${mes_actual}", DateTime.Now.ToString("MMMM") },
                { "${anio_actual}", DateTime.Now.Year.ToString() }
                //Agregar deposito, esta en el documento pero no lo puse en el formulario
                //${total_tarifa} hacer que sea la multiplicacion de dias * tarifa
                //arreglar fecha arrendamiento en documento?? Si se quita o se deja
            };
        }
    }
}
