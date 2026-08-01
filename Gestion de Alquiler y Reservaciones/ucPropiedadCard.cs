using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class ucPropiedadCard : UserControl
    {
        public ucPropiedadCard()
        {
            InitializeComponent();
        }

        public void CargarDatos(string nombre, string tipo, decimal? area, decimal? precio, string estado, string arrendatario)
        {
            lblNombre.Text = nombre;
            lblTipoArea.Text = (area.HasValue && area.Value > 0) ? $"{tipo} · {area.Value:0} m²" : tipo;

            lblEstado.Text = estado;
            ConfigurarBadgeEstado(estado);

            if (!string.IsNullOrWhiteSpace(arrendatario))
            {
                lblArrendatario.Text = "  " + arrendatario;
                lblArrendatario.ForeColor = Color.FromArgb(60, 60, 60);
                lblArrendatario.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            }
            else
            {
                lblArrendatario.Text = "  Sin arrendatario";
                lblArrendatario.ForeColor = Color.Gray;
                lblArrendatario.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            }

            NumberFormatInfo nfi = new NumberFormatInfo { CurrencySymbol = "L" };
            lblPrecio.Text = precio.HasValue ? precio.Value.ToString("C2", nfi) : "N/A";
        }

        private void ConfigurarBadgeEstado(string estado)
        {
            switch (estado)
            {
                case "Disponible":
                    lblEstado.BackColor = Color.FromArgb(59, 140, 74);
                    lblEstado.ForeColor = Color.White;
                    break;
                case "Arrendada":
                    lblEstado.BackColor = Color.FromArgb(200, 79, 36);
                    lblEstado.ForeColor = Color.White;
                    break;
                case "Reservada":
                    lblEstado.BackColor = Color.FromArgb(230, 179, 64);
                    lblEstado.ForeColor = Color.FromArgb(65, 36, 2);
                    break;
                case "En Mantenimiento":
                    lblEstado.BackColor = Color.FromArgb(92, 107, 133);
                    lblEstado.ForeColor = Color.White;
                    lblEstado.Font = new Font(lblEstado.Font.FontFamily, 5, FontStyle.Bold);
                    break;
                case "Inactiva":
                    lblEstado.BackColor = Color.FromArgb(74, 74, 74);
                    lblEstado.ForeColor = Color.White;
                    break;
                default:
                    lblEstado.BackColor = Color.Gray;
                    lblEstado.ForeColor = Color.White;
                    break;
            }
        }

        private void ucPropiedadCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(225, 222, 214)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
