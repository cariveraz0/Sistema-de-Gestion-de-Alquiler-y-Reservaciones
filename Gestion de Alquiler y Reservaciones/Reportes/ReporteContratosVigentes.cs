using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

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
    public partial class ReporteContratosVigentes : ReporteBase
    {
        // ---------- CAMPOS PARA PAGINACIÓN ----------
        private DataTable dtCompleto;          // guarda TODOS los datos que trajo la consulta
        private int paginaActual = 0;
        private const int FilasPorPagina = 10;

        // Ruta del logo. Ajusta esto a una ruta relativa al ejecutable en vez
        // de una ruta absoluta de tu máquina, para que funcione en las
        // computadoras de tus compañeros también (ver nota al final).
        private static readonly string RutaLogo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "LogoFinal2.png");

        public ReporteContratosVigentes()
        {
            InitializeComponent();
            ConfigurarDataGridView(dgvContratos);
            CargarDatosContratos();
        }

        public void ConfigurarDataGridView(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D67931");
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeight = 40;

            grid.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8F9FA");
            grid.RowsDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Regular);
            grid.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);

            grid.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E2E6EA");
            grid.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = ColorTranslator.FromHtml("#E0E0E0");
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void CargarDatosContratos()
        {
            string query = @"
        SELECT
            cl.NombreCompleto      AS Arrendatario,
            p.Codigo               AS Propiedad,
            c.FechaInicio          AS [Fecha Inicio],
            c.FechaFin             AS [Fecha Vencimiento],
            c.MontoMensual         AS [Monto Mensual],
            ec.Nombre              AS Estado
        FROM Contratos c
        INNER JOIN Clientes cl        ON cl.IdCliente = c.IdArrendatario
        INNER JOIN Propiedades p      ON p.IdPropiedad = c.IdPropiedad
        INNER JOIN EstadosContrato ec ON ec.IdEstadoContrato = c.IdEstadoContrato
        WHERE ec.Nombre IN ('Vigente', 'Por Vencer')
        ORDER BY c.FechaFin ASC;";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    dtCompleto = new DataTable();
                    adaptador.Fill(dtCompleto);
                }

                paginaActual = 0;
                MostrarPagina(paginaActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los contratos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPagina(int numeroPagina)
        {
            if (dtCompleto == null) return;

            int totalFilas = dtCompleto.Rows.Count;
            int totalPaginas = (int)Math.Ceiling(totalFilas / (double)FilasPorPagina);
            if (totalPaginas == 0) totalPaginas = 1;

            if (numeroPagina < 0) numeroPagina = 0;
            if (numeroPagina > totalPaginas - 1) numeroPagina = totalPaginas - 1;
            paginaActual = numeroPagina;

            var filasPagina = dtCompleto.AsEnumerable()
                .Skip(paginaActual * FilasPorPagina)
                .Take(FilasPorPagina);

            DataTable dtPagina = dtCompleto.Clone();
            foreach (var fila in filasPagina)
            {
                dtPagina.ImportRow(fila);
            }

            dgvContratos.DataSource = dtPagina;

            AplicarEstilosColumnas(dgvContratos);

            lblPagina.Text = $"Página {paginaActual + 1} de {totalPaginas}";

            btnPaginaAnterior.Enabled = paginaActual > 0;
            btnPaginaSiguiente.Enabled = paginaActual < totalPaginas - 1;
        }

        private void AplicarEstilosColumnas(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Arrendatario"] != null)
                grid.Columns["Arrendatario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Propiedad"] != null)
                grid.Columns["Propiedad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Fecha Inicio"] != null)
                grid.Columns["Fecha Inicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Fecha Vencimiento"] != null)
                grid.Columns["Fecha Vencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Estado"] != null)
                grid.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Monto Mensual"] != null)
            {
                grid.Columns["Monto Mensual"].DefaultCellStyle.Format = "C2";
                grid.Columns["Monto Mensual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        // ---------- BOTONES DE PAGINACIÓN ----------

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            MostrarPagina(paginaActual - 1);
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            MostrarPagina(paginaActual + 1);
        }

        // ---------- EXPORTAR A PDF ----------

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtCompleto == null || dtCompleto.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                sfd.FileName = $"ReporteContratos_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GenerarPdfContratos(sfd.FileName);
                        MessageBox.Show("Reporte generado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(
                            "No se pudo guardar el archivo porque está abierto en otro programa (por ejemplo, su lector de PDF). Ciérrelo e intente de nuevo.",
                            "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Genera el PDF en tamaño carta con TODOS los contratos, con
        /// encabezado alineado (logo + título recuadrado + fecha/hora),
        /// negritas reales con fuentes bold y numeración de página al pie.
        /// </summary>
        private void GenerarPdfContratos(string rutaArchivo)
        {
            // OJO: no envolver PdfWriter/PdfDocument en "using". Document.Close()
            // ya cierra en cascada PdfDocument y PdfWriter; si el "using" los
            // vuelve a cerrar, se produce un doble cierre que revienta con
            // "Unknown PdfException" y deja el archivo bloqueado.
            PdfWriter writer = new PdfWriter(rutaArchivo);
            PdfDocument pdf = new PdfDocument(writer);
            Document documento = new Document(pdf, PageSize.LETTER);

            try
            {
                documento.SetMargins(20, 25, 40, 25);

                // ---------- FUENTES ----------
                PdfFont fontRegular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                documento.SetFont(fontRegular);

                // ---------- ENCABEZADO ----------
                // 3 columnas: logo (ancho fijo) | título recuadrado (centrado) | fecha/hora (der.)
                // Todas con VerticalAlignment.MIDDLE para que todo quede alineado
                // sobre la misma línea horizontal, sin importar la altura del logo.
                float[] anchoEncabezado = { 1.3f, 5f, 2f };
                Table tablaEncabezado = new Table(UnitValue.CreatePercentArray(anchoEncabezado)).UseAllAvailableWidth();
                tablaEncabezado.SetBackgroundColor(new DeviceRgb(0xD6, 0x79, 0x31));
                tablaEncabezado.SetBorder(Border.NO_BORDER);

                // --- Celda del logo ---
                Cell celdaLogo = new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetPadding(6);

                if (File.Exists(RutaLogo))
                {
                    iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(RutaLogo));
                    logo.SetWidth(45).SetAutoScaleHeight(true); // ancho fijo, alto proporcional
                    celdaLogo.Add(logo);
                }
                else
                {
                    // Si no encuentra el logo no revienta el reporte, solo deja el espacio en blanco.
                    celdaLogo.Add(new Paragraph(""));
                }

                // --- Celda del título, recuadrada en blanco para que resalte sobre el naranja ---
                Cell celdaTitulo = new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetPadding(8)
                    .Add(new Paragraph("REPORTE DE CONTRATOS VIGENTES Y SU ESTADO")
                        .SetFont(fontBold)
                        .SetFontSize(14)
                        .SetFontColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetMargin(0)
                        .SetMarginLeft(50));

                // --- Celda de fecha/hora, etiquetas en bold y valores en regular ---
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
                documento.Add(new Paragraph("\n").SetMargin(0));

                // ---------- TABLA DE DATOS ----------
                float[] anchoColumnas = { 3, 2, 2, 2, 2, 2 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchoColumnas)).UseAllAvailableWidth();

                string[] encabezados = { "Arrendatario", "Propiedad", "Fecha Inicio", "Fecha Vencimiento", "Monto Mensual", "Estado" };
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
                    tabla.AddCell(CeldaTexto(fila["Arrendatario"].ToString(), fontRegular));
                    tabla.AddCell(CeldaTexto(fila["Propiedad"].ToString(), fontRegular));
                    tabla.AddCell(CeldaTexto(Convert.ToDateTime(fila["Fecha Inicio"]).ToString("dd/MM/yyyy"), fontRegular));
                    tabla.AddCell(CeldaTexto(Convert.ToDateTime(fila["Fecha Vencimiento"]).ToString("dd/MM/yyyy"), fontRegular));
                    tabla.AddCell(CeldaTexto(Convert.ToDecimal(fila["Monto Mensual"]).ToString("C2"), fontRegular, TextAlignment.RIGHT));

                    string estado = fila["Estado"].ToString();
                    Cell celdaEstado = new Cell()
                        .Add(new Paragraph(estado).SetFont(fontBold).SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(4);

                    switch (estado.Trim().ToLower())
                    {
                        case "vigente":
                            celdaEstado.SetBackgroundColor(new DeviceRgb(0xD4, 0xED, 0xDA)).SetFontColor(new DeviceRgb(0x15, 0x57, 0x24));
                            break;
                        case "por vencer":
                            celdaEstado.SetBackgroundColor(new DeviceRgb(0xFF, 0xF3, 0xCD)).SetFontColor(new DeviceRgb(0x85, 0x64, 0x04));
                            break;
                        case "finalizado":
                            celdaEstado.SetBackgroundColor(new DeviceRgb(0xCC, 0xE5, 0xFF)).SetFontColor(new DeviceRgb(0x00, 0x40, 0x85));
                            break;
                        case "cancelado":
                            celdaEstado.SetBackgroundColor(new DeviceRgb(0xF8, 0xD7, 0xDA)).SetFontColor(new DeviceRgb(0x72, 0x1C, 0x24));
                            break;
                    }

                    tabla.AddCell(celdaEstado);
                }

                documento.Add(tabla);

                documento.Add(new Paragraph($"\nTotal de contratos: {dtCompleto.Rows.Count}")
                    .SetFont(fontBold)
                    .SetFontSize(9)
                    .SetTextAlignment(TextAlignment.RIGHT));

                // ---------- NUMERACIÓN DE PÁGINAS ----------
                // Se hace DESPUÉS de agregar todo el contenido, porque solo hasta
                // ahora se sabe cuántas páginas ocupó la tabla completa. Se
                // recorre cada página ya generada y se dibuja "Página X de N"
                // directamente sobre su canvas, en la esquina inferior derecha.
                int totalPaginas = pdf.GetNumberOfPages();
                for (int i = 1; i <= totalPaginas; i++)
                {
                    PdfPage pagina = pdf.GetPage(i);
                    iText.Kernel.Geom.Rectangle tamano = pagina.GetPageSize();

                    PdfCanvas pdfCanvas = new PdfCanvas(pagina);
                    Canvas canvas = new Canvas(pdfCanvas, tamano);

                    canvas.ShowTextAligned(
                        new Paragraph($"Página {i} de {totalPaginas}")
                            .SetFont(fontRegular)
                            .SetFontSize(8)
                            .SetFontColor(ColorConstants.GRAY),
                        tamano.GetWidth() - 25,
                        15,
                        TextAlignment.RIGHT);

                    canvas.Close();
                }
            }
            finally
            {
                // Único punto de cierre. Se ejecuta incluso si algo falla arriba,
                // así el archivo nunca se queda con el candado puesto.
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

        // ---------- FORMATO CONDICIONAL DE LA COLUMNA ESTADO EN PANTALLA ----------

        private void dgvContratos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvContratos.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim().ToLower();

                switch (estado)
                {
                    case "vigente":
                        e.CellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                        break;

                    case "por vencer":
                        e.CellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                        break;

                    case "finalizado":
                        e.CellStyle.BackColor = ColorTranslator.FromHtml("#CCE5FF");
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#004085");
                        break;

                    case "cancelado":
                        e.CellStyle.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                        break;
                }

                e.CellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);
            }
        }
    }
}

