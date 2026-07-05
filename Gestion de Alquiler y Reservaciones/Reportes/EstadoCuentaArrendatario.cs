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
using System.IO;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class EstadoCuentaArrendatario : ReporteBase
    {
        private int idContratoActual = 0;
        private Label lblNotaMora;
        private static readonly string RutaLogo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "LogoFinal2.png");

        public EstadoCuentaArrendatario()
        {
            InitializeComponent();

            ConfigurarDataGridView();

            // Permite buscar presionando Enter dentro del cuadro de texto
            filtroNombre.KeyDown += FiltroNombre_KeyDown;

            // El combo de contratos no viene conectado desde el diseñador, se conecta aquí
            cbxContrato.SelectedIndexChanged += cbxContrato_SelectedIndexChanged;

            // Autocompletado: sugiere nombres de arrendatarios existentes mientras se escribe
            CargarSugerenciasArrendatarios();

            AgregarNotaMora();
        }

        // Sobrecarga para abrir el reporte directamente con un contrato ya conocido
        // (por ejemplo, desde el listado de contratos o desde otra pantalla)
        public EstadoCuentaArrendatario(int idContrato) : this()
        {
            idContratoActual = idContrato;
            CargarReporte(idContratoActual);
        }

        // Configura el DataGridView para que las columnas ocupen todo el ancho disponible
        // y permita scroll vertical cuando el historial tenga más filas de las que caben a la vista
        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Agrega debajo del resumen la nota que explica cómo se calcula la mora
        private void AgregarNotaMora()
        {
            lblNotaMora = new Label
            {
                AutoSize = true,
                Font = new Font(label14.Font.FontFamily, 8f, FontStyle.Italic),
                ForeColor = System.Drawing.Color.DimGray,
                Location = new System.Drawing.Point(panel8.Location.X, panel8.Location.Y + panel8.Height + 4),
                Text = "Nota: la mora se calcula aplicando un 5% mensual sobre el saldo pendiente acumulado."
            };

            pnlPrincipal.Controls.Add(lblNotaMora);
            lblNotaMora.BringToFront();
        }

        // Carga en el TextBox la lista de nombres de arrendatarios para el autocompletado nativo
        private void CargarSugerenciasArrendatarios()
        {
            string query = @"
                SELECT DISTINCT cl.NombreCompleto
                FROM clientes cl
                INNER JOIN contratos co ON co.IdArrendatario = cl.IdCliente
                ORDER BY cl.NombreCompleto";

            var sugerencias = new AutoCompleteStringCollection();

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            sugerencias.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las sugerencias de arrendatarios: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            filtroNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            filtroNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            filtroNombre.AutoCompleteCustomSource = sugerencias;
        }

        private void FiltroNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarArrendatario();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarArrendatario();
        }

        // Busca contratos cuyo arrendatario coincida (búsqueda parcial) con el texto ingresado
        // y llena cbxContrato con todos los contratos encontrados para que el usuario elija cuál ver.
        private void BuscarArrendatario()
        {
            string texto = filtroNombre.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                MessageBox.Show("Ingrese el nombre del arrendatario a buscar.", "Búsqueda",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"
                SELECT co.IdContrato, co.NumeroContrato, cl.NombreCompleto, p.Codigo AS Propiedad
                FROM contratos co
                INNER JOIN clientes cl ON cl.IdCliente = co.IdArrendatario
                INNER JOIN Propiedades p ON p.IdPropiedad = co.IdPropiedad
                WHERE cl.NombreCompleto LIKE @Nombre
                ORDER BY co.FechaInicio DESC";

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Nombre", $"%{texto}%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el arrendatario: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron contratos para ese arrendatario.", "Búsqueda",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxContrato.DataSource = null;
                cbxContrato.Items.Clear();
                LimpiarReporte();
                return;
            }

            // Se arma la lista de contratos encontrados para el combo:
            // "Nº de contrato - Propiedad" (si el arrendatario tiene varios contratos, aparecen todos)
            DataTable dtOpciones = new DataTable();
            dtOpciones.Columns.Add("IdContrato", typeof(int));
            dtOpciones.Columns.Add("Texto", typeof(string));

            foreach (DataRow fila in dt.Rows)
            {
                dtOpciones.Rows.Add(
                    Convert.ToInt32(fila["IdContrato"]),
                    //$"{fila["NumeroContrato"]} - {fila["Propiedad"]}");
                    $"{fila["NumeroContrato"]}");
            }

            // Importante: DisplayMember/ValueMember se asignan ANTES del DataSource.
            // Si se asignan después, al fijar el DataSource el combo dispara SelectedIndexChanged
            // de inmediato y, como ValueMember todavía estaría vacío, SelectedValue devolvería el
            // DataRowView completo en vez del IdContrato (InvalidCastException al convertirlo).
            cbxContrato.DisplayMember = "Texto";
            cbxContrato.ValueMember = "IdContrato";
            cbxContrato.DataSource = dtOpciones;

            // Al fijar el DataSource ya queda seleccionado el primer contrato (el más reciente),
            // lo que dispara cbxContrato_SelectedIndexChanged y carga el reporte automáticamente.
        }

        private void cbxContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbxContrato.SelectedValue is int idSeleccionado)) return;

            idContratoActual = idSeleccionado;
            CargarReporte(idContratoActual);
        }

        // Carga toda la información del reporte (encabezado, historial de pagos y resumen)
        // para el contrato indicado
        private void CargarReporte(int idContrato)
        {
            DataRow contrato = ObtenerDatosContrato(idContrato);
            if (contrato == null)
            {
                MessageBox.Show("No se encontró información del contrato.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarEncabezado(contrato);

            DataTable dtHistorial = ObtenerHistorialPagos(idContrato);
            ActualizarDataGridView(dtHistorial);
            ActualizarResumen(dtHistorial);
        }

        // Obtiene la información general del contrato (cliente, propiedad, fechas, monto)
        private DataRow ObtenerDatosContrato(int idContrato)
        {
            string query = @"
                SELECT co.IdContrato, co.NumeroContrato, co.FechaInicio, co.FechaFin, co.MontoMensual,
                       cl.NombreCompleto, p.Codigo AS Propiedad
                FROM contratos co
                INNER JOIN clientes cl ON cl.IdCliente = co.IdArrendatario
                INNER JOIN Propiedades p ON p.IdPropiedad = co.IdPropiedad
                WHERE co.IdContrato = @IdContrato";

            DataTable dt = new DataTable();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@IdContrato", idContrato);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Llena las etiquetas del encabezado ("Información del contrato") con los datos obtenidos
        private void CargarEncabezado(DataRow contrato)
        {
            Nombre.Text = contrato["NombreCompleto"].ToString();
            Propiedad.Text = contrato["Propiedad"].ToString();
            nContrato.Text = contrato["NumeroContrato"].ToString();
            fechaInicio.Text = Convert.ToDateTime(contrato["FechaInicio"]).ToString("dd/MM/yyyy");
            fechaVencimiento.Text = Convert.ToDateTime(contrato["FechaFin"]).ToString("dd/MM/yyyy");
            montoMensual.Text = "L. " + Convert.ToDecimal(contrato["MontoMensual"]).ToString("N2");
        }

        // Obtiene el historial de cuotas del contrato, cruzando cuotascontrato con pagos
        // (LEFT JOIN porque una cuota puede no tener pago registrado todavía)
        private DataTable ObtenerHistorialPagos(int idContrato)
        {
            string query = @"
                SELECT 
                    cc.IdCuota,
                    cc.NumeroCuota,
                    cc.PeriodoCorrespondiente,
                    cc.FechaVencimiento,
                    cc.MontoCuota,
                    cc.MontoMora,
                    ep.Nombre AS Estado,
                    pg.FechaPago,
                    pg.Monto AS MontoPagado,
                    pg.NumeroRecibo
                FROM cuotascontrato cc
                INNER JOIN EstadosPago ep ON ep.IdEstadoPago = cc.IdEstadoPago
                LEFT JOIN pagos pg ON pg.IdCuota = cc.IdCuota
                WHERE cc.IdContrato = @IdContrato
                ORDER BY cc.NumeroCuota";

            DataTable dt = new DataTable();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@IdContrato", idContrato);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        // Transforma el resultado crudo de la consulta al formato de columnas que se muestra en pantalla
        private void ActualizarDataGridView(DataTable dtOrigen)
        {
            DataTable dtVisual = new DataTable();
            dtVisual.Columns.Add("Fecha de Pago", typeof(string));
            dtVisual.Columns.Add("Periodo Cubierto", typeof(string));
            dtVisual.Columns.Add("Monto Pagado", typeof(string));
            dtVisual.Columns.Add("Pago Pendiente", typeof(string));
            dtVisual.Columns.Add("Mora Acumulada", typeof(string));
            dtVisual.Columns.Add("Estado", typeof(string));
            dtVisual.Columns.Add("Observaciones", typeof(string));

            foreach (DataRow fila in dtOrigen.Rows)
            {
                string estado = fila["Estado"].ToString();
                bool pagada = estado.StartsWith("Pagad", StringComparison.OrdinalIgnoreCase);
                bool anulada = estado.Equals("Anulada", StringComparison.OrdinalIgnoreCase);

                decimal montoCuota = Convert.ToDecimal(fila["MontoCuota"]);
                decimal montoMora = Convert.ToDecimal(fila["MontoMora"]);
                decimal montoPagado = (pagada && fila["MontoPagado"] != DBNull.Value)
                                        ? Convert.ToDecimal(fila["MontoPagado"])
                                        : 0m;
                decimal pagoPendiente = (!pagada && !anulada) ? montoCuota : 0m;

                string fechaPago = (pagada && fila["FechaPago"] != DBNull.Value)
                                    ? Convert.ToDateTime(fila["FechaPago"]).ToString("dd/MM/yyyy")
                                    : "-";

                string observaciones;
                if (pagada)
                    observaciones = fila["NumeroRecibo"] != DBNull.Value
                                        ? $"Pago registrado (Recibo {fila["NumeroRecibo"]})"
                                        : "Pago registrado";
                else if (anulada)
                    observaciones = "Pago anulado";
                else
                    observaciones = "Pago no realizado";

                DataRow filaVisual = dtVisual.NewRow();
                filaVisual["Fecha de Pago"] = fechaPago;
                filaVisual["Periodo Cubierto"] = FormatearPeriodo(fila["PeriodoCorrespondiente"]);
                filaVisual["Monto Pagado"] = "L. " + montoPagado.ToString("N2");
                filaVisual["Pago Pendiente"] = "L. " + pagoPendiente.ToString("N2");
                filaVisual["Mora Acumulada"] = "L. " + montoMora.ToString("N2");
                filaVisual["Estado"] = estado;
                filaVisual["Observaciones"] = observaciones;
                dtVisual.Rows.Add(filaVisual);
            }

            dataGridView1.DataSource = dtVisual;

            // Reparte el ancho disponible entre columnas (Observaciones y Periodo un poco más anchas)
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Fecha de Pago"].FillWeight = 90;
                dataGridView1.Columns["Periodo Cubierto"].FillWeight = 110;
                dataGridView1.Columns["Monto Pagado"].FillWeight = 100;
                dataGridView1.Columns["Pago Pendiente"].FillWeight = 100;
                dataGridView1.Columns["Mora Acumulada"].FillWeight = 100;
                dataGridView1.Columns["Estado"].FillWeight = 80;
                dataGridView1.Columns["Observaciones"].FillWeight = 160;
            }

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (col.Name != "Observaciones")
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // Convierte la fecha del período (ej. 2026-07-01) a un texto legible ("Julio 2026")
        private string FormatearPeriodo(object periodo)
        {
            if (periodo == null || periodo == DBNull.Value) return string.Empty;

            DateTime fecha = Convert.ToDateTime(periodo);
            string mes = fecha.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));
            mes = char.ToUpper(mes[0]) + mes.Substring(1);
            return $"{mes} {fecha.Year}";
        }

        // Calcula y muestra los totales del resumen del estado de cuenta
        private void ActualizarResumen(DataTable dtHistorial)
        {
            decimal totalPagadoValor = 0m;
            decimal totalPendienteValor = 0m;

            foreach (DataRow fila in dtHistorial.Rows)
            {
                string estado = fila["Estado"].ToString();
                bool pagada = estado.StartsWith("Pagad", StringComparison.OrdinalIgnoreCase);
                bool anulada = estado.Equals("Anulada", StringComparison.OrdinalIgnoreCase);

                decimal montoCuota = Convert.ToDecimal(fila["MontoCuota"]);
                decimal montoMora = Convert.ToDecimal(fila["MontoMora"]);

                if (pagada && fila["MontoPagado"] != DBNull.Value)
                    totalPagadoValor += Convert.ToDecimal(fila["MontoPagado"]);
                else if (!anulada)
                    totalPendienteValor += montoCuota + montoMora;
            }

            totalPagado.Text = "L. " + totalPagadoValor.ToString("N2");
            totalPendiente.Text = "L. " + totalPendienteValor.ToString("N2");

            bool enMora = totalPendienteValor > 0;
            estadoGeneral.Text = enMora ? "EN MORA" : "AL DÍA";
            estadoGeneral.ForeColor = enMora ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        // Limpia el reporte cuando no se encuentran resultados en la búsqueda
        private void LimpiarReporte()
        {
            Nombre.Text = string.Empty;
            Propiedad.Text = string.Empty;
            nContrato.Text = string.Empty;
            fechaInicio.Text = string.Empty;
            fechaVencimiento.Text = string.Empty;
            montoMensual.Text = string.Empty;
            totalPagado.Text = string.Empty;
            totalPendiente.Text = string.Empty;
            estadoGeneral.Text = string.Empty;
            estadoGeneral.ForeColor = SystemColors.ControlText;
            dataGridView1.DataSource = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            filtroNombre.Clear();

            cbxContrato.DataSource = null;
            cbxContrato.Items.Clear();

            idContratoActual = 0;
            LimpiarReporte();

            filtroNombre.Focus();
        }

        private void EstadoCuentaArrendatario_Load(object sender, EventArgs e)
        {
            filtroNombre.Clear();

            cbxContrato.DataSource = null;
            cbxContrato.Items.Clear();

            idContratoActual = 0;
            LimpiarReporte();

            filtroNombre.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (idContratoActual == 0)
            {
                MessageBox.Show("Seleccione un contrato primero para imprimir su estado de cuenta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                sfd.FileName = $"EstadoCuenta_{Nombre.Text.Replace(" ", "")}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GenerarPdfEstadoCuenta(sfd.FileName, dt);
                        MessageBox.Show("Estado de cuenta generado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(
                            "No se pudo guardar el archivo porque está abierto en otro programa. Ciérrelo e intente de nuevo.",
                            "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void GenerarPdfEstadoCuenta(string rutaArchivo, DataTable dt)
        {
            PdfWriter writer = new PdfWriter(rutaArchivo);
            PdfDocument pdf = new PdfDocument(writer);
            Document documento = new Document(pdf, PageSize.LETTER.Rotate());

            try
            {
                documento.SetMargins(20, 25, 40, 25);

                PdfFont fontRegular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                documento.SetFont(fontRegular);

                float[] anchoEncabezado = { 1.3f, 5f, 2f };
                Table tablaEncabezado = new Table(UnitValue.CreatePercentArray(anchoEncabezado)).UseAllAvailableWidth();
                tablaEncabezado.SetBackgroundColor(new DeviceRgb(0xD6, 0x79, 0x31));
                tablaEncabezado.SetBorder(Border.NO_BORDER);

                Cell celdaLogo = new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetPadding(6);

                if (File.Exists(RutaLogo))
                {
                    iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(RutaLogo));
                    logo.SetWidth(45).SetAutoScaleHeight(true);
                    celdaLogo.Add(logo);
                }
                else
                {
                    celdaLogo.Add(new Paragraph(""));
                }

                Cell celdaTitulo = new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetPadding(8)
                    .Add(new Paragraph("ESTADO DE CUENTA POR ARRENDATARIO")
                        .SetFont(fontBold)
                        .SetFontSize(14)
                        .SetFontColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetMargin(0));

                Paragraph parrafoFecha = new Paragraph()
                    .Add(new Text("Fecha: ").SetFont(fontBold))
                    .Add(new Text(DateTime.Now.ToString("dd/MM/yyyy")).SetFont(fontRegular))
                    .Add(new Text("\nHora: ").SetFont(fontBold))
                    .Add(new Text(DateTime.Now.ToString("hh:mm tt")).SetFont(fontRegular))
                    .SetFontSize(9)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetMargin(0);

                Cell celdaFecha = new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetPadding(8)
                    .Add(parrafoFecha);

                tablaEncabezado.AddCell(celdaLogo);
                tablaEncabezado.AddCell(celdaTitulo);
                tablaEncabezado.AddCell(celdaFecha);
                documento.Add(tablaEncabezado);

                documento.Add(new Paragraph("\n"));

                Table infoTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 3, 1, 2 })).UseAllAvailableWidth();
                infoTable.SetMarginBottom(10);

                infoTable.AddCell(new Cell().Add(new Paragraph("Arrendatario:").SetFont(fontBold)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph(Nombre.Text)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph("Propiedad:").SetFont(fontBold)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph(Propiedad.Text)).SetBorder(Border.NO_BORDER));

                infoTable.AddCell(new Cell().Add(new Paragraph("Nº Contrato:").SetFont(fontBold)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph(nContrato.Text)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph("Monto Mensual:").SetFont(fontBold)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph(montoMensual.Text)).SetBorder(Border.NO_BORDER));

                infoTable.AddCell(new Cell().Add(new Paragraph("Inicio:").SetFont(fontBold)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph(fechaInicio.Text)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph("Vencimiento:").SetFont(fontBold)).SetBorder(Border.NO_BORDER));
                infoTable.AddCell(new Cell().Add(new Paragraph(fechaVencimiento.Text)).SetBorder(Border.NO_BORDER));

                documento.Add(infoTable);

                float[] anchoColumnas = { 2, 2, 2, 2, 2, 2, 3 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchoColumnas)).UseAllAvailableWidth();

                string[] encabezados = { "Fecha de Pago", "Periodo Cubierto", "Monto Pagado", "Pago Pendiente", "Mora Acumulada", "Estado", "Observaciones" };
                foreach (var encabezado in encabezados)
                {
                    Cell celda = new Cell()
                        .Add(new Paragraph(encabezado).SetFont(fontBold).SetFontColor(ColorConstants.WHITE).SetFontSize(9))
                        .SetBackgroundColor(new DeviceRgb(0xD6, 0x79, 0x31))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(6);
                    tabla.AddHeaderCell(celda);
                }

                foreach (DataRow fila in dt.Rows)
                {
                    tabla.AddCell(CeldaTexto(fila["Fecha de Pago"].ToString(), fontRegular));
                    tabla.AddCell(CeldaTexto(fila["Periodo Cubierto"].ToString(), fontRegular));
                    tabla.AddCell(CeldaTexto(fila["Monto Pagado"].ToString(), fontRegular, TextAlignment.RIGHT));
                    tabla.AddCell(CeldaTexto(fila["Pago Pendiente"].ToString(), fontRegular, TextAlignment.RIGHT));
                    tabla.AddCell(CeldaTexto(fila["Mora Acumulada"].ToString(), fontRegular, TextAlignment.RIGHT));

                    string estado = fila["Estado"].ToString();
                    Cell celdaEstado = new Cell()
                        .Add(new Paragraph(estado).SetFont(fontBold).SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(4);

                    switch (estado.Trim().ToLower())
                    {
                        case "pagada":
                        case "pagado":
                            celdaEstado.SetBackgroundColor(new DeviceRgb(0xD4, 0xED, 0xDA)).SetFontColor(new DeviceRgb(0x15, 0x57, 0x24));
                            break;
                        case "en mora":
                            celdaEstado.SetBackgroundColor(new DeviceRgb(0xF8, 0xD7, 0xDA)).SetFontColor(new DeviceRgb(0x72, 0x1C, 0x24));
                            break;
                        case "pendiente":
                            celdaEstado.SetBackgroundColor(new DeviceRgb(0xFF, 0xF3, 0xCD)).SetFontColor(new DeviceRgb(0x85, 0x64, 0x04));
                            break;
                    }
                    tabla.AddCell(celdaEstado);

                    tabla.AddCell(CeldaTexto(fila["Observaciones"].ToString(), fontRegular, TextAlignment.LEFT));
                }

                documento.Add(tabla);

                documento.Add(new Paragraph($"\nResumen: Total Pagado {totalPagado.Text}  |  Total Pendiente {totalPendiente.Text}  |  Estado: {estadoGeneral.Text}")
                    .SetFont(fontBold).SetFontSize(10).SetTextAlignment(TextAlignment.RIGHT).SetMarginTop(10));

                int totalPaginas = pdf.GetNumberOfPages();
                for (int i = 1; i <= totalPaginas; i++)
                {
                    PdfPage pagina = pdf.GetPage(i);
                    iText.Kernel.Geom.Rectangle tamano = pagina.GetPageSize();
                    PdfCanvas pdfCanvas = new PdfCanvas(pagina);
                    Canvas canvas = new Canvas(pdfCanvas, tamano);
                    canvas.ShowTextAligned(
                        new Paragraph($"Página {i} de {totalPaginas}")
                            .SetFont(fontRegular).SetFontSize(8).SetFontColor(ColorConstants.GRAY),
                        tamano.GetWidth() - 25, 15, TextAlignment.RIGHT);
                    canvas.Close();
                }
            }
            finally
            {
                documento.Close();
            }
        }
        private Cell CeldaTexto(string texto, PdfFont fuente, TextAlignment alineacion = TextAlignment.CENTER)
        {
            return new Cell()
                .Add(new Paragraph(texto).SetFont(fuente))
                .SetTextAlignment(alineacion)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetPadding(4)
                .SetFontSize(9);
        }
    }
}