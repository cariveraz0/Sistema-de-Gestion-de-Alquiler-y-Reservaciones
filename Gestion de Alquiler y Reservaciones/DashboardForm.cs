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


namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            CargarIndicadoresDashboard();
            CargarAlertas();
            CargarActividadReciente();
        }

        private void panelKPI1_Paint_1(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI2_Paint_1(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI3_Paint_1(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI4_Paint_1(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void CargarIndicadoresDashboard()
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                // Contratos Vigentes
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Contratos c
            INNER JOIN EstadosContrato e ON c.IdEstadoContrato = e.IdEstadoContrato
            WHERE e.Nombre = 'Vigente'", cn))
                {
                    label13.Text = cmd.ExecuteScalar().ToString();
                }

                // Contratos Por Vencer
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Contratos c
            INNER JOIN EstadosContrato e ON c.IdEstadoContrato = e.IdEstadoContrato
            WHERE e.Nombre = 'Por Vencer'", cn))
                {
                    label19.Text = cmd.ExecuteScalar().ToString() + " próximos a vencer";
                }

                // Reservaciones activas de este mes
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Reservaciones r
            INNER JOIN EstadosReservacion er ON r.IdEstadoReservacion = er.IdEstadoReservacion
            WHERE er.Nombre <> 'Cancelada'
              AND MONTH(r.FechaEntrada) = MONTH(GETDATE())
              AND YEAR(r.FechaEntrada)  = YEAR(GETDATE())", cn))
                {
                    label15.Text = cmd.ExecuteScalar().ToString();
                }

                // Mantenimientos pendientes
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Mantenimiento m
            INNER JOIN EstadosMantenimiento em ON m.IdEstadoMantenimiento = em.IdEstadoMantenimiento
            WHERE em.Nombre = 'Pendiente'", cn))
                {
                    label17.Text = cmd.ExecuteScalar().ToString();
                }
            }
        }
        private void CargarAlertas()
        {
            // 1. Limpiamos el panel por si se vuelve a cargar
            flpAlertas.Controls.Clear();

            // Configuración para que el FlowLayoutPanel se vea bien
            flpAlertas.AutoScroll = true;
            flpAlertas.WrapContents = false;
            flpAlertas.FlowDirection = FlowDirection.TopDown;

            string query = @"
                -- 1. PRÓXIMAS RESERVACIONES (Próximos 30 días)
                SELECT 
                    'Reservación' AS TipoAlerta,
                    'Reserva en: ' + P.Codigo AS Descripcion,
                    R.FechaEntrada AS Fecha,
                    '#d67a31' AS ColorSugerido
                FROM Reservaciones R
                INNER JOIN Propiedades P ON R.IdPropiedad = P.IdPropiedad
                WHERE R.FechaEntrada BETWEEN GETDATE() AND DATEADD(day, 30, GETDATE())
                  AND R.IdEstadoReservacion IN (1, 2) -- 1: Pendiente, 2: Confirmada

                UNION ALL

                -- 2. PAGOS A VENCER (15 días) O ATRASADOS
                SELECT 
                    'Pago' AS TipoAlerta,
                    'Contrato #' + C.NumeroContrato + ' - L' + CAST(CC.MontoCuota AS VARCHAR) AS Descripcion,
                    CC.FechaVencimiento AS Fecha,
                    CASE 
                        WHEN CC.FechaVencimiento < CAST(GETDATE() AS DATE) THEN '#C84F24' -- Naranja Rojizo Clarita (Atrasado)
                        ELSE '#E6B340' -- Dorado Clarita (Por vencer)
                    END AS ColorSugerido
                FROM CuotasContrato CC
                INNER JOIN Contratos C ON CC.IdContrato = C.IdContrato
                WHERE CC.FechaVencimiento <= DATEADD(day, 15, CAST(GETDATE() AS DATE))
                  AND CC.IdEstadoPago = 1 -- 1: Pendiente

                UNION ALL

                -- 3. MANTENIMIENTOS PENDIENTES
                SELECT 
                    'Mantenimiento' AS TipoAlerta,
                    'Revisión en: ' + P.Codigo AS Descripcion,
                    M.FechaSolicitud AS Fecha,
                    '#95A5A6' AS ColorSugerido -- Gris
                FROM Mantenimiento M
                INNER JOIN Propiedades P ON M.IdPropiedad = P.IdPropiedad
                WHERE M.IdEstadoMantenimiento = 1 -- 1: Pendiente

                ORDER BY Fecha ASC;";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AlertaItem nuevaAlerta = new AlertaItem();

                            string tipo = reader["TipoAlerta"].ToString();
                            string descripcion = reader["Descripcion"].ToString();
                            DateTime fecha = Convert.ToDateTime(reader["Fecha"]);
                            string colorHex = reader["ColorSugerido"].ToString();

                            nuevaAlerta.CargarDatos(tipo, descripcion, fecha, colorHex);

                            flpAlertas.Controls.Add(nuevaAlerta);
                        }
                    }
                }
            }
        }
        private void CargarActividadReciente()
        {
            // Limpiamos el FlowLayoutPanel de actividades
            flpActividad.Controls.Clear();
            flpActividad.AutoScroll = true;
            flpActividad.WrapContents = false;
            flpActividad.FlowDirection = FlowDirection.TopDown;

            string query = @"
                SELECT TOP 10 * FROM (
                    -- 1. NUEVO CONTRATO
                    SELECT 
                        'Nuevo Contrato' AS Titulo,
                        'Contrato #' + C.NumeroContrato + ' - ' + CL.NombreCompleto AS Detalle,
                        C.FechaCreacion AS Fecha,
                        '#E6B340' AS ColorHex
                    FROM Contratos C
                    INNER JOIN Clientes CL ON C.IdArrendatario = CL.IdCliente

                    UNION ALL

                    -- 2. NUEVA RESERVACIÓN
                    SELECT 
                        'Nueva Reservación' AS Titulo,
                        'Reserva en ' + P.Codigo + ' por ' + CL.NombreCompleto AS Detalle,
                        R.FechaCreacion AS Fecha,
                        '#F53D20' AS ColorHex
                    FROM Reservaciones R
                    INNER JOIN Clientes CL ON R.IdCliente = CL.IdCliente
                    INNER JOIN Propiedades P ON R.IdPropiedad = P.IdPropiedad

                    UNION ALL

                    -- 3. NUEVA SOLICITUD DE MANTENIMIENTO
                    SELECT 
                        'Mantenimiento Solicitado' AS Titulo,
                        'Propiedad: ' + P.Codigo + ' - ' + M.Descripcion AS Detalle,
                        CAST(M.FechaSolicitud AS DATETIME) AS Fecha,
                        '#E67E22' AS ColorHex -- Naranja
                    FROM Mantenimiento M
                    INNER JOIN Propiedades P ON M.IdPropiedad = P.IdPropiedad

                    UNION ALL

                    -- 4. NUEVO PAGO REGISTRADO
                    SELECT 
                        'Pago Recibido' AS Titulo,
                        'Monto: L' + CAST(P.Monto AS VARCHAR) + ' (' + MP.Nombre + ')' AS Detalle,
                        P.FechaPago AS Fecha,
                        '#C84F24' AS ColorHex -- Naranja Corporativo
                    FROM Pagos P
                    INNER JOIN MetodosPago MP ON P.IdMetodoPago = MP.IdMetodoPago
                    
                    UNION ALL

                    -- 5. NUEVO CLIENTE REGISTRADO (¡El que acabamos de agregar!)
                    SELECT 
                        'Nuevo Cliente' AS Titulo,
                        'Cliente: ' + NombreCompleto AS Detalle,
                        FechaRegistro AS Fecha,
                        '#d67a31' AS ColorHex
                    FROM Clientes
                ) AS Actividades
                ORDER BY Fecha DESC;";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ActividadesItem item = new ActividadesItem();

                            string titulo = reader["Titulo"].ToString();
                            string detalle = reader["Detalle"].ToString();
                            DateTime fecha = Convert.ToDateTime(reader["Fecha"]);
                            string colorHex = reader["ColorHex"].ToString();

                            item.CargarDatos(titulo, detalle, fecha, colorHex);
                            flpActividad.Controls.Add(item);
                        }
                    }
                }
            }
        }
    }
}
