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
    public partial class ReporteReservacionesPeriodo : ReporteBase
    {
        private DataGridView dgvReservaciones;
        private Label lblTotal, lblConfirmadas, lblFinalizadas, lblPendientes, lblCanceladas, lblMontoTotal;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private DataTable dtCompleto;
        private static readonly string RutaLogo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "LogoFinal2.png");

        public ReporteReservacionesPeriodo()
    :       this(new DateTime(2026, 6, 1), new DateTime(2026, 6, 30))
        {
        }

        public ReporteReservacionesPeriodo(DateTime inicio, DateTime fin)
        {
            fechaInicio = inicio;
            fechaFin = fin;

            InitializeComponent();
            CrearControlesReporte();
            CargarReporteReservaciones();

            dgvReservaciones.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvReservaciones_CellFormatting);
        }

        private void CrearControlesReporte()
        {
            System.Drawing.Color naranjaTitulo = System.Drawing.Color.FromArgb(216, 122, 45);

            Label lblPeriodo = new Label();
            lblPeriodo.Text = $"PERIODO CONSULTADO: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}";
            lblPeriodo.Location = new System.Drawing.Point(60, 20);
            lblPeriodo.Size = new Size(860, 25);
            lblPeriodo.BackColor = naranjaTitulo;
            lblPeriodo.ForeColor = System.Drawing.Color.White;
            lblPeriodo.Font = new Font("Montserrat", 10, FontStyle.Bold);
            lblPeriodo.TextAlign = ContentAlignment.MiddleCenter;
            pnlPrincipal.Controls.Add(lblPeriodo);

            dgvReservaciones = new DataGridView();
            dgvReservaciones.Location = new System.Drawing.Point(60, 55);
            dgvReservaciones.Size = new Size(860, 190); // Altura ligeramente ajustada para que quepa todo
            dgvReservaciones.RowHeadersVisible = false;
            dgvReservaciones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReservaciones.RowTemplate.Height = 28;
            dgvReservaciones.ReadOnly = true;
            dgvReservaciones.AllowUserToAddRows = false;
            dgvReservaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservaciones.BackgroundColor = System.Drawing.Color.White;
            dgvReservaciones.EnableHeadersVisualStyles = false;
            dgvReservaciones.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvReservaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);
            dgvReservaciones.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            dgvReservaciones.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
            dgvReservaciones.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            pnlPrincipal.Controls.Add(dgvReservaciones);

            Panel pnlResumen = new Panel();
            pnlResumen.Location = new System.Drawing.Point(60, 260);
            pnlResumen.Size = new Size(860, 85);
            pnlResumen.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            pnlPrincipal.Controls.Add(pnlResumen);

            Label lblTituloResumen = new Label();
            lblTituloResumen.Text = "RESUMEN DEL PERIODO";
            lblTituloResumen.Location = new System.Drawing.Point(0, 0);
            lblTituloResumen.Size = new Size(860, 25);
            lblTituloResumen.BackColor = naranjaTitulo;
            lblTituloResumen.ForeColor = System.Drawing.Color.White;
            lblTituloResumen.Font = new Font("Montserrat", 9, FontStyle.Bold);
            lblTituloResumen.TextAlign = ContentAlignment.MiddleCenter;
            pnlResumen.Controls.Add(lblTituloResumen);

            lblTotal = CrearLabelResumen("TOTAL:\n0", 0, 110);
            lblConfirmadas = CrearLabelResumen("CONFIRMADAS:\n0", 135, 125);
            lblFinalizadas = CrearLabelResumen("FINALIZADAS:\n0", 275, 125);
            lblPendientes = CrearLabelResumen("PENDIENTES:\n0", 415, 125);
            lblCanceladas = CrearLabelResumen("CANCELADAS:\n0", 555, 125);
            lblMontoTotal = CrearLabelResumen("TOTAL MONTO:\nL. 0.00", 690, 150);

            pnlResumen.Controls.Add(lblTotal);
            pnlResumen.Controls.Add(lblConfirmadas);
            pnlResumen.Controls.Add(lblFinalizadas);
            pnlResumen.Controls.Add(lblPendientes);
            pnlResumen.Controls.Add(lblCanceladas);
            pnlResumen.Controls.Add(lblMontoTotal);

            Label lblNota = new Label();
            lblNota.Text = "Nota: Este reporte incluye todas las reservaciones realizadas dentro del rango de fechas seleccionado.";
            lblNota.Location = new System.Drawing.Point(60, 360);
            lblNota.Size = new Size(860, 22);
            lblNota.Font = new Font("Montserrat", 9, FontStyle.Bold);
            lblNota.ForeColor = System.Drawing.Color.Black;
            lblNota.TextAlign = ContentAlignment.MiddleLeft;
            pnlPrincipal.Controls.Add(lblNota);

            Button btnImprimir = new Button();
            btnImprimir.BackColor = System.Drawing.Color.FromArgb(214, 122, 49);
            btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Montserrat SemiBold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = System.Drawing.Color.White;
            btnImprimir.Location = new System.Drawing.Point(412, 410);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(160, 35);
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += new EventHandler(this.btnImprimir_Click);
            pnlPrincipal.Controls.Add(btnImprimir);
        }

        private Label CrearLabelResumen(string texto, int x, int ancho)
        {
            return new Label
            {
                Text = texto,
                Location = new System.Drawing.Point(x, 32),
                Size = new Size(ancho, 40),
                Font = new Font("Montserrat", 8, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private void CargarReporteReservaciones()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"
                   SELECT 
                    ROW_NUMBER() OVER (ORDER BY r.FechaEntrada) AS [#],
                    c.NombreCompleto AS [Cliente],
                    p.Codigo AS [Espacio Reservado],
                FORMAT(r.FechaEntrada, 'dd/MM/yyyy') AS [Fecha de Reserva],
                 CASE 
                    WHEN CAST(r.FechaEntrada AS DATE) = CAST(r.FechaSalida AS DATE)
                    THEN FORMAT(r.FechaEntrada, 'hh:mm tt') + ' - ' + FORMAT(r.FechaSalida, 'hh:mm tt')
                       ELSE FORMAT(r.FechaEntrada, 'dd/MM/yyyy') + ' - ' + FORMAT(r.FechaSalida, 'dd/MM/yyyy')
                    END AS [Hora / Día],
                    CASE 
                    WHEN er.Nombre = 'Completada' THEN 'Finalizada'
                       ELSE er.Nombre
                 END AS [Estado],
                'L. ' + FORMAT(r.MontoTotal, 'N2') AS [Monto Cobrado],
                 r.MontoTotal
                FROM Reservaciones r
               INNER JOIN Clientes c ON r.IdCliente = c.IdCliente
                INNER JOIN Propiedades p ON r.IdPropiedad = p.IdPropiedad
                    INNER JOIN EstadosReservacion er ON r.IdEstadoReservacion = er.IdEstadoReservacion
                WHERE r.FechaEntrada >= @FechaInicio
                AND r.FechaEntrada < DATEADD(DAY, 1, @FechaFin)
                ORDER BY r.FechaEntrada;
                ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtCompleto = dt;

                dgvReservaciones.RowHeadersVisible = false;
                dgvReservaciones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvReservaciones.DataBindingComplete += (s, e) =>
                {
                    if (dgvReservaciones.Columns.Count > 0 && dgvReservaciones.Columns[0] != null)
                    {
                        dgvReservaciones.Columns[0].Width = 35;
                        dgvReservaciones.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvReservaciones.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                };

                dgvReservaciones.DataSource = dt;
                dgvReservaciones.RowHeadersVisible = false;

               


                if (dgvReservaciones.Columns.Contains("MontoTotal"))
                {
                    dgvReservaciones.Columns["MontoTotal"].Visible = false;
                }

                CargarResumen(dt);
            }
        }

        private void CargarResumen(DataTable dt)
        {
            int confirmadas = 0, finalizadas = 0, pendientes = 0, canceladas = 0;
            decimal totalMonto = 0;

            foreach (DataRow row in dt.Rows)
            {
                string estado = row["Estado"].ToString();

                if (estado == "Confirmada") confirmadas++;
                else if (estado == "Finalizada") finalizadas++;
                else if (estado == "Pendiente") pendientes++;
                else if (estado == "Cancelada") canceladas++;

                totalMonto += Convert.ToDecimal(row["MontoTotal"]);
            }

            lblTotal.Text = "TOTAL:\n" + dt.Rows.Count;
            lblConfirmadas.Text = "CONFIRMADAS:\n" + confirmadas;
            lblFinalizadas.Text = "FINALIZADAS:\n" + finalizadas;
            lblPendientes.Text = "PENDIENTES:\n" + pendientes;
            lblCanceladas.Text = "CANCELADAS:\n" + canceladas;
            lblMontoTotal.Text = "TOTAL MONTO:\nL. " + totalMonto.ToString("N2");
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtCompleto == null || dtCompleto.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para imprimir.", 
                    "Aviso.", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                sfd.FileName = $"ReporteReservaciones_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GenerarPdfReservaciones(sfd.FileName);

                        var abrir = MessageBox.Show(
                            "Reporte generado correctamente. ¿Desea abrirlo ahora?",
                            "Éxito.", 
                            MessageBoxButtons.YesNo, 
                            MessageBoxIcon.Information
                        );

                        if (abrir == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName)
                            {
                                UseShellExecute = true
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error al generar el PDF: " + ex.Message, 
                            "Error.", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void GenerarPdfReservaciones(string rutaArchivo)
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
                    .Add(new Paragraph("REPORTE DE RESERVACIONES POR PERÍODO")
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
                documento.Add(new Paragraph($"Periodo Consultado: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}\n\n")
                    .SetFont(fontBold).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetMargin(0));

                float[] anchoColumnas = {3, 2, 2, 3, 2, 2};
                Table tabla = new Table(UnitValue.CreatePercentArray(anchoColumnas)).UseAllAvailableWidth();

                string[] encabezados = {"Cliente", "Espacio Reservado", "Fecha de Reserva", "Hora / Día", "Estado", "Monto Cobrado" };
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

                foreach (DataRow fila in dtCompleto.Rows)
                {
                    tabla.AddCell(CeldaTexto(fila["Cliente"].ToString(), fontRegular, TextAlignment.LEFT));
                    tabla.AddCell(CeldaTexto(fila["Espacio Reservado"].ToString(), fontRegular));
                    tabla.AddCell(CeldaTexto(fila["Fecha de Reserva"].ToString(), fontRegular));
                    tabla.AddCell(CeldaTexto(fila["Hora / Día"].ToString(), fontRegular));

                    string estado = fila["Estado"].ToString();
                    Cell celdaEstado = new Cell()
                        .Add(new Paragraph(estado).SetFont(fontBold).SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(4);

                    switch (estado.Trim().ToLower())
                    {
                        case "confirmada":
                            celdaEstado.SetFontColor(new DeviceRgb(0x15, 0x57, 0x24));
                            break;
                        case "finalizada":
                            celdaEstado.SetFontColor(new DeviceRgb(0x00, 0x40, 0x85));
                            break;
                        case "pendiente":
                            celdaEstado.SetFontColor(new DeviceRgb(0x85, 0x64, 0x04));
                            break;
                        case "cancelada":
                            celdaEstado.SetFontColor(new DeviceRgb(0x72, 0x1C, 0x24));
                            break;
                    }
                    tabla.AddCell(celdaEstado);

                    tabla.AddCell(CeldaTexto(fila["Monto Cobrado"].ToString(), fontRegular, TextAlignment.RIGHT));
                }

                //documento.Add(new Paragraph($"\nTotal de reservaciones: {dtCompleto.Rows.Count}")
                //    .SetFont(fontBold)
                //    .SetFontSize(9)
                //    .SetTextAlignment(TextAlignment.RIGHT));

                documento.Add(tabla);

                // Numeración de páginas
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
        private void dgvReservaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvReservaciones.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim().ToLower();

                switch (estado)
                {
                    case "confirmada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                        break;

                    case "pendiente":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                        break;

                    case "finalizada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#004085");
                        break;

                    case "cancelada":
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                        break;
                }

                // Aplicamos la fuente en negrita
                e.CellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);
            }
        }
    }
}
