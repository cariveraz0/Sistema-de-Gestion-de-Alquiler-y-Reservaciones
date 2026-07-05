using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class EstadisticasOcupacionPropiedad : ReporteBase
    {
        private List<string> listaPropiedadesReservadas = new List<string>();
        public EstadisticasOcupacionPropiedad()
        {
            InitializeComponent();
            cmbTiposPropiedad.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EstadisticasOcupacionPropiedad_Load(object sender, EventArgs e)
        {
            cmbTiposPropiedad.SelectedIndex = -1;

            if (cmbTiposPropiedad.SelectedIndex == -1)
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
                btnConsultar.Enabled = false;
                dgvInformacion.Enabled = false;
            }
        }

        private void cmbTiposPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTiposPropiedad.SelectedIndex != -1)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
                btnConsultar.Enabled = true;
            }
        }

        private void cmdConsultar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha inicial no debe ser mayor a la fecha final",
                    "Rango de fecha invalido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                int[] propiedadID = { };
                switch (cmbTiposPropiedad.SelectedIndex)
                {
                    //Plaza Universitaria
                    //Casa Vacacional
                    //Apartamento
                    case 0:
                        propiedadID = new int[] { 3, 4, 7, 8, 11 };
                        break;

                    case 1:
                        propiedadID = new int[] { 5, 6, 12 };
                        break;

                    case 2:
                        propiedadID = new int[] { 1, 2, 9, 10 };
                        break;
                }
                dgvInformacion.Enabled = true;
                listaPropiedadesReservadas = buscarTipoPropiedades(propiedadID);
                llenargrafico();
                llenardgv(propiedadID);
            }
        }

        /// <summary>
        /// Busca el tipo de propiedad reservada entre el rango de fechas a partir de la idPropiedad reservada
        /// </summary>
        /// <param name="propiedadID"></param>
        private List<string> buscarTipoPropiedades(int[] propiedadID)
        {
            List<string> propiedades = new List<string>();
            try
            {
                string idsFormateados = string.Join(",", propiedadID);
                string queryBuscarTipoPropiedades = "select R.IdPropiedad, R.FechaEntrada, " +
                    "R.FechaSalida, TP.Nombre from Reservaciones as R INNER JOIN Propiedades as P " +
                    "on R.IdPropiedad = P.IdPropiedad INNER JOIN TiposPropiedad as TP on " +
                    "P.IdTipoPropiedad = TP.IdTipoPropiedad where " +
                    $"R.IdPropiedad in ({idsFormateados}) and " +
                    "R.FechaCreacion BETWEEN @desde and @hasta";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdBuscarTipoPropiedades = new SqlCommand(queryBuscarTipoPropiedades, conectar);
                    cmdBuscarTipoPropiedades.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);

                    DateTime fechaHastaFinDelDia = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                    cmdBuscarTipoPropiedades.Parameters.AddWithValue("@hasta", fechaHastaFinDelDia);
                    SqlDataReader readerBuscarTipoPropiedades = cmdBuscarTipoPropiedades.ExecuteReader();
                    while (readerBuscarTipoPropiedades.Read())
                    {
                        propiedades.Add(readerBuscarTipoPropiedades["Nombre"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algo salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return propiedades;
        }

        /// <summary>
        /// Esta funcion se encarga de llenar de valores el grafico de pastel
        /// </summary>
        private void llenargrafico()
        {
            try
            {
                // 1. Limpiamos cualquier dato o serie de prueba que traiga el diseño por defecto
                chartOcupacionPropiedades.Series.Clear();
                chartOcupacionPropiedades.Titles.Clear();

                // 2. Agregamos un título principal
                Title titulo = chartOcupacionPropiedades.Titles.Add($"Ocupación en {cmbTiposPropiedad.SelectedItem}");
                titulo.Font = new Font("Microsoft Sans Serif", 11);

                // 3. Creamos la serie y le decimos explícitamente que sea tipo Pastel (Pie)
                Series seriePastel = new Series("Ocupacion");
                seriePastel.ChartType = SeriesChartType.Pie;
                chartOcupacionPropiedades.Series.Add(seriePastel);

                // --- NUEVO PASO: Agrupar y contar las palabras repetidas antes de graficar ---
                Dictionary<string, int> conteoPropiedades = new Dictionary<string, int>();
                foreach (string propiedad in listaPropiedadesReservadas)
                {
                    if (conteoPropiedades.ContainsKey(propiedad))
                        conteoPropiedades[propiedad]++;
                    else
                        conteoPropiedades.Add(propiedad, 1);
                }

                // 4. ¡Agregamos los datos agrupados al gráfico configurando la leyenda por separado!
                foreach (KeyValuePair<string, int> resultado in conteoPropiedades)
                {
                    // Añadimos el punto con su valor numérico
                    int nuevoPuntoIndex = seriePastel.Points.AddXY(resultado.Key, resultado.Value);
                    DataPoint punto = seriePastel.Points[nuevoPuntoIndex];

                    // ASIGNACIÓN CORRECTA:
                    // El texto que va en la leyenda de colores (abajo) será el nombre único de la propiedad
                    punto.LegendText = resultado.Key;

                    // El texto que va DENTRO del círculo será únicamente el porcentaje calculado
                    punto.Label = "#PERCENT{P0}";
                }

                // 5. Configuración estética final del texto interior
                seriePastel.IsValueShownAsLabel = true;
                seriePastel.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);


                // 6. Configurar la leyenda (los cuadritos informativos de abajo)
                chartOcupacionPropiedades.Legends[0].Docking = Docking.Bottom;
                chartOcupacionPropiedades.Legends[0].Alignment = StringAlignment.Center;

                // 7. Colores personalizados (Validando cuántos puntos se agregaron para evitar errores de índice)
                if (seriePastel.Points.Count > 0) seriePastel.Points[0].Color = Color.FromArgb(230, 126, 34);  // Naranja
                if (seriePastel.Points.Count > 1) seriePastel.Points[1].Color = Color.FromArgb(241, 196, 15);  // Amarillo
                if (seriePastel.Points.Count > 2) seriePastel.Points[2].Color = Color.FromArgb(46, 204, 113);  // Verde
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algo salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void llenardgv(int[] propiedadID)
        {
            try
            {
                string idsFormateados = string.Join(",", propiedadID);
                string queryLlenarDGV =
                "SELECT R.IdPropiedad, TP.Nombre, COUNT(*) as Cantidad " +
                "FROM Reservaciones as R " +
                "INNER JOIN Propiedades as P ON R.IdPropiedad = P.IdPropiedad " +
                "INNER JOIN TiposPropiedad as TP ON P.IdTipoPropiedad = TP.IdTipoPropiedad " +
                $"WHERE R.IdPropiedad IN ({idsFormateados}) " +
                "AND CAST(R.FechaEntrada AS DATE) >= @desde " + // Forzamos a comparar solo fechas sin hora
                "AND CAST(R.FechaSalida AS DATE) <= @hasta " +
                "GROUP BY R.IdPropiedad, TP.Nombre";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdLlenarDGV = new SqlCommand(queryLlenarDGV, conectar);
                    cmdLlenarDGV.Parameters.AddWithValue("@desde", dtpDesde.Value.Date);

                    DateTime fechaHastaFinDelDia = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);
                    cmdLlenarDGV.Parameters.AddWithValue("@hasta", fechaHastaFinDelDia);
                    SqlDataReader readerLlenarDGV = cmdLlenarDGV.ExecuteReader();
                    dgvInformacion.Rows.Clear();
                    while (readerLlenarDGV.Read())
                    {
                        dgvInformacion.Rows.Add(readerLlenarDGV["IdPropiedad"].ToString(), readerLlenarDGV["Nombre"].ToString(), readerLlenarDGV["Cantidad"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Algo salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
