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

using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Canvas;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class HistorialMantenimientoPropiedad : ReporteBase
    {
        private DataTable dtCompleto;
        private int paginaActual = 0;
        private const int FilasPorPagina = 10;

        private static readonly string RutaLogo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Images", "LogoFinal2.png");

        private string propiedadSeleccionadaTexto = string.Empty;
        public HistorialMantenimientoPropiedad()
        {
            InitializeComponent();
            ConfigurarDataGridView(dgvMantenimiento);
            CargarComboPropiedades();

            cboPropiedades.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void CargarComboPropiedades()
        {
            string query = @"
        SELECT
            p.IdPropiedad,
            p.Codigo + ' - ' + p.Direccion AS Descripcion
        FROM Propiedades p
        ORDER BY p.Codigo;";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    DataTable dtPropiedades = new DataTable();
                    adaptador.Fill(dtPropiedades);

                    cboPropiedades.DisplayMember = "Descripcion";
                    cboPropiedades.ValueMember = "IdPropiedad";
                    cboPropiedades.DataSource = dtPropiedades;
                }

                // Si hay al menos una propiedad, dispara la carga del historial
                // (el SelectedIndexChanged ya se encarga de llamar a CargarHistorial)
                if (cboPropiedades.Items.Count == 0)
                {
                    dtCompleto = null;
                    dgvMantenimiento.DataSource = null;
                    lblPagina.Text = "Sin propiedades registradas";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las propiedades: " + ex.Message, 
                    "Error de datos.", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        private void cboPropiedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPropiedades.SelectedValue == null || cboPropiedades.SelectedValue is DBNull)
                return;

            string idPropiedad = cboPropiedades.SelectedValue.ToString();
            propiedadSeleccionadaTexto = cboPropiedades.Text;

            CargarHistorialMantenimiento(idPropiedad);
        }

        private void CargarHistorialMantenimiento(string idPropiedad)
        {
            // Se ajustaron los alias para que coincidan exactamente con lo que espera el PDF y el DataGridView
            string query = @"
        SELECT 
            m.NumeroOrden AS [Número de Orden],
            tm.Nombre AS [Tipo],
            e.NombreCompleto AS [Técnico Asignado],
            m.Descripcion AS [Descripción del Problema],
            m.FechaSolicitud AS [Fecha Reporte],
            m.FechaProgramada AS [Fecha Programada],
            m.FechaConclusion AS [Conclusión],
            m.Costo AS [Costo],
            em.Nombre AS [Estado]
        FROM Mantenimiento m
        INNER JOIN TiposMantenimiento tm ON m.IdTipoMantenimiento = tm.IdTipoMantenimiento
        INNER JOIN EstadosMantenimiento em ON m.IdEstadoMantenimiento = em.IdEstadoMantenimiento
        LEFT JOIN Empleado e ON m.IdTecnicoAsignado = e.IdEmpleado
        WHERE m.IdPropiedad = @IdPropiedad
        ORDER BY m.FechaSolicitud DESC";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    dtCompleto = new DataTable();
                    adapter.Fill(dtCompleto);

                    //dgvMantenimiento.DataSource = dtCompleto;
                    MostrarPagina(0);
                }
            }
        }
        private void MostrarPagina(int numeroPagina)
        {
            if (dtCompleto == null)
            {
                dgvMantenimiento.DataSource = null;
                lblPagina.Text = "Sin registros";
                return;
            }

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

            dgvMantenimiento.DataSource = dtPagina;

            AplicarEstilosColumnas(dgvMantenimiento);

            if (totalFilas == 0)
            {
                lblPagina.Text = "Página 0 de 0";
            }
            else
            {
                lblPagina.Text = $"Página {paginaActual + 1} de {totalPaginas}";
            }

            //btnPaginaAnterior.Enabled = paginaActual > 0;
            //btnPaginaSiguiente.Enabled = paginaActual < totalPaginas - 1;
        }
        private void AplicarEstilosColumnas(DataGridView grid)
        {
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Fecha Reporte"] != null)
                grid.Columns["Fecha Reporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Descripción del Problema"] != null)
            {
                grid.Columns["Descripción del Problema"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grid.Columns["Descripción del Problema"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            if (grid.Columns["Técnico Asignado"] != null)
                grid.Columns["Técnico Asignado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Conclusión"] != null)
                grid.Columns["Conclusión"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Estado"] != null)
                grid.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (grid.Columns["Costo"] != null)
            {
                grid.Columns["Costo"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-HN");
                grid.Columns["Costo"].DefaultCellStyle.Format = "C2";
                grid.Columns["Costo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //grid.Columns["Costo"].DefaultCellStyle.NullValue = "—";
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtCompleto == null || dtCompleto.Rows.Count == 0)
            {
                if (dtCompleto == null || dtCompleto.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay órdenes de mantenimiento para imprimir en esta propiedad.", 
                        "Aviso.", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    sfd.FileName = $"HistorialMantenimiento_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            GenerarPdfHistorial(sfd.FileName);

                            MessageBox.Show(
                                "Reporte generado y guardado con éxito.", 
                                "Información.", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information
                            );
                        }
                        catch (IOException)
                        {
                            MessageBox.Show(
                                "No se pudo guardar el archivo porque está abierto en otro programa (por ejemplo, su lector de PDF). Ciérrelo e intente de nuevo.",
                                "Archivo en uso.", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning
                            );
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

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                sfd.FileName = $"HistorialMantenimiento_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GenerarPdfHistorial(sfd.FileName);

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
        private void GenerarPdfHistorial(string rutaArchivo)
        {
            // Sin bloque 'using' para evitar el "Unknown PdfException" por doble cierre
            PdfWriter writer = new PdfWriter(rutaArchivo);
            PdfDocument pdf = new PdfDocument(writer);
            Document documento = new Document(pdf, PageSize.LETTER);

            try
            {
                documento.SetMargins(20, 25, 40, 25);

                // Fuentes
                PdfFont fontRegular = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                documento.SetFont(fontRegular);

                // ---------- ENCABEZADO ----------
                float[] anchoEncabezado = { 1.3f, 5f, 2f };
                Table tablaEncabezado = new Table(UnitValue.CreatePercentArray(anchoEncabezado)).UseAllAvailableWidth();
                tablaEncabezado.SetBackgroundColor(new DeviceRgb(0xD6, 0x7A, 0x31));
                tablaEncabezado.SetBorder(Border.NO_BORDER);

                // Logo
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

                // Título y Subtítulo (Nombre de la propiedad)
                Paragraph pTitulo = new Paragraph("HISTORIAL DE MANTENIMIENTO")
                    .SetFont(fontBold).SetFontSize(14).SetFontColor(ColorConstants.WHITE).SetMargin(0);

                Paragraph pSubtitulo = new Paragraph($"Propiedad: {propiedadSeleccionadaTexto}")
                    .SetFont(fontRegular).SetFontSize(10).SetFontColor(ColorConstants.WHITE).SetMarginTop(2);

                Cell celdaTitulo = new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetPadding(8)
                    .Add(pTitulo)
                    .Add(pSubtitulo); // Se añade el subtítulo debajo del título principal

                // Fecha y Hora
                Paragraph parrafoFecha = new Paragraph()
                    .Add(new Text("Fecha: ").SetFont(fontBold))
                    .Add(new Text(DateTime.Now.ToString("dd/MM/yyyy")).SetFont(fontRegular))
                    .Add(new Text("\nHora: ").SetFont(fontBold))
                    .Add(new Text(DateTime.Now.ToString("hh:mm tt")).SetFont(fontRegular))
                    .SetFontSize(9).SetFontColor(ColorConstants.WHITE).SetTextAlignment(TextAlignment.RIGHT).SetMargin(0);

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
                float[] anchoColumnas = { 2, 4, 2.5f, 1.5f, 2, 2 };
                Table tabla = new Table(UnitValue.CreatePercentArray(anchoColumnas)).UseAllAvailableWidth();

                string[] encabezados = { "Fecha Reporte", "Descripción del Problema", "Técnico Asignado", "Costo", "Conclusión", "Estado" };
                foreach (var encabezado in encabezados)
                {
                    Cell celda = new Cell()
                        .Add(new Paragraph(encabezado).SetFont(fontBold).SetFontColor(ColorConstants.WHITE).SetFontSize(9))
                        .SetBackgroundColor(new DeviceRgb(0xD6, 0x7A, 0x31))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(6);
                    tabla.AddHeaderCell(celda);
                }

                foreach (DataRow fila in dtCompleto.Rows)
                {
                    tabla.AddCell(CeldaTexto(Convert.ToDateTime(fila["Fecha Reporte"]).ToString("dd/MM/yyyy"), fontRegular));
                    tabla.AddCell(CeldaTexto(fila["Descripción del Problema"].ToString(), fontRegular, TextAlignment.LEFT));

                    string tecnico = fila["Técnico Asignado"] is DBNull ? "Sin asignar" : fila["Técnico Asignado"].ToString();
                    tabla.AddCell(CeldaTexto(tecnico, fontRegular));

                    string costo = fila["Costo"] is DBNull ? "—"  : Convert.ToDecimal(fila["Costo"]).ToString("C2", System.Globalization.CultureInfo.CreateSpecificCulture("es-HN"));
                    TextAlignment alineacion = (costo == "—") ? TextAlignment.CENTER : TextAlignment.RIGHT;
                    tabla.AddCell(CeldaTexto(costo, fontRegular, alineacion));

                    // Ajuste por posible acento en la columna Conclusión según la base de datos
                    string columnaConclusion = dtCompleto.Columns.Contains("Conclusión") ? "Conclusión" : "Conclusion";
                    string conclusion = fila[columnaConclusion] is DBNull ? "—" : Convert.ToDateTime(fila[columnaConclusion]).ToString("dd/MM/yyyy");
                    tabla.AddCell(CeldaTexto(conclusion, fontRegular));

                    string estado = fila["Estado"].ToString();
                    Cell celdaEstado = new Cell()
                        .Add(new Paragraph(estado).SetFont(fontBold).SetFontSize(9))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(4);

                    switch (estado.Trim().ToLower())
                    {
                        case "pendiente":
                            celdaEstado.SetFontColor(new DeviceRgb(0x85, 0x64, 0x04));
                            break;
                        case "en proceso":
                            celdaEstado.SetFontColor(new DeviceRgb(0x00, 0x40, 0x85));
                            break;
                        case "completado":
                            celdaEstado.SetFontColor(new DeviceRgb(0x15, 0x57, 0x24));
                            break;
                        case "cancelado":
                            celdaEstado.SetFontColor(new DeviceRgb(0x72, 0x1C, 0x24));
                            break;
                    }
                    tabla.AddCell(celdaEstado);
                }

                documento.Add(tabla);

                documento.Add(new Paragraph($"\nTotal de órdenes: {dtCompleto.Rows.Count}")
                    .SetFont(fontBold)
                    .SetFontSize(9)
                    .SetTextAlignment(TextAlignment.RIGHT));

                // ---------- NUMERACIÓN DE PÁGINAS ----------
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
                // Se asegura de cerrar el documento para liberar el archivo siempre
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

        private void dgvMantenimiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvMantenimiento.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().Trim().ToLower();

                switch (estado)
                {
                    case "pendiente":
                        //e.CellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                        break;

                    case "en proceso":
                        //e.CellStyle.BackColor = ColorTranslator.FromHtml("#CCE5FF");
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#004085");
                        break;

                    case "completado":
                        //e.CellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                        break;

                    case "cancelado":
                        //e.CellStyle.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                        e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                        break;
                }

                e.CellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);
            }
        }

        private void HistorialMantenimientoPropiedad_Load(object sender, EventArgs e)
        {

        }
    }
}
