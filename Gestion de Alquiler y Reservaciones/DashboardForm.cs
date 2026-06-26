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
    public partial class DashboardForm : BaseForm
    {
        public DashboardForm()
        {
            InitializeComponent();
        }
        private void panelKPI1_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI2_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI3_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void panelKPI4_Paint(object sender, PaintEventArgs e)
        {
            Color colorLinea = Color.FromArgb(200, 79, 36);
            e.Graphics.FillRectangle(
                new SolidBrush(colorLinea), 0, 0, 4, panelKPI1.Height
            );
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
