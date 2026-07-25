using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class ActividadesItem : UserControl
    {
        public ActividadesItem()
        {
            InitializeComponent();
        }

        public void CargarDatos(string titulo, string detalle, DateTime fecha, string colorHex)
        {
            lblTitulo.Text = titulo;
            lblDetalle.Text = detalle;
            lblTiempo.Text = ObtenerTiempoTranscurrido(fecha);
            pnlColor.BackColor = ColorTranslator.FromHtml(colorHex);
        }

        // Formato amigable tipo "Hace 5 min", "Ayer", etc.
        private string ObtenerTiempoTranscurrido(DateTime fecha)
        {
            DateTime fechaUtc = DateTime.SpecifyKind(fecha, DateTimeKind.Utc);

            TimeSpan diferencia = DateTime.UtcNow - fechaUtc;

            if (diferencia.TotalSeconds < 0)
                diferencia = TimeSpan.Zero;

            if (diferencia.TotalMinutes < 60)
                return $"Hace {(int)diferencia.TotalMinutes} min";
            if (diferencia.TotalHours < 24)
                return $"Hace {(int)diferencia.TotalHours} hr";
            if (diferencia.TotalDays < 7)
                return $"Hace {(int)diferencia.TotalDays} días";

            return fechaUtc.ToLocalTime().ToString("dd/MM/yyyy HH:mm");
        }
    }
}
    
