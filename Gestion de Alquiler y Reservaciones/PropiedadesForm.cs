using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class PropiedadesForm : Form
    {
        public PropiedadesForm()
        {
            InitializeComponent();
            ConfigurarDataGridView(dataGridView1);
            ConfigurarDataGridView(dataGridView2);
            CargarKPIs();
            CargarDataGridPropiedades();
            CargarDataGridReservaciones();
        }

        private void CargarKPIs()
        {
            string consulta = @"
                SELECT ep.Nombre AS Estado, COUNT(p.IdPropiedad) AS Total
                FROM EstadosPropiedad ep
                LEFT JOIN Propiedades p ON ep.IdEstadoPropiedad = p.IdEstadoPropiedad
                GROUP BY ep.Nombre";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            lblDisponible.Text = "0";
                            lblArrendada.Text = "0";
                            lblReservada.Text = "0";
                            lblMantenimiento.Text = "0";
                            lblInactiva.Text = "0";

                            while (reader.Read())
                            {
                                string estado = reader["Estado"].ToString();
                                string total = reader["Total"].ToString();

                                switch (estado)
                                {
                                    case "Disponible": lblDisponible.Text = total; break;
                                    case "Arrendada": lblArrendada.Text = total; break;
                                    case "Reservada": lblReservada.Text = total; break;
                                    case "En Mantenimiento": lblMantenimiento.Text = total; break;
                                    case "Inactiva": lblInactiva.Text = total; break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar KPIs: " + ex.Message
                );
            }
        }

        private void panelKPI1_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
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
        private void CargarDataGridPropiedades()
        {
            string consulta = @"
                SELECT 
                    p.Codigo AS [Nombre Propiedad],
                    ISNULL(p.AreaM2, 0) AS [Área (m²)],
                    ISNULL(p.PrecioAlquiler, 0) AS [Precio],
                    ep.Nombre AS [Estado],
                    ISNULL(cli.NombreCompleto, 'N/A') AS [Arrendatario]
                FROM Propiedades p
                INNER JOIN EstadosPropiedad ep ON p.IdEstadoPropiedad = ep.IdEstadoPropiedad
                LEFT JOIN Contratos c ON p.IdPropiedad = c.IdPropiedad 
                     AND c.IdEstadoContrato = (SELECT IdEstadoContrato FROM EstadosContrato WHERE Nombre = 'Vigente')
                LEFT JOIN Clientes cli ON c.IdArrendatario = cli.IdCliente
                ORDER BY p.Codigo";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        dataGridView1.DataSource = dt;

                        if (dataGridView1.Columns["Precio"] != null)
                        {
                            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "C2";
                            dataGridView1.Columns["Precio"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("es-HN");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar Propiedades: " + ex.Message
                );
            }
        }
        private void CargarDataGridReservaciones()
        {
            string consulta = @"
                SELECT 
                    p.Codigo AS [Propiedad],
                    tp.Nombre AS [Tipo],
                    cli.NombreCompleto AS [Cliente],
                    r.FechaEntrada AS [Entrada],
                    r.FechaSalida AS [Salida],
                    er.Nombre AS [Estado]
                FROM Reservaciones r
                INNER JOIN Propiedades p ON r.IdPropiedad = p.IdPropiedad
                INNER JOIN Clientes cli ON r.IdCliente = cli.IdCliente
                INNER JOIN EstadosReservacion er ON r.IdEstadoReservacion = er.IdEstadoReservacion
                INNER JOIN TiposPropiedad tp ON p.IdTipoPropiedad = tp.IdTipoPropiedad
                WHERE tp.Nombre IN ('Casa de Playa/Montaña', 'Auditorio', 'Sala de Juntas')
                ORDER BY r.FechaEntrada DESC";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);
                        dataGridView2.DataSource = dt;

                        if (dataGridView2.Columns["Entrada"] != null)
                            dataGridView2.Columns["Entrada"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

                        if (dataGridView2.Columns["Salida"] != null)
                            dataGridView2.Columns["Salida"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar Reservaciones: " + ex.Message
                );
            }
        }

        private void PropiedadesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
