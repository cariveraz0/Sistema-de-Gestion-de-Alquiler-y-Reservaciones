namespace Gestion_de_Alquiler_y_Reservaciones
{
    partial class PagosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlPagos = new System.Windows.Forms.Panel();
            this.pnlPagodeCuota = new System.Windows.Forms.Panel();
            this.txtNumeroRecibo = new System.Windows.Forms.TextBox();
            this.labelRecibo = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.labelFechaPago = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.labelMetodoPago = new System.Windows.Forms.Label();
            this.numMontoPagar = new System.Windows.Forms.NumericUpDown();
            this.labelMontoPagar = new System.Windows.Forms.Label();
            this.txtSaldoPendiente = new System.Windows.Forms.TextBox();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.txtMora = new System.Windows.Forms.TextBox();
            this.labelMora = new System.Windows.Forms.Label();
            this.txtMontoCuota = new System.Windows.Forms.TextBox();
            this.labelMontoCuota = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarCuota = new System.Windows.Forms.Button();
            this.pnlPagoReservacion = new System.Windows.Forms.Panel();
            this.txtNumeroReciboR = new System.Windows.Forms.TextBox();
            this.labelReciboR = new System.Windows.Forms.Label();
            this.dtpFechaPagoR = new System.Windows.Forms.DateTimePicker();
            this.labelFechaPagoR = new System.Windows.Forms.Label();
            this.cmbMetodoPagoR = new System.Windows.Forms.ComboBox();
            this.labelMetodoPagoR = new System.Windows.Forms.Label();
            this.numMontoPagarR = new System.Windows.Forms.NumericUpDown();
            this.labelMontoPagarR = new System.Windows.Forms.Label();
            this.txtSaldoPendienteR = new System.Windows.Forms.TextBox();
            this.labelSaldoR = new System.Windows.Forms.Label();
            this.txtMontoTotalR = new System.Windows.Forms.TextBox();
            this.labelMontoTotalR = new System.Windows.Forms.Label();
            this.txtPropiedadR = new System.Windows.Forms.TextBox();
            this.labelPropiedadR = new System.Windows.Forms.Label();
            this.txtClienteR = new System.Windows.Forms.TextBox();
            this.labelClienteR = new System.Windows.Forms.Label();
            this.rbReservacion = new System.Windows.Forms.RadioButton();
            this.rbPagodeCuota = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cmbResultadosCuota = new System.Windows.Forms.ComboBox();
            this.lblResultadosCuota = new System.Windows.Forms.Label();
            this.lblResultadosReserv = new System.Windows.Forms.Label();
            this.cmbResultadosReserv = new System.Windows.Forms.ComboBox();
            this.btnBuscarReserv = new System.Windows.Forms.Button();
            this.txtBuscarCuota = new System.Windows.Forms.TextBox();
            this.txtBuscarReserv = new System.Windows.Forms.TextBox();
            this.pnlCuerpo.SuspendLayout();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.pnlPagos.SuspendLayout();
            this.pnlPagodeCuota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoPagar)).BeginInit();
            this.pnlPagoReservacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoPagarR)).BeginInit();
            this.pnlAccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPagos
            // 
            this.btnPagos.FlatAppearance.BorderSize = 0;
            this.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagos.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagos.Location = new System.Drawing.Point(38, 12);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(170, 34);
            this.btnPagos.TabIndex = 0;
            this.btnPagos.Text = "Registrar Pagos";
            this.btnPagos.UseVisualStyleBackColor = true;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.Location = new System.Drawing.Point(214, 12);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(170, 34);
            this.btnHistorial.TabIndex = 1;
            this.btnHistorial.Text = "Historial de Pagos";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.pnlPagos);
            this.pnlCuerpo.Controls.Add(this.pnlHistorial);
            this.pnlCuerpo.Location = new System.Drawing.Point(38, 75);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1042, 486);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHistorial.Controls.Add(this.dgvHistorial);
            this.pnlHistorial.Controls.Add(this.pnlBuscar);
            this.pnlHistorial.Location = new System.Drawing.Point(0, 0);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1036, 480);
            this.pnlHistorial.TabIndex = 3;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(3, 63);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1033, 416);
            this.dgvHistorial.TabIndex = 1;
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.White;
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.label3);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Location = new System.Drawing.Point(0, 0);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(1033, 60);
            this.pnlBuscar.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(73, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(320, 23);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buscar:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(408, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 27);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlPagos
            // 
            this.pnlPagos.Controls.Add(this.rbReservacion);
            this.pnlPagos.Controls.Add(this.rbPagodeCuota);
            this.pnlPagos.Controls.Add(this.label2);
            this.pnlPagos.Controls.Add(this.label1);
            this.pnlPagos.Controls.Add(this.pnlPagodeCuota);
            this.pnlPagos.Controls.Add(this.pnlPagoReservacion);
            this.pnlPagos.Location = new System.Drawing.Point(0, 0);
            this.pnlPagos.Name = "pnlPagos";
            this.pnlPagos.Size = new System.Drawing.Size(1039, 482);
            this.pnlPagos.TabIndex = 0;
            // 
            // pnlPagodeCuota
            // 
            this.pnlPagodeCuota.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPagodeCuota.Controls.Add(this.txtBuscarCuota);
            this.pnlPagodeCuota.Controls.Add(this.lblResultadosCuota);
            this.pnlPagodeCuota.Controls.Add(this.cmbResultadosCuota);
            this.pnlPagodeCuota.Controls.Add(this.txtNumeroRecibo);
            this.pnlPagodeCuota.Controls.Add(this.labelRecibo);
            this.pnlPagodeCuota.Controls.Add(this.dtpFechaPago);
            this.pnlPagodeCuota.Controls.Add(this.labelFechaPago);
            this.pnlPagodeCuota.Controls.Add(this.cmbMetodoPago);
            this.pnlPagodeCuota.Controls.Add(this.labelMetodoPago);
            this.pnlPagodeCuota.Controls.Add(this.numMontoPagar);
            this.pnlPagodeCuota.Controls.Add(this.labelMontoPagar);
            this.pnlPagodeCuota.Controls.Add(this.txtSaldoPendiente);
            this.pnlPagodeCuota.Controls.Add(this.labelSaldo);
            this.pnlPagodeCuota.Controls.Add(this.txtMora);
            this.pnlPagodeCuota.Controls.Add(this.labelMora);
            this.pnlPagodeCuota.Controls.Add(this.txtMontoCuota);
            this.pnlPagodeCuota.Controls.Add(this.labelMontoCuota);
            this.pnlPagodeCuota.Controls.Add(this.textBox2);
            this.pnlPagodeCuota.Controls.Add(this.label6);
            this.pnlPagodeCuota.Controls.Add(this.textBox1);
            this.pnlPagodeCuota.Controls.Add(this.label5);
            this.pnlPagodeCuota.Controls.Add(this.txtCliente);
            this.pnlPagodeCuota.Controls.Add(this.label4);
            this.pnlPagodeCuota.Controls.Add(this.btnBuscarCuota);
            this.pnlPagodeCuota.Location = new System.Drawing.Point(21, 100);
            this.pnlPagodeCuota.Name = "pnlPagodeCuota";
            this.pnlPagodeCuota.Size = new System.Drawing.Size(995, 370);
            this.pnlPagodeCuota.TabIndex = 5;
            // 
            // txtNumeroRecibo
            // 
            this.txtNumeroRecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroRecibo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroRecibo.Location = new System.Drawing.Point(22, 331);
            this.txtNumeroRecibo.Name = "txtNumeroRecibo";
            this.txtNumeroRecibo.ReadOnly = true;
            this.txtNumeroRecibo.Size = new System.Drawing.Size(878, 22);
            this.txtNumeroRecibo.TabIndex = 20;
            // 
            // labelRecibo
            // 
            this.labelRecibo.AutoSize = true;
            this.labelRecibo.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecibo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelRecibo.Location = new System.Drawing.Point(19, 311);
            this.labelRecibo.Name = "labelRecibo";
            this.labelRecibo.Size = new System.Drawing.Size(209, 17);
            this.labelRecibo.TabIndex = 19;
            this.labelRecibo.Text = "Número de recibo (autogenerado)";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(642, 265);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(258, 22);
            this.dtpFechaPago.TabIndex = 18;
            // 
            // labelFechaPago
            // 
            this.labelFechaPago.AutoSize = true;
            this.labelFechaPago.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelFechaPago.Location = new System.Drawing.Point(639, 245);
            this.labelFechaPago.Name = "labelFechaPago";
            this.labelFechaPago.Size = new System.Drawing.Size(95, 17);
            this.labelFechaPago.TabIndex = 17;
            this.labelFechaPago.Text = "Fecha de pago";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(355, 265);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(258, 21);
            this.cmbMetodoPago.TabIndex = 16;
            // 
            // labelMetodoPago
            // 
            this.labelMetodoPago.AutoSize = true;
            this.labelMetodoPago.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelMetodoPago.Location = new System.Drawing.Point(352, 245);
            this.labelMetodoPago.Name = "labelMetodoPago";
            this.labelMetodoPago.Size = new System.Drawing.Size(104, 17);
            this.labelMetodoPago.TabIndex = 15;
            this.labelMetodoPago.Text = "Método de pago";
            // 
            // numMontoPagar
            // 
            this.numMontoPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMontoPagar.DecimalPlaces = 2;
            this.numMontoPagar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMontoPagar.Location = new System.Drawing.Point(22, 265);
            this.numMontoPagar.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMontoPagar.Name = "numMontoPagar";
            this.numMontoPagar.Size = new System.Drawing.Size(303, 22);
            this.numMontoPagar.TabIndex = 14;
            // 
            // labelMontoPagar
            // 
            this.labelMontoPagar.AutoSize = true;
            this.labelMontoPagar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMontoPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelMontoPagar.Location = new System.Drawing.Point(19, 245);
            this.labelMontoPagar.Name = "labelMontoPagar";
            this.labelMontoPagar.Size = new System.Drawing.Size(94, 17);
            this.labelMontoPagar.TabIndex = 13;
            this.labelMontoPagar.Text = "Monto a pagar";
            // 
            // txtSaldoPendiente
            // 
            this.txtSaldoPendiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldoPendiente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoPendiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.txtSaldoPendiente.Location = new System.Drawing.Point(642, 199);
            this.txtSaldoPendiente.Name = "txtSaldoPendiente";
            this.txtSaldoPendiente.ReadOnly = true;
            this.txtSaldoPendiente.Size = new System.Drawing.Size(258, 22);
            this.txtSaldoPendiente.TabIndex = 12;
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.labelSaldo.Location = new System.Drawing.Point(639, 179);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(107, 17);
            this.labelSaldo.TabIndex = 11;
            this.labelSaldo.Text = "Saldo pendiente:";
            // 
            // txtMora
            // 
            this.txtMora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMora.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMora.Location = new System.Drawing.Point(355, 199);
            this.txtMora.Name = "txtMora";
            this.txtMora.ReadOnly = true;
            this.txtMora.Size = new System.Drawing.Size(258, 22);
            this.txtMora.TabIndex = 10;
            // 
            // labelMora
            // 
            this.labelMora.AutoSize = true;
            this.labelMora.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelMora.Location = new System.Drawing.Point(352, 179);
            this.labelMora.Name = "labelMora";
            this.labelMora.Size = new System.Drawing.Size(111, 17);
            this.labelMora.TabIndex = 9;
            this.labelMora.Text = "Mora acumulada:";
            // 
            // txtMontoCuota
            // 
            this.txtMontoCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoCuota.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoCuota.Location = new System.Drawing.Point(22, 199);
            this.txtMontoCuota.Name = "txtMontoCuota";
            this.txtMontoCuota.ReadOnly = true;
            this.txtMontoCuota.Size = new System.Drawing.Size(303, 22);
            this.txtMontoCuota.TabIndex = 8;
            // 
            // labelMontoCuota
            // 
            this.labelMontoCuota.AutoSize = true;
            this.labelMontoCuota.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMontoCuota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelMontoCuota.Location = new System.Drawing.Point(19, 179);
            this.labelMontoCuota.Name = "labelMontoCuota";
            this.labelMontoCuota.Size = new System.Drawing.Size(86, 17);
            this.labelMontoCuota.TabIndex = 7;
            this.labelMontoCuota.Text = "Monto cuota:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(642, 133);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(258, 22);
            this.textBox2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(639, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Periodo Correspondiente:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(355, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(258, 22);
            this.textBox1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(352, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Propiedad:";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(22, 133);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(303, 22);
            this.txtCliente.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(19, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cliente:";
            // 
            // btnBuscarCuota
            // 
            this.btnBuscarCuota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnBuscarCuota.FlatAppearance.BorderSize = 0;
            this.btnBuscarCuota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCuota.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCuota.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCuota.Location = new System.Drawing.Point(586, 15);
            this.btnBuscarCuota.Name = "btnBuscarCuota";
            this.btnBuscarCuota.Size = new System.Drawing.Size(80, 23);
            this.btnBuscarCuota.TabIndex = 0;
            this.btnBuscarCuota.Text = "Buscar";
            this.btnBuscarCuota.UseVisualStyleBackColor = false;
            // 
            // pnlPagoReservacion
            // 
            this.pnlPagoReservacion.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPagoReservacion.Controls.Add(this.txtBuscarReserv);
            this.pnlPagoReservacion.Controls.Add(this.lblResultadosReserv);
            this.pnlPagoReservacion.Controls.Add(this.cmbResultadosReserv);
            this.pnlPagoReservacion.Controls.Add(this.btnBuscarReserv);
            this.pnlPagoReservacion.Controls.Add(this.txtNumeroReciboR);
            this.pnlPagoReservacion.Controls.Add(this.labelReciboR);
            this.pnlPagoReservacion.Controls.Add(this.dtpFechaPagoR);
            this.pnlPagoReservacion.Controls.Add(this.labelFechaPagoR);
            this.pnlPagoReservacion.Controls.Add(this.cmbMetodoPagoR);
            this.pnlPagoReservacion.Controls.Add(this.labelMetodoPagoR);
            this.pnlPagoReservacion.Controls.Add(this.numMontoPagarR);
            this.pnlPagoReservacion.Controls.Add(this.labelMontoPagarR);
            this.pnlPagoReservacion.Controls.Add(this.txtSaldoPendienteR);
            this.pnlPagoReservacion.Controls.Add(this.labelSaldoR);
            this.pnlPagoReservacion.Controls.Add(this.txtMontoTotalR);
            this.pnlPagoReservacion.Controls.Add(this.labelMontoTotalR);
            this.pnlPagoReservacion.Controls.Add(this.txtPropiedadR);
            this.pnlPagoReservacion.Controls.Add(this.labelPropiedadR);
            this.pnlPagoReservacion.Controls.Add(this.txtClienteR);
            this.pnlPagoReservacion.Controls.Add(this.labelClienteR);
            this.pnlPagoReservacion.Location = new System.Drawing.Point(21, 100);
            this.pnlPagoReservacion.Name = "pnlPagoReservacion";
            this.pnlPagoReservacion.Size = new System.Drawing.Size(995, 370);
            this.pnlPagoReservacion.TabIndex = 6;
            this.pnlPagoReservacion.Visible = false;
            // 
            // txtNumeroReciboR
            // 
            this.txtNumeroReciboR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroReciboR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroReciboR.Location = new System.Drawing.Point(22, 331);
            this.txtNumeroReciboR.Name = "txtNumeroReciboR";
            this.txtNumeroReciboR.ReadOnly = true;
            this.txtNumeroReciboR.Size = new System.Drawing.Size(878, 22);
            this.txtNumeroReciboR.TabIndex = 18;
            // 
            // labelReciboR
            // 
            this.labelReciboR.AutoSize = true;
            this.labelReciboR.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReciboR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelReciboR.Location = new System.Drawing.Point(19, 311);
            this.labelReciboR.Name = "labelReciboR";
            this.labelReciboR.Size = new System.Drawing.Size(209, 17);
            this.labelReciboR.TabIndex = 17;
            this.labelReciboR.Text = "Número de recibo (autogenerado)";
            // 
            // dtpFechaPagoR
            // 
            this.dtpFechaPagoR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPagoR.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPagoR.Location = new System.Drawing.Point(642, 265);
            this.dtpFechaPagoR.Name = "dtpFechaPagoR";
            this.dtpFechaPagoR.Size = new System.Drawing.Size(258, 22);
            this.dtpFechaPagoR.TabIndex = 16;
            // 
            // labelFechaPagoR
            // 
            this.labelFechaPagoR.AutoSize = true;
            this.labelFechaPagoR.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaPagoR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelFechaPagoR.Location = new System.Drawing.Point(639, 245);
            this.labelFechaPagoR.Name = "labelFechaPagoR";
            this.labelFechaPagoR.Size = new System.Drawing.Size(95, 17);
            this.labelFechaPagoR.TabIndex = 15;
            this.labelFechaPagoR.Text = "Fecha de pago";
            // 
            // cmbMetodoPagoR
            // 
            this.cmbMetodoPagoR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPagoR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMetodoPagoR.FormattingEnabled = true;
            this.cmbMetodoPagoR.Location = new System.Drawing.Point(355, 265);
            this.cmbMetodoPagoR.Name = "cmbMetodoPagoR";
            this.cmbMetodoPagoR.Size = new System.Drawing.Size(258, 21);
            this.cmbMetodoPagoR.TabIndex = 14;
            // 
            // labelMetodoPagoR
            // 
            this.labelMetodoPagoR.AutoSize = true;
            this.labelMetodoPagoR.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMetodoPagoR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelMetodoPagoR.Location = new System.Drawing.Point(352, 245);
            this.labelMetodoPagoR.Name = "labelMetodoPagoR";
            this.labelMetodoPagoR.Size = new System.Drawing.Size(104, 17);
            this.labelMetodoPagoR.TabIndex = 13;
            this.labelMetodoPagoR.Text = "Método de pago";
            // 
            // numMontoPagarR
            // 
            this.numMontoPagarR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMontoPagarR.DecimalPlaces = 2;
            this.numMontoPagarR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMontoPagarR.Location = new System.Drawing.Point(22, 265);
            this.numMontoPagarR.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMontoPagarR.Name = "numMontoPagarR";
            this.numMontoPagarR.Size = new System.Drawing.Size(303, 22);
            this.numMontoPagarR.TabIndex = 12;
            // 
            // labelMontoPagarR
            // 
            this.labelMontoPagarR.AutoSize = true;
            this.labelMontoPagarR.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMontoPagarR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelMontoPagarR.Location = new System.Drawing.Point(19, 245);
            this.labelMontoPagarR.Name = "labelMontoPagarR";
            this.labelMontoPagarR.Size = new System.Drawing.Size(94, 17);
            this.labelMontoPagarR.TabIndex = 11;
            this.labelMontoPagarR.Text = "Monto a pagar";
            // 
            // txtSaldoPendienteR
            // 
            this.txtSaldoPendienteR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldoPendienteR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoPendienteR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.txtSaldoPendienteR.Location = new System.Drawing.Point(355, 199);
            this.txtSaldoPendienteR.Name = "txtSaldoPendienteR";
            this.txtSaldoPendienteR.ReadOnly = true;
            this.txtSaldoPendienteR.Size = new System.Drawing.Size(258, 22);
            this.txtSaldoPendienteR.TabIndex = 10;
            // 
            // labelSaldoR
            // 
            this.labelSaldoR.AutoSize = true;
            this.labelSaldoR.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaldoR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.labelSaldoR.Location = new System.Drawing.Point(352, 179);
            this.labelSaldoR.Name = "labelSaldoR";
            this.labelSaldoR.Size = new System.Drawing.Size(107, 17);
            this.labelSaldoR.TabIndex = 9;
            this.labelSaldoR.Text = "Saldo pendiente:";
            // 
            // txtMontoTotalR
            // 
            this.txtMontoTotalR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoTotalR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoTotalR.Location = new System.Drawing.Point(22, 199);
            this.txtMontoTotalR.Name = "txtMontoTotalR";
            this.txtMontoTotalR.ReadOnly = true;
            this.txtMontoTotalR.Size = new System.Drawing.Size(303, 22);
            this.txtMontoTotalR.TabIndex = 8;
            // 
            // labelMontoTotalR
            // 
            this.labelMontoTotalR.AutoSize = true;
            this.labelMontoTotalR.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMontoTotalR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelMontoTotalR.Location = new System.Drawing.Point(19, 179);
            this.labelMontoTotalR.Name = "labelMontoTotalR";
            this.labelMontoTotalR.Size = new System.Drawing.Size(124, 17);
            this.labelMontoTotalR.TabIndex = 7;
            this.labelMontoTotalR.Text = "Monto Reservación:";
            // 
            // txtPropiedadR
            // 
            this.txtPropiedadR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPropiedadR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPropiedadR.Location = new System.Drawing.Point(355, 133);
            this.txtPropiedadR.Name = "txtPropiedadR";
            this.txtPropiedadR.ReadOnly = true;
            this.txtPropiedadR.Size = new System.Drawing.Size(258, 22);
            this.txtPropiedadR.TabIndex = 6;
            // 
            // labelPropiedadR
            // 
            this.labelPropiedadR.AutoSize = true;
            this.labelPropiedadR.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropiedadR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelPropiedadR.Location = new System.Drawing.Point(352, 113);
            this.labelPropiedadR.Name = "labelPropiedadR";
            this.labelPropiedadR.Size = new System.Drawing.Size(72, 17);
            this.labelPropiedadR.TabIndex = 5;
            this.labelPropiedadR.Text = "Propiedad:";
            // 
            // txtClienteR
            // 
            this.txtClienteR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClienteR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteR.Location = new System.Drawing.Point(22, 133);
            this.txtClienteR.Name = "txtClienteR";
            this.txtClienteR.ReadOnly = true;
            this.txtClienteR.Size = new System.Drawing.Size(303, 22);
            this.txtClienteR.TabIndex = 4;
            // 
            // labelClienteR
            // 
            this.labelClienteR.AutoSize = true;
            this.labelClienteR.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.labelClienteR.Location = new System.Drawing.Point(19, 113);
            this.labelClienteR.Name = "labelClienteR";
            this.labelClienteR.Size = new System.Drawing.Size(52, 17);
            this.labelClienteR.TabIndex = 3;
            this.labelClienteR.Text = "Cliente:";
            // 
            // rbReservacion
            // 
            this.rbReservacion.AutoSize = true;
            this.rbReservacion.BackColor = System.Drawing.SystemColors.Control;
            this.rbReservacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbReservacion.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.rbReservacion.Location = new System.Drawing.Point(223, 73);
            this.rbReservacion.Name = "rbReservacion";
            this.rbReservacion.Size = new System.Drawing.Size(146, 21);
            this.rbReservacion.TabIndex = 4;
            this.rbReservacion.TabStop = true;
            this.rbReservacion.Text = "Pago de Reservación";
            this.rbReservacion.UseVisualStyleBackColor = false;
            this.rbReservacion.CheckedChanged += new System.EventHandler(this.rbTipoPago_CheckedChanged);
            // 
            // rbPagodeCuota
            // 
            this.rbPagodeCuota.AutoSize = true;
            this.rbPagodeCuota.BackColor = System.Drawing.SystemColors.Control;
            this.rbPagodeCuota.Checked = true;
            this.rbPagodeCuota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbPagodeCuota.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPagodeCuota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.rbPagodeCuota.Location = new System.Drawing.Point(43, 73);
            this.rbPagodeCuota.Name = "rbPagodeCuota";
            this.rbPagodeCuota.Size = new System.Drawing.Size(173, 21);
            this.rbPagodeCuota.TabIndex = 3;
            this.rbPagodeCuota.TabStop = true;
            this.rbPagodeCuota.Text = "Pago de Cuota (Contrato)";
            this.rbPagodeCuota.UseVisualStyleBackColor = false;
            this.rbPagodeCuota.CheckedChanged += new System.EventHandler(this.rbTipoPago_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(37, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de Pago:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTRO DE PAGO";
            // 
            // pnlAccion
            // 
            this.pnlAccion.BackColor = System.Drawing.Color.White;
            this.pnlAccion.Controls.Add(this.btnGuardar);
            this.pnlAccion.Controls.Add(this.btnLimpiar);
            this.pnlAccion.Location = new System.Drawing.Point(38, 571);
            this.pnlAccion.Name = "pnlAccion";
            this.pnlAccion.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlAccion.Size = new System.Drawing.Size(1042, 46);
            this.pnlAccion.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(249, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 30);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Pago";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLimpiar.Location = new System.Drawing.Point(43, 8);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 30);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar Formulario";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // cmbResultadosCuota
            // 
            this.cmbResultadosCuota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbResultadosCuota.FormattingEnabled = true;
            this.cmbResultadosCuota.Location = new System.Drawing.Point(25, 50);
            this.cmbResultadosCuota.Name = "cmbResultadosCuota";
            this.cmbResultadosCuota.Size = new System.Drawing.Size(536, 23);
            this.cmbResultadosCuota.TabIndex = 22;
            // 
            // lblResultadosCuota
            // 
            this.lblResultadosCuota.AutoSize = true;
            this.lblResultadosCuota.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadosCuota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblResultadosCuota.Location = new System.Drawing.Point(27, 82);
            this.lblResultadosCuota.Name = "lblResultadosCuota";
            this.lblResultadosCuota.Size = new System.Drawing.Size(17, 17);
            this.lblResultadosCuota.TabIndex = 23;
            this.lblResultadosCuota.Text = "...";
            // 
            // lblResultadosReserv
            // 
            this.lblResultadosReserv.AutoSize = true;
            this.lblResultadosReserv.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadosReserv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblResultadosReserv.Location = new System.Drawing.Point(27, 81);
            this.lblResultadosReserv.Name = "lblResultadosReserv";
            this.lblResultadosReserv.Size = new System.Drawing.Size(17, 17);
            this.lblResultadosReserv.TabIndex = 27;
            this.lblResultadosReserv.Text = "...";
            // 
            // cmbResultadosReserv
            // 
            this.cmbResultadosReserv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbResultadosReserv.FormattingEnabled = true;
            this.cmbResultadosReserv.Location = new System.Drawing.Point(25, 49);
            this.cmbResultadosReserv.Name = "cmbResultadosReserv";
            this.cmbResultadosReserv.Size = new System.Drawing.Size(536, 23);
            this.cmbResultadosReserv.TabIndex = 26;
            // 
            // btnBuscarReserv
            // 
            this.btnBuscarReserv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnBuscarReserv.FlatAppearance.BorderSize = 0;
            this.btnBuscarReserv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarReserv.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarReserv.ForeColor = System.Drawing.Color.White;
            this.btnBuscarReserv.Location = new System.Drawing.Point(586, 15);
            this.btnBuscarReserv.Name = "btnBuscarReserv";
            this.btnBuscarReserv.Size = new System.Drawing.Size(80, 23);
            this.btnBuscarReserv.TabIndex = 24;
            this.btnBuscarReserv.Text = "Buscar";
            this.btnBuscarReserv.UseVisualStyleBackColor = false;
            // 
            // txtBuscarCuota
            // 
            this.txtBuscarCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCuota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCuota.Location = new System.Drawing.Point(25, 15);
            this.txtBuscarCuota.Name = "txtBuscarCuota";
            this.txtBuscarCuota.Size = new System.Drawing.Size(536, 23);
            this.txtBuscarCuota.TabIndex = 24;
            // 
            // txtBuscarReserv
            // 
            this.txtBuscarReserv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarReserv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarReserv.Location = new System.Drawing.Point(25, 15);
            this.txtBuscarReserv.Name = "txtBuscarReserv";
            this.txtBuscarReserv.Size = new System.Drawing.Size(536, 23);
            this.txtBuscarReserv.TabIndex = 28;
            // 
            // PagosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 648);
            this.Controls.Add(this.pnlAccion);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnPagos);
            this.Name = "PagosForm";
            this.Text = "PagosForm";
            this.Load += new System.EventHandler(this.PagosForm_Load);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.pnlPagos.ResumeLayout(false);
            this.pnlPagos.PerformLayout();
            this.pnlPagodeCuota.ResumeLayout(false);
            this.pnlPagodeCuota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoPagar)).EndInit();
            this.pnlPagoReservacion.ResumeLayout(false);
            this.pnlPagoReservacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoPagarR)).EndInit();
            this.pnlAccion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlAccion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlPagos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.RadioButton rbPagodeCuota;
        private System.Windows.Forms.RadioButton rbReservacion;
        private System.Windows.Forms.Panel pnlPagodeCuota;
        private System.Windows.Forms.Button btnBuscarCuota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMontoCuota;
        private System.Windows.Forms.TextBox txtMontoCuota;
        private System.Windows.Forms.Label labelMora;
        private System.Windows.Forms.TextBox txtMora;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.TextBox txtSaldoPendiente;
        private System.Windows.Forms.Label labelMontoPagar;
        private System.Windows.Forms.NumericUpDown numMontoPagar;
        private System.Windows.Forms.Label labelMetodoPago;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label labelFechaPago;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label labelRecibo;
        private System.Windows.Forms.TextBox txtNumeroRecibo;
        private System.Windows.Forms.Panel pnlPagoReservacion;
        private System.Windows.Forms.Label labelClienteR;
        private System.Windows.Forms.TextBox txtClienteR;
        private System.Windows.Forms.Label labelPropiedadR;
        private System.Windows.Forms.TextBox txtPropiedadR;
        private System.Windows.Forms.Label labelMontoTotalR;
        private System.Windows.Forms.TextBox txtMontoTotalR;
        private System.Windows.Forms.Label labelSaldoR;
        private System.Windows.Forms.TextBox txtSaldoPendienteR;
        private System.Windows.Forms.Label labelMontoPagarR;
        private System.Windows.Forms.NumericUpDown numMontoPagarR;
        private System.Windows.Forms.Label labelMetodoPagoR;
        private System.Windows.Forms.ComboBox cmbMetodoPagoR;
        private System.Windows.Forms.Label labelFechaPagoR;
        private System.Windows.Forms.DateTimePicker dtpFechaPagoR;
        private System.Windows.Forms.Label labelReciboR;
        private System.Windows.Forms.TextBox txtNumeroReciboR;
        private System.Windows.Forms.Label lblResultadosCuota;
        private System.Windows.Forms.ComboBox cmbResultadosCuota;
        private System.Windows.Forms.Label lblResultadosReserv;
        private System.Windows.Forms.ComboBox cmbResultadosReserv;
        private System.Windows.Forms.Button btnBuscarReserv;
        private System.Windows.Forms.TextBox txtBuscarCuota;
        private System.Windows.Forms.TextBox txtBuscarReserv;
    }
}