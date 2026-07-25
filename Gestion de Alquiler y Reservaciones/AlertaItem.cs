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
    public partial class AlertaItem : UserControl
    {
        public AlertaItem()
        {
            InitializeComponent();
        }
        public void CargarDatos(string tipo, string descripcion, DateTime fecha, string colorHex)
        {
            lblTipo.Text = tipo;
            lblDescripcion.Text = descripcion;
            lblFecha.Text = fecha.ToString("dd MMM yyyy");
            pnlColor.BackColor = ColorTranslator.FromHtml(colorHex);
        }
    }
}
