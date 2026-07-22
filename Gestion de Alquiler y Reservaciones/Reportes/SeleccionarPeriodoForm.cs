using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class SeleccionarPeriodoForm : Form
    {
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }

        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;

        public SeleccionarPeriodoForm()
        {
            InitializeComponent();
            DiseñarFormulario();
        }

        private void DiseñarFormulario()
        {
            this.Text = "Periodo de Consulta";
            this.Size = new Size(380, 240);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Label lblTitulo = new Label
            {
                Text = "Seleccione el período del reporte",
                Font = new Font("Montserrat", 12, FontStyle.Bold),
                Location = new Point(35, 20),
                Size = new Size(300, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblTitulo);

            Label lblDesde = new Label
            {
                Text = "Desde:",
                Font = new Font("Montserrat", 9, FontStyle.Bold),
                Location = new Point(45, 70),
                Size = new Size(70, 25)
            };
            this.Controls.Add(lblDesde);

            dtpInicio = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Value = new DateTime(2026, 6, 1),
                Location = new Point(120, 68),
                Size = new Size(160, 25)
            };
            this.Controls.Add(dtpInicio);

            Label lblHasta = new Label
            {
                Text = "Hasta:",
                Font = new Font("Montserrat", 9, FontStyle.Bold),
                Location = new Point(45, 105),
                Size = new Size(70, 25)
            };
            this.Controls.Add(lblHasta);

            dtpFin = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Value = new DateTime(2026, 6, 30),
                Location = new Point(120, 103),
                Size = new Size(160, 25)
            };
            this.Controls.Add(dtpFin);

            Button btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new Point(80, 145),
                Size = new Size(90, 30),
                BackColor = Color.FromArgb(214, 122, 49),
                Font = new Font("Montserrat", 9, FontStyle.Bold),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = 
                {
                    BorderColor = Color.White,
                    BorderSize = 1
                }
            };
            btnAceptar.Click += BtnAceptar_Click;
            this.Controls.Add(btnAceptar);

            Button btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(190, 145),
                Size = new Size(90, 30),
                Font = new Font("Montserrat", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderColor = Color.White,
                    BorderSize = 1
                }
            };
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancelar);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (dtpInicio.Value.Date > dtpFin.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser mayor que la fecha final."
                );
                return;
            }

            FechaInicio = dtpInicio.Value.Date;
            FechaFin = dtpFin.Value.Date;
            this.DialogResult = DialogResult.OK;
        }
    }
}