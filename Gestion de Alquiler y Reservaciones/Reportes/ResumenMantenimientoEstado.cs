using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class ResumenMantenimientoEstado : ReporteBase
    {


        //Método para cargar estados en Combobox
        public void CargarEstadosEnComboBox(ComboBox cBxEstados)
        {
            try
            {
                string query = "SELECT IdEstadoMantenimiento, Nombre FROM EstadosMantenimiento ORDER BY Nombre";

                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dtEstados = new DataTable();
                    adapter.Fill(dtEstados);

                    // Crear una fila para "Todos los estados"
                    DataRow row = dtEstados.NewRow();
                    row["IdEstadoMantenimiento"] = 0;
                    row["Nombre"] = "Todos los estados";
                    dtEstados.Rows.InsertAt(row, 0);

                    // Asignar al ComboBox
                    cBxEstados.DataSource = dtEstados;
                    cBxEstados.DisplayMember = "Nombre";
                    cBxEstados.ValueMember = "IdEstadoMantenimiento";

                    // Seleccionar "Todos" por defecto
                    cBxEstados.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método para cargar estados en Combobox
        public void CargarPropiedadesEnComboBox(ComboBox cBxPropiedades)
        {
            try
            {
                string query = "SELECT IdPropiedad, Codigo FROM Propiedades ORDER BY IdPropiedad";

                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dtEstados = new DataTable();
                    adapter.Fill(dtEstados);

                    // Crear una fila para "Todos los estados"
                    DataRow row = dtEstados.NewRow();
                    row["IdPropiedad"] = 0;
                    row["Codigo"] = "Todas las propiedades";
                    dtEstados.Rows.InsertAt(row, 0);

                    // Asignar al ComboBox
                    cBxPropiedades.DataSource = dtEstados;
                    cBxPropiedades.DisplayMember = "Codigo";
                    cBxPropiedades.ValueMember = "IdPropiedad";

                    // Seleccionar "Todos" por defecto
                    cBxPropiedades.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las propiedades: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public ResumenMantenimientoEstado()
        {
            InitializeComponent();


            // Rango por defecto: semana actual (lunes a hoy)
            dtpFin.Value = DateTime.Today;
            dtpInicio.Value = DateTime.Today.AddDays(-365);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dtDatos = ObtenerDatosFiltrados();
                ActualizarChart(dtDatos);
                ActualizarResumenEjecutivo(dtDatos);
                ActualizarDataGridView(dtDatos);

                // Subtítulo con el rango y el filtro de propiedad aplicado
                string propiedadTexto = cBxPropiedades.Text;
                lblSubtitulo.Text = $"Del {dtpInicio.Value:dd/MM/yyyy} al {dtpFin.Value:dd/MM/yyyy} - {propiedadTexto}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Obtiene las solicitudes de mantenimiento aplicando los filtros de fecha, estado y propiedad
        private DataTable ObtenerDatosFiltrados()
        {
            string query = @"
                SELECT 
                    m.IdMantenimiento,
                    m.NumeroOrden,
                    m.IdPropiedad,
                    p.Codigo AS PropiedadCodigo,
                    m.IdEstadoMantenimiento,
                    em.Nombre AS EstadoNombre,
                    m.FechaSolicitud
                FROM Mantenimiento m
                INNER JOIN Propiedades p ON p.IdPropiedad = m.IdPropiedad
                INNER JOIN EstadosMantenimiento em ON em.IdEstadoMantenimiento = m.IdEstadoMantenimiento
                WHERE m.FechaSolicitud BETWEEN @FechaInicio AND @FechaFin
                    AND (@IdEstado = 0 OR m.IdEstadoMantenimiento = @IdEstado)
                    AND (@IdPropiedad = 0 OR m.IdPropiedad = @IdPropiedad)
                ORDER BY p.Codigo";

            DataTable dt = new DataTable();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                int idEstado = cBxEstados.SelectedValue != null ? Convert.ToInt32(cBxEstados.SelectedValue) : 0;
                int idPropiedad = cBxPropiedades.SelectedValue != null ? Convert.ToInt32(cBxPropiedades.SelectedValue) : 0;

                cmd.Parameters.AddWithValue("@FechaInicio", dtpInicio.Value.Date);
                cmd.Parameters.AddWithValue("@FechaFin", dtpFin.Value.Date.AddDays(1).AddSeconds(-1));
                cmd.Parameters.AddWithValue("@IdEstado", idEstado);
                cmd.Parameters.AddWithValue("@IdPropiedad", idPropiedad);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        // Obtiene todos los estados de mantenimiento existentes (sin el placeholder "Todos los estados"),
        // ordenados por Id, para que las columnas del datagridview siempre se muestren aunque estén en 0
        private List<string> ObtenerTodosLosEstados()
        {
            List<string> estados = new List<string>();
            string query = "SELECT Nombre FROM EstadosMantenimiento ORDER BY IdEstadoMantenimiento";

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        estados.Add(reader.GetString(0));
                }
            }

            return estados;
        }




        // Llena el chart de dona con la cantidad de solicitudes por estado
        private void ActualizarChart(DataTable dt)
        {
            Series serie = chartEstados.Series["Estados"];
            serie.Points.Clear();

            var conteoPorEstado = dt.AsEnumerable()
                .GroupBy(r => r.Field<string>("EstadoNombre"))
                .Select(g => new { Estado = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

            int total = dt.Rows.Count;

            foreach (var item in conteoPorEstado)
            {
                int idx = serie.Points.AddXY(item.Estado, item.Cantidad);
                serie.Points[idx].Color = ObtenerColorChart(item.Estado);
                serie.Points[idx].Label = total > 0 ? $"{(item.Cantidad * 100.0 / total):0}%" : "0%";
                serie.Points[idx].LegendText = item.Estado;
            }

            lblTotalCentro.Text = $"Total{Environment.NewLine}{total}";
            lblTotalCentro.TextAlign = ContentAlignment.MiddleCenter;
        }

        // Reconstruye el panel de resumen ejecutivo (título fijo + detalle dinámico por estado)
        private void ActualizarResumenEjecutivo(DataTable dt)
        {
            // Elimina los controles generados dinámicamente en una llamada anterior, deja label3 (título)
            var controlesAEliminar = pnlResumenEjecutivo.Controls
                .Cast<Control>()
                .Where(c => c != label3)
                .ToList();
            foreach (var c in controlesAEliminar)
            {
                pnlResumenEjecutivo.Controls.Remove(c);
                c.Dispose();
            }

            var conteoPorEstado = dt.AsEnumerable()
                .GroupBy(r => r.Field<string>("EstadoNombre"))
                .Select(g => new { Estado = g.Key, Cantidad = g.Count() })
                .OrderByDescending(x => x.Cantidad)
                .ToList();

            int y = 40;
            const int alturaFila = 24;

            foreach (var item in conteoPorEstado)
            {
                Panel dot = new Panel
                {
                    BackColor = ObtenerColorEstado(item.Estado),
                    Size = new Size(12, 12),
                    Location = new Point(14, y + 3)
                };

                Label lblEstado = new Label
                {
                    Text = $"{item.Estado}:",
                    Font = new Font(label6.Font, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(34, y)
                };

                Label lblCantidad = new Label
                {
                    Text = $"{item.Cantidad} órdenes",
                    AutoSize = true,
                    Location = new Point(200, y)
                };

                pnlResumenEjecutivo.Controls.Add(dot);
                pnlResumenEjecutivo.Controls.Add(lblEstado);
                pnlResumenEjecutivo.Controls.Add(lblCantidad);

                y += alturaFila;
            }

            y += 10;

            Label lblSeparador = new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                AutoSize = false,
                Height = 2,
                Location = new Point(14, y),
                Width = pnlResumenEjecutivo.Width - 28
            };
            pnlResumenEjecutivo.Controls.Add(lblSeparador);
            y += 14;

            int totalOrdenes = dt.Rows.Count;

            // Propiedades con incidencias: propiedades distintas con al menos una solicitud
            // en el rango filtrado, sin importar el estado (2 mantenimientos en la misma
            // propiedad cuentan como 1 incidencia).
            int propiedadesConIncidencias = dt.AsEnumerable()
                .Select(r => r.Field<int>("IdPropiedad"))
                .Distinct()
                .Count();

            Label lblTotalOrdenes = new Label
            {
                Text = "Total de órdenes:",
                AutoSize = true,
                Location = new Point(14, y)
            };
            Label lblTotalOrdenesValor = new Label
            {
                Text = totalOrdenes.ToString(),
                Font = new Font(label3.Font, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(300, y)
            };
            pnlResumenEjecutivo.Controls.Add(lblTotalOrdenes);
            pnlResumenEjecutivo.Controls.Add(lblTotalOrdenesValor);
            y += alturaFila;

            Label lblIncidencias = new Label
            {
                Text = "Propiedades con incidencias:",
                AutoSize = true,
                Location = new Point(14, y)
            };
            Label lblIncidenciasValor = new Label
            {
                Text = propiedadesConIncidencias.ToString(),
                Font = new Font(label3.Font, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(300, y)
            };
            pnlResumenEjecutivo.Controls.Add(lblIncidencias);
            pnlResumenEjecutivo.Controls.Add(lblIncidenciasValor);
        }

        // Llena la tabla consolidada por propiedad (filas = propiedades, columnas = TODOS los estados existentes)
        private void ActualizarDataGridView(DataTable dt)
        {
            // Siempre se muestran todas las columnas de estado que existen en la base de datos,
            // aunque para el filtro actual algún estado tenga 0 solicitudes.
            var estadosPresentes = ObtenerTodosLosEstados();

            DataTable dtPivot = new DataTable();
            dtPivot.Columns.Add("Propiedad", typeof(string));
            foreach (string estado in estadosPresentes)
                dtPivot.Columns.Add(estado, typeof(int));
            dtPivot.Columns.Add("Total", typeof(int));

            var propiedades = dt.AsEnumerable()
                .GroupBy(r => new { Id = r.Field<int>("IdPropiedad"), Codigo = r.Field<string>("PropiedadCodigo") })
                .OrderBy(g => g.Key.Id)
                .ToList();

            int[] totalesPorEstado = new int[estadosPresentes.Count];
            int totalGeneral = 0;

            foreach (var grupo in propiedades)
            {
                DataRow fila = dtPivot.NewRow();
                fila["Propiedad"] = grupo.Key.Codigo;

                int totalFila = 0;
                for (int i = 0; i < estadosPresentes.Count; i++)
                {
                    int cantidad = grupo.Count(r => r.Field<string>("EstadoNombre") == estadosPresentes[i]);
                    fila[estadosPresentes[i]] = cantidad;
                    totalesPorEstado[i] += cantidad;
                    totalFila += cantidad;
                }

                fila["Total"] = totalFila;
                totalGeneral += totalFila;
                dtPivot.Rows.Add(fila);
            }

            // Fila de totales
            DataRow filaTotal = dtPivot.NewRow();
            filaTotal["Propiedad"] = "Total general";
            for (int i = 0; i < estadosPresentes.Count; i++)
                filaTotal[estadosPresentes[i]] = totalesPorEstado[i];
            filaTotal["Total"] = totalGeneral;
            dtPivot.Rows.Add(filaTotal);

            dgvPropiedades.AutoGenerateColumns = true;
            dgvPropiedades.DataSource = dtPivot;
            dgvPropiedades.ReadOnly = true;
            dgvPropiedades.AllowUserToAddRows = false;
            dgvPropiedades.AllowUserToResizeRows = false;
            dgvPropiedades.RowHeadersVisible = false;

            // Permite scroll vertical cuando hay demasiadas filas para el alto visible
            dgvPropiedades.ScrollBars = ScrollBars.Vertical;

            // Hace que las columnas ocupen todo el ancho del control, siempre, aunque estén en 0
            dgvPropiedades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPropiedades.Columns["Propiedad"].FillWeight = 150;
            foreach (DataGridViewColumn col in dgvPropiedades.Columns)
            {
                if (col.Name != "Propiedad")
                    col.FillWeight = 100;

                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font(dgvPropiedades.Font, FontStyle.Bold);
                if (col.Name != "Propiedad")
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Altura de fila fija y cómoda (ya NO se fuerza a caber todo en el alto visible,
            // así el control puede mostrar scroll cuando hay muchas propiedades)
            dgvPropiedades.RowTemplate.Height = 30;
            foreach (DataGridViewRow fila in dgvPropiedades.Rows)
                fila.Height = 30;

            if (dgvPropiedades.Rows.Count > 0)
            {
                var ultimaFila = dgvPropiedades.Rows[dgvPropiedades.Rows.Count - 1];
                ultimaFila.DefaultCellStyle.Font = new Font(dgvPropiedades.Font, FontStyle.Bold);
            }
        }

        // Asigna un color consistente según el nombre del estado
        private Color ObtenerColorEstado(string nombreEstado)
        {
            switch (nombreEstado)
            {
                case "Pendiente":
                    return Color.Red;
                case "En Proceso":
                    return Color.Orange;
                case "Completado":
                    return Color.LimeGreen;
                case "Cancelado":
                    return Color.Gray;
                default:
                    return Color.SteelBlue;
            }
        }

        private Color ObtenerColorChart(string nombreEstado)
        {
            switch (nombreEstado)
            {
                case "Pendiente":
                    return Color.Orange;
                case "En Proceso":
                    return Color.Orange;
                case "Completado":
                    return Color.OrangeRed;
                case "Cancelado":
                    return Color.Gray;
                default:
                    return Color.SteelBlue;
            }
        }

        private void ResumenMantenimientoEstado_Load(object sender, EventArgs e)
        {
            DataTable dtDatos = ObtenerDatosFiltrados();
            CargarEstadosEnComboBox(cBxEstados);
            CargarPropiedadesEnComboBox(cBxPropiedades);
            ActualizarChart(dtDatos);
            ActualizarResumenEjecutivo(dtDatos);
            ActualizarDataGridView(dtDatos);
            string propiedadTexto = cBxPropiedades.Text;
            lblSubtitulo.Text = $"Del {dtpInicio.Value:dd/MM/yyyy} al {dtpFin.Value:dd/MM/yyyy} - {propiedadTexto}";
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            // 1. Restaurar filtros a su valor por defecto
            dtpFin.Value = DateTime.Today;
            dtpInicio.Value = DateTime.Today.AddDays(-365);
            cBxEstados.SelectedValue = 0;
            cBxPropiedades.SelectedValue = 0;

            // 2. Limpiar subtítulo
            lblSubtitulo.Text = string.Empty;

            // 3. Limpiar chart
            chartEstados.Series["Estados"].Points.Clear();
            lblTotalCentro.Text = "Total";

            // 4. Limpiar resumen ejecutivo (deja solo el título "RESUMEN EJECUTIVO")
            var controlesAEliminar = pnlResumenEjecutivo.Controls
                .Cast<Control>()
                .Where(c => c != label3)
                .ToList();
            foreach (var c in controlesAEliminar)
            {
                pnlResumenEjecutivo.Controls.Remove(c);
                c.Dispose();
            }

            // 5. Limpiar el datagridview
            DataTable dtDatos = ObtenerDatosFiltrados();
            dgvPropiedades.DataSource = null;
            dgvPropiedades.Columns.Clear();
            dgvPropiedades.Rows.Clear();
            CargarEstadosEnComboBox(cBxEstados);
            CargarPropiedadesEnComboBox(cBxPropiedades);
            ActualizarChart(dtDatos);
            ActualizarResumenEjecutivo(dtDatos);
            ActualizarDataGridView(dtDatos);
            string propiedadTexto = cBxPropiedades.Text;
            lblSubtitulo.Text = $"Del {dtpInicio.Value:dd/MM/yyyy} al {dtpFin.Value:dd/MM/yyyy} - {propiedadTexto}";

        }

        private void chartEstados_Click(object sender, EventArgs e)
        {

        }

        private void lblSubtitulo_Click(object sender, EventArgs e)
        {

        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}