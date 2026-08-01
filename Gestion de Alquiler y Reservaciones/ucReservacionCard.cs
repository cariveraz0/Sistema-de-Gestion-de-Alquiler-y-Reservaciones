using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class ucReservacionCard : UserControl
    {
        public ucReservacionCard()
        {
            InitializeComponent();
        }

        public void CargarDatos(string propiedad, string cliente, string estado, DateTime entrada, DateTime salida)
        {
            lblNombre.Text = propiedad;
            lblCliente.Text = "  " + cliente;
            lblEstado.Text = estado;
            ConfigurarBadgeEstado(estado);

            CultureInfo culturaHn = new CultureInfo("es-HN");
            lblEntrada.Text = "Entrada: " + entrada.ToString("dd MMM, hh:mm tt", culturaHn);
            lblSalida.Text = "Salida: " + salida.ToString("dd MMM, hh:mm tt", culturaHn);
        }

        private void ConfigurarBadgeEstado(string estado)
        {
            switch (estado)
            {
                case "Confirmada":
                    lblEstado.BackColor = Color.FromArgb(59, 140, 74);
                    lblEstado.ForeColor = Color.White;
                    break;
                case "Pendiente":
                    lblEstado.BackColor = Color.FromArgb(201, 154, 46);
                    lblEstado.ForeColor = Color.White;
                    break;
                case "En Curso":
                    lblEstado.BackColor = Color.FromArgb(53, 119, 201);
                    lblEstado.ForeColor = Color.White;
                    break;
                default:
                    lblEstado.BackColor = Color.Gray;
                    lblEstado.ForeColor = Color.White;
                    break;
            }
        }

        private void ucReservacionCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(225, 222, 214)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
