using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    public partial class SeleccionarPeriodoIngresosForm : Form
    {
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }

        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;

        public SeleccionarPeriodoIngresosForm()
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

            Label lblTitulo = new Label();
            lblTitulo.Text = "Seleccione el período del reporte";
            lblTitulo.Font = new Font("Montserrat", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(35, 20);
            lblTitulo.Size = new Size(300, 25);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

            Label lblDesde = new Label();
            lblDesde.Text = "Desde:";
            lblDesde.Font = new Font("Montserrat", 9, FontStyle.Bold);
            lblDesde.Location = new Point(45, 70);
            lblDesde.Size = new Size(70, 25);
            this.Controls.Add(lblDesde);

            dtpInicio = new DateTimePicker();
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Value = new DateTime(2026, 1, 1);
            dtpInicio.Location = new Point(120, 68);
            dtpInicio.Size = new Size(160, 25);
            this.Controls.Add(dtpInicio);

            Label lblHasta = new Label();
            lblHasta.Text = "Hasta:";
            lblHasta.Font = new Font("Montserrat", 9, FontStyle.Bold);
            lblHasta.Location = new Point(45, 105);
            lblHasta.Size = new Size(70, 25);
            this.Controls.Add(lblHasta);

            dtpFin = new DateTimePicker();
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Value = new DateTime(2026, 12, 31);
            dtpFin.Location = new Point(120, 103);
            dtpFin.Size = new Size(160, 25);
            this.Controls.Add(dtpFin);

            Button btnAceptar = new Button();
            btnAceptar.Text = "Aceptar";
            btnAceptar.Location = new Point(80, 145);
            btnAceptar.Size = new Size(90, 30);
            btnAceptar.BackColor = Color.FromArgb(214, 122, 49);
            btnAceptar.Font = new Font("Montserrat", 9, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderColor = Color.White;
            btnAceptar.FlatAppearance.BorderSize = 1;
            btnAceptar.Click += BtnAceptar_Click;
            this.Controls.Add(btnAceptar);

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Font = new Font("Montserrat", 9, FontStyle.Bold);
            btnCancelar.Location = new Point(190, 145);
            btnCancelar.Size = new Size(90, 30);
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.White;
            btnCancelar.FlatAppearance.BorderSize = 1;
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