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
            CargarKPIs();
            CargarCardsPropiedades();
            CargarCardsReservaciones();
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

        private void CargarCardsPropiedades()
        {
            string consulta = @"
            SELECT 
                p.Codigo AS Nombre,
                tp.Nombre AS Tipo,
                p.AreaM2,
                p.PrecioAlquiler,
                ep.Nombre AS Estado,
                cli.NombreCompleto AS Arrendatario
            FROM Propiedades p
            INNER JOIN TiposPropiedad tp ON p.IdTipoPropiedad = tp.IdTipoPropiedad
            INNER JOIN EstadosPropiedad ep ON p.IdEstadoPropiedad = ep.IdEstadoPropiedad
            LEFT JOIN Contratos c ON p.IdPropiedad = c.IdPropiedad 
                 AND c.IdEstadoContrato IN (SELECT IdEstadoContrato FROM EstadosContrato WHERE Nombre IN ('Vigente','Por Vencer'))
            LEFT JOIN Clientes cli ON c.IdArrendatario = cli.IdCliente
            WHERE tp.Nombre IN ('Apartamento', 'Local Comercial')
            ORDER BY p.Codigo";

            try
            {
                flpPropiedades.Controls.Clear();

                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ucPropiedadCard card = new ucPropiedadCard();
                            card.CargarDatos(
                                reader["Nombre"].ToString(),
                                reader["Tipo"].ToString(),
                                reader["AreaM2"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["AreaM2"]),
                                reader["PrecioAlquiler"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["PrecioAlquiler"]),
                                reader["Estado"].ToString(),
                                reader["Arrendatario"] == DBNull.Value ? null : reader["Arrendatario"].ToString()
                            );
                            flpPropiedades.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Propiedades: " + ex.Message);
            }
        }

        private void CargarCardsReservaciones()
        {
            string consulta = @"
            SELECT 
                p.Codigo AS Propiedad,
                cli.NombreCompleto AS Cliente,
                er.Nombre AS Estado,
                r.FechaEntrada,
                r.FechaSalida
            FROM Reservaciones r
            INNER JOIN Propiedades p ON r.IdPropiedad = p.IdPropiedad
            INNER JOIN Clientes cli ON r.IdCliente = cli.IdCliente
            INNER JOIN EstadosReservacion er ON r.IdEstadoReservacion = er.IdEstadoReservacion
            INNER JOIN TiposPropiedad tp ON p.IdTipoPropiedad = tp.IdTipoPropiedad
            WHERE tp.Nombre IN ('Casa de Playa/Montaña', 'Auditorio', 'Sala de Juntas')
              AND er.Nombre NOT IN ('Cancelada', 'Completada')
              AND r.FechaSalida >= CAST(GETDATE() AS DATE)
            ORDER BY r.FechaEntrada ASC";

            try
            {
                flpReservaciones.Controls.Clear();

                using (SqlConnection conexion = Conexion.ObtenerConexion())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ucReservacionCard card = new ucReservacionCard();
                            card.CargarDatos(
                                reader["Propiedad"].ToString(),
                                reader["Cliente"].ToString(),
                                reader["Estado"].ToString(),
                                Convert.ToDateTime(reader["FechaEntrada"]),
                                Convert.ToDateTime(reader["FechaSalida"])
                            );
                            flpReservaciones.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Reservaciones: " + ex.Message);
            }
        }
    }
}
