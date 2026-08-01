namespace Gestion_de_Alquiler_y_Reservaciones
{
    partial class ReservacionesForm
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
            this.btnNuevaReservacion = new System.Windows.Forms.Button();
            this.btnHistorialReservaciones = new System.Windows.Forms.Button();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.pnlReservacion = new System.Windows.Forms.Panel();
            this.txtPersonas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblVDisponibilidad = new System.Windows.Forms.Label();
            this.lblVFechaSalida = new System.Windows.Forms.Label();
            this.lblVFechaEntrada = new System.Windows.Forms.Label();
            this.lblVCliente = new System.Windows.Forms.Label();
            this.lblVPropiedad = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpSalida = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEntrada = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPropiedad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlEditar = new System.Windows.Forms.Panel();
            this.lblVReservacion = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFechaSalida = new System.Windows.Forms.TextBox();
            this.txtFechaEntrada = new System.Windows.Forms.TextBox();
            this.txtPropiedadActu = new System.Windows.Forms.TextBox();
            this.cboReservacion = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtObservacionesActu = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMontoPagarActu = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtClienteActu = new System.Windows.Forms.TextBox();
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizarReservacion = new System.Windows.Forms.Button();
            this.pnlActualizar = new System.Windows.Forms.Panel();
            this.btnLimpiarActu = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtPersonasActu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlCuerpo.SuspendLayout();
            this.pnlReservacion.SuspendLayout();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.pnlEditar.SuspendLayout();
            this.pnlAccion.SuspendLayout();
            this.pnlActualizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevaReservacion
            // 
            this.btnNuevaReservacion.FlatAppearance.BorderSize = 0;
            this.btnNuevaReservacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaReservacion.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaReservacion.Location = new System.Drawing.Point(38, 12);
            this.btnNuevaReservacion.Name = "btnNuevaReservacion";
            this.btnNuevaReservacion.Size = new System.Drawing.Size(170, 34);
            this.btnNuevaReservacion.TabIndex = 0;
            this.btnNuevaReservacion.Text = "Nueva Reservación";
            this.btnNuevaReservacion.UseVisualStyleBackColor = true;
            this.btnNuevaReservacion.Click += new System.EventHandler(this.btnNuevaReservacion_Click);
            // 
            // btnHistorialReservaciones
            // 
            this.btnHistorialReservaciones.FlatAppearance.BorderSize = 0;
            this.btnHistorialReservaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialReservaciones.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialReservaciones.Location = new System.Drawing.Point(408, 12);
            this.btnHistorialReservaciones.Name = "btnHistorialReservaciones";
            this.btnHistorialReservaciones.Size = new System.Drawing.Size(188, 34);
            this.btnHistorialReservaciones.TabIndex = 1;
            this.btnHistorialReservaciones.Text = "Historial de Reservaciones";
            this.btnHistorialReservaciones.UseVisualStyleBackColor = true;
            this.btnHistorialReservaciones.Click += new System.EventHandler(this.btnHistorialReservaciones_Click);
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.pnlEditar);
            this.pnlCuerpo.Controls.Add(this.pnlReservacion);
            this.pnlCuerpo.Controls.Add(this.pnlHistorial);
            this.pnlCuerpo.Location = new System.Drawing.Point(38, 75);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1042, 486);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // pnlReservacion
            // 
            this.pnlReservacion.Controls.Add(this.txtPersonas);
            this.pnlReservacion.Controls.Add(this.label10);
            this.pnlReservacion.Controls.Add(this.lblVDisponibilidad);
            this.pnlReservacion.Controls.Add(this.lblVFechaSalida);
            this.pnlReservacion.Controls.Add(this.lblVFechaEntrada);
            this.pnlReservacion.Controls.Add(this.lblVCliente);
            this.pnlReservacion.Controls.Add(this.lblVPropiedad);
            this.pnlReservacion.Controls.Add(this.txtObservaciones);
            this.pnlReservacion.Controls.Add(this.label7);
            this.pnlReservacion.Controls.Add(this.txtMonto);
            this.pnlReservacion.Controls.Add(this.label6);
            this.pnlReservacion.Controls.Add(this.dtpSalida);
            this.pnlReservacion.Controls.Add(this.label5);
            this.pnlReservacion.Controls.Add(this.dtpEntrada);
            this.pnlReservacion.Controls.Add(this.label4);
            this.pnlReservacion.Controls.Add(this.label3);
            this.pnlReservacion.Controls.Add(this.cboPropiedad);
            this.pnlReservacion.Controls.Add(this.label2);
            this.pnlReservacion.Controls.Add(this.label1);
            this.pnlReservacion.Controls.Add(this.txtCliente);
            this.pnlReservacion.Location = new System.Drawing.Point(0, 0);
            this.pnlReservacion.Name = "pnlReservacion";
            this.pnlReservacion.Size = new System.Drawing.Size(1036, 480);
            this.pnlReservacion.TabIndex = 0;
            // 
            // txtPersonas
            // 
            this.txtPersonas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersonas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonas.Location = new System.Drawing.Point(383, 347);
            this.txtPersonas.MaxLength = 200;
            this.txtPersonas.Name = "txtPersonas";
            this.txtPersonas.Size = new System.Drawing.Size(137, 22);
            this.txtPersonas.TabIndex = 21;
            this.txtPersonas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersonas_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label10.Location = new System.Drawing.Point(380, 327);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Cantidad de Personas:";
            // 
            // lblVDisponibilidad
            // 
            this.lblVDisponibilidad.AutoSize = true;
            this.lblVDisponibilidad.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVDisponibilidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVDisponibilidad.Location = new System.Drawing.Point(39, 301);
            this.lblVDisponibilidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVDisponibilidad.Name = "lblVDisponibilidad";
            this.lblVDisponibilidad.Size = new System.Drawing.Size(285, 17);
            this.lblVDisponibilidad.TabIndex = 19;
            this.lblVDisponibilidad.Text = "La propiedad ya está reservada en esas fechas.";
            this.lblVDisponibilidad.Visible = false;
            // 
            // lblVFechaSalida
            // 
            this.lblVFechaSalida.AutoSize = true;
            this.lblVFechaSalida.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVFechaSalida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVFechaSalida.Location = new System.Drawing.Point(244, 278);
            this.lblVFechaSalida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVFechaSalida.Name = "lblVFechaSalida";
            this.lblVFechaSalida.Size = new System.Drawing.Size(73, 17);
            this.lblVFechaSalida.TabIndex = 17;
            this.lblVFechaSalida.Text = "Obligatorio";
            // 
            // lblVFechaEntrada
            // 
            this.lblVFechaEntrada.AutoSize = true;
            this.lblVFechaEntrada.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVFechaEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVFechaEntrada.Location = new System.Drawing.Point(245, 216);
            this.lblVFechaEntrada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVFechaEntrada.Name = "lblVFechaEntrada";
            this.lblVFechaEntrada.Size = new System.Drawing.Size(73, 17);
            this.lblVFechaEntrada.TabIndex = 16;
            this.lblVFechaEntrada.Text = "Obligatorio";
            // 
            // lblVCliente
            // 
            this.lblVCliente.AutoSize = true;
            this.lblVCliente.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVCliente.Location = new System.Drawing.Point(358, 153);
            this.lblVCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVCliente.Name = "lblVCliente";
            this.lblVCliente.Size = new System.Drawing.Size(73, 17);
            this.lblVCliente.TabIndex = 15;
            this.lblVCliente.Text = "Obligatorio";
            // 
            // lblVPropiedad
            // 
            this.lblVPropiedad.AutoSize = true;
            this.lblVPropiedad.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVPropiedad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVPropiedad.Location = new System.Drawing.Point(339, 89);
            this.lblVPropiedad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVPropiedad.Name = "lblVPropiedad";
            this.lblVPropiedad.Size = new System.Drawing.Size(73, 17);
            this.lblVPropiedad.TabIndex = 14;
            this.lblVPropiedad.Text = "Obligatorio";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(40, 403);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(577, 50);
            this.txtObservaciones.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(37, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Observaciones:";
            // 
            // txtMonto
            // 
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(40, 347);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(200, 22);
            this.txtMonto.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(37, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Monto a pagar:";
            // 
            // dtpSalida
            // 
            this.dtpSalida.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSalida.Location = new System.Drawing.Point(40, 276);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(200, 20);
            this.dtpSalida.TabIndex = 8;
            this.dtpSalida.ValueChanged += new System.EventHandler(this.dtpSalida_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(37, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha Salida:";
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntrada.Location = new System.Drawing.Point(40, 214);
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(200, 20);
            this.dtpEntrada.TabIndex = 6;
            this.dtpEntrada.ValueChanged += new System.EventHandler(this.dtpEntrada_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(37, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha Entrada:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(37, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cliente:";
            // 
            // cboPropiedad
            // 
            this.cboPropiedad.FormattingEnabled = true;
            this.cboPropiedad.Location = new System.Drawing.Point(40, 87);
            this.cboPropiedad.Name = "cboPropiedad";
            this.cboPropiedad.Size = new System.Drawing.Size(293, 21);
            this.cboPropiedad.TabIndex = 3;
            this.cboPropiedad.Text = "--Seleccionar--";
            this.cboPropiedad.SelectedIndexChanged += new System.EventHandler(this.cboPropiedad_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label2.Location = new System.Drawing.Point(36, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "CREACIÓN DE NUEVA RESERVACIÓN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(37, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Propiedad:";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(40, 150);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(313, 22);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHistorial.Controls.Add(this.dgvHistorial);
            this.pnlHistorial.Controls.Add(this.pnlBuscar);
            this.pnlHistorial.Location = new System.Drawing.Point(0, 0);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1036, 480);
            this.pnlHistorial.TabIndex = 13;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(3, 64);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1033, 416);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistorial_CellFormatting);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.White;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.label8);
            this.pnlBuscar.Location = new System.Drawing.Point(3, 3);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(1033, 60);
            this.pnlBuscar.TabIndex = 0;
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
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(73, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(320, 23);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label8.Location = new System.Drawing.Point(15, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Buscar:";
            // 
            // pnlEditar
            // 
            this.pnlEditar.Controls.Add(this.txtPersonasActu);
            this.pnlEditar.Controls.Add(this.label11);
            this.pnlEditar.Controls.Add(this.lblVReservacion);
            this.pnlEditar.Controls.Add(this.cboEstado);
            this.pnlEditar.Controls.Add(this.label9);
            this.pnlEditar.Controls.Add(this.txtFechaSalida);
            this.pnlEditar.Controls.Add(this.txtFechaEntrada);
            this.pnlEditar.Controls.Add(this.txtPropiedadActu);
            this.pnlEditar.Controls.Add(this.cboReservacion);
            this.pnlEditar.Controls.Add(this.label21);
            this.pnlEditar.Controls.Add(this.txtObservacionesActu);
            this.pnlEditar.Controls.Add(this.label14);
            this.pnlEditar.Controls.Add(this.txtMontoPagarActu);
            this.pnlEditar.Controls.Add(this.label15);
            this.pnlEditar.Controls.Add(this.label16);
            this.pnlEditar.Controls.Add(this.label17);
            this.pnlEditar.Controls.Add(this.label18);
            this.pnlEditar.Controls.Add(this.label19);
            this.pnlEditar.Controls.Add(this.label20);
            this.pnlEditar.Controls.Add(this.txtClienteActu);
            this.pnlEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditar.Location = new System.Drawing.Point(0, 0);
            this.pnlEditar.Name = "pnlEditar";
            this.pnlEditar.Size = new System.Drawing.Size(1042, 486);
            this.pnlEditar.TabIndex = 19;
            // 
            // lblVReservacion
            // 
            this.lblVReservacion.AutoSize = true;
            this.lblVReservacion.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVReservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVReservacion.Location = new System.Drawing.Point(721, 26);
            this.lblVReservacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVReservacion.Name = "lblVReservacion";
            this.lblVReservacion.Size = new System.Drawing.Size(39, 17);
            this.lblVReservacion.TabIndex = 44;
            this.lblVReservacion.Text = "texto";
            this.lblVReservacion.Visible = false;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboEstado.Location = new System.Drawing.Point(40, 424);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(219, 21);
            this.cboEstado.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label9.Location = new System.Drawing.Point(40, 404);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "Estado:";
            // 
            // txtFechaSalida
            // 
            this.txtFechaSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaSalida.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaSalida.Location = new System.Drawing.Point(370, 212);
            this.txtFechaSalida.Name = "txtFechaSalida";
            this.txtFechaSalida.ReadOnly = true;
            this.txtFechaSalida.Size = new System.Drawing.Size(248, 22);
            this.txtFechaSalida.TabIndex = 41;
            // 
            // txtFechaEntrada
            // 
            this.txtFechaEntrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaEntrada.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEntrada.Location = new System.Drawing.Point(40, 214);
            this.txtFechaEntrada.Name = "txtFechaEntrada";
            this.txtFechaEntrada.ReadOnly = true;
            this.txtFechaEntrada.Size = new System.Drawing.Size(248, 22);
            this.txtFechaEntrada.TabIndex = 40;
            // 
            // txtPropiedadActu
            // 
            this.txtPropiedadActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPropiedadActu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPropiedadActu.Location = new System.Drawing.Point(40, 88);
            this.txtPropiedadActu.Name = "txtPropiedadActu";
            this.txtPropiedadActu.ReadOnly = true;
            this.txtPropiedadActu.Size = new System.Drawing.Size(313, 22);
            this.txtPropiedadActu.TabIndex = 39;
            // 
            // cboReservacion
            // 
            this.cboReservacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReservacion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReservacion.FormattingEnabled = true;
            this.cboReservacion.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboReservacion.Location = new System.Drawing.Point(497, 27);
            this.cboReservacion.Name = "cboReservacion";
            this.cboReservacion.Size = new System.Drawing.Size(219, 21);
            this.cboReservacion.TabIndex = 38;
            this.cboReservacion.SelectedIndexChanged += new System.EventHandler(this.cboReservacion_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label21.Location = new System.Drawing.Point(408, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 17);
            this.label21.TabIndex = 37;
            this.label21.Text = "Reservación:";
            // 
            // txtObservacionesActu
            // 
            this.txtObservacionesActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacionesActu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionesActu.Location = new System.Drawing.Point(40, 339);
            this.txtObservacionesActu.Multiline = true;
            this.txtObservacionesActu.Name = "txtObservacionesActu";
            this.txtObservacionesActu.Size = new System.Drawing.Size(577, 50);
            this.txtObservacionesActu.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label14.Location = new System.Drawing.Point(40, 319);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "Observaciones:";
            // 
            // txtMontoPagarActu
            // 
            this.txtMontoPagarActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoPagarActu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPagarActu.Location = new System.Drawing.Point(40, 276);
            this.txtMontoPagarActu.Name = "txtMontoPagarActu";
            this.txtMontoPagarActu.ReadOnly = true;
            this.txtMontoPagarActu.Size = new System.Drawing.Size(200, 22);
            this.txtMontoPagarActu.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label15.Location = new System.Drawing.Point(40, 256);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 17);
            this.label15.TabIndex = 28;
            this.label15.Text = "Monto a pagar:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label16.Location = new System.Drawing.Point(367, 194);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 17);
            this.label16.TabIndex = 26;
            this.label16.Text = "Fecha Salida:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label17.Location = new System.Drawing.Point(40, 194);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 17);
            this.label17.TabIndex = 24;
            this.label17.Text = "Fecha Entrada:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label18.Location = new System.Drawing.Point(40, 131);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 17);
            this.label18.TabIndex = 23;
            this.label18.Text = "Cliente:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label19.Location = new System.Drawing.Point(39, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(284, 24);
            this.label19.TabIndex = 21;
            this.label19.Text = "ACTUALIZACIÓN DE RESERVACIÓN";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label20.Location = new System.Drawing.Point(40, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 17);
            this.label20.TabIndex = 20;
            this.label20.Text = "Propiedad:";
            // 
            // txtClienteActu
            // 
            this.txtClienteActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClienteActu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteActu.Location = new System.Drawing.Point(40, 151);
            this.txtClienteActu.Name = "txtClienteActu";
            this.txtClienteActu.ReadOnly = true;
            this.txtClienteActu.Size = new System.Drawing.Size(313, 22);
            this.txtClienteActu.TabIndex = 19;
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
            this.pnlAccion.TabIndex = 0;
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
            this.btnGuardar.Text = "Guardar Reservación";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizarReservacion
            // 
            this.btnActualizarReservacion.FlatAppearance.BorderSize = 0;
            this.btnActualizarReservacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarReservacion.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarReservacion.Location = new System.Drawing.Point(214, 12);
            this.btnActualizarReservacion.Name = "btnActualizarReservacion";
            this.btnActualizarReservacion.Size = new System.Drawing.Size(188, 34);
            this.btnActualizarReservacion.TabIndex = 3;
            this.btnActualizarReservacion.Text = "Actualización de Reservación";
            this.btnActualizarReservacion.UseVisualStyleBackColor = true;
            this.btnActualizarReservacion.Click += new System.EventHandler(this.btnActualizarReservacion_Click);
            // 
            // pnlActualizar
            // 
            this.pnlActualizar.BackColor = System.Drawing.Color.White;
            this.pnlActualizar.Controls.Add(this.btnLimpiarActu);
            this.pnlActualizar.Controls.Add(this.btnActualizar);
            this.pnlActualizar.Location = new System.Drawing.Point(38, 571);
            this.pnlActualizar.Name = "pnlActualizar";
            this.pnlActualizar.Size = new System.Drawing.Size(1042, 46);
            this.pnlActualizar.TabIndex = 44;
            // 
            // btnLimpiarActu
            // 
            this.btnLimpiarActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLimpiarActu.FlatAppearance.BorderSize = 0;
            this.btnLimpiarActu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarActu.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarActu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLimpiarActu.Location = new System.Drawing.Point(43, 8);
            this.btnLimpiarActu.Name = "btnLimpiarActu";
            this.btnLimpiarActu.Size = new System.Drawing.Size(200, 30);
            this.btnLimpiarActu.TabIndex = 45;
            this.btnLimpiarActu.Text = "Limpiar Formulario";
            this.btnLimpiarActu.UseVisualStyleBackColor = false;
            this.btnLimpiarActu.Click += new System.EventHandler(this.btnLimpiarActu_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(249, 8);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(200, 30);
            this.btnActualizar.TabIndex = 45;
            this.btnActualizar.Text = "Actualizar Reservación";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtPersonasActu
            // 
            this.txtPersonasActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersonasActu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonasActu.Location = new System.Drawing.Point(370, 276);
            this.txtPersonasActu.MaxLength = 200;
            this.txtPersonasActu.Name = "txtPersonasActu";
            this.txtPersonasActu.ReadOnly = true;
            this.txtPersonasActu.Size = new System.Drawing.Size(137, 22);
            this.txtPersonasActu.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label11.Location = new System.Drawing.Point(367, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 17);
            this.label11.TabIndex = 45;
            this.label11.Text = "Cantidad de Personas:";
            // 
            // ReservacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 648);
            this.Controls.Add(this.pnlActualizar);
            this.Controls.Add(this.pnlAccion);
            this.Controls.Add(this.btnActualizarReservacion);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.btnHistorialReservaciones);
            this.Controls.Add(this.btnNuevaReservacion);
            this.Name = "ReservacionesForm";
            this.Text = "ReservacionesForm";
            this.Load += new System.EventHandler(this.ReservacionesForm_Load);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlReservacion.ResumeLayout(false);
            this.pnlReservacion.PerformLayout();
            this.pnlHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.pnlEditar.ResumeLayout(false);
            this.pnlEditar.PerformLayout();
            this.pnlAccion.ResumeLayout(false);
            this.pnlActualizar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaReservacion;
        private System.Windows.Forms.Button btnHistorialReservaciones;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlAccion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlReservacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPropiedad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpSalida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEntrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblVPropiedad;
        private System.Windows.Forms.Label lblVCliente;
        private System.Windows.Forms.Label lblVFechaSalida;
        private System.Windows.Forms.Label lblVFechaEntrada;
        private System.Windows.Forms.Label lblVDisponibilidad;
        private System.Windows.Forms.Button btnActualizarReservacion;
        private System.Windows.Forms.Panel pnlEditar;
        private System.Windows.Forms.TextBox txtObservacionesActu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtClienteActu;
        private System.Windows.Forms.ComboBox cboReservacion;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPropiedadActu;
        private System.Windows.Forms.TextBox txtFechaSalida;
        private System.Windows.Forms.TextBox txtFechaEntrada;
        private System.Windows.Forms.TextBox txtMontoPagarActu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlActualizar;
        private System.Windows.Forms.Button btnLimpiarActu;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblVReservacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPersonas;
        private System.Windows.Forms.TextBox txtPersonasActu;
        private System.Windows.Forms.Label label11;
    }
}