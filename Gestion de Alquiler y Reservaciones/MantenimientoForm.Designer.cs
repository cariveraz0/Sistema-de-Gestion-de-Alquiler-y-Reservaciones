namespace Gestion_de_Alquiler_y_Reservaciones
{
    partial class MantenimientoForm
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
            this.btnSolicitud = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.pnlNueva = new System.Windows.Forms.Panel();
            this.lblOFecha = new System.Windows.Forms.Label();
            this.lblOTipo = new System.Windows.Forms.Label();
            this.lblOTecnico = new System.Windows.Forms.Label();
            this.lblOPropiedad = new System.Windows.Forms.Label();
            this.dtpProgramada = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTecnico = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPropiedad = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlEditar = new System.Windows.Forms.Panel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboSolicitud = new System.Windows.Forms.ComboBox();
            this.dtpConclusion = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescripcionActu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlActualizar = new System.Windows.Forms.Panel();
            this.btnActualizarSoli = new System.Windows.Forms.Button();
            this.btnLimpiarActu = new System.Windows.Forms.Button();
            this.txtPropiedadActu = new System.Windows.Forms.TextBox();
            this.txtTecnicoActu = new System.Windows.Forms.TextBox();
            this.pnlCuerpo.SuspendLayout();
            this.pnlNueva.SuspendLayout();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.pnlEditar.SuspendLayout();
            this.pnlAccion.SuspendLayout();
            this.pnlActualizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSolicitud
            // 
            this.btnSolicitud.AccessibleName = "btnSolicitud";
            this.btnSolicitud.FlatAppearance.BorderSize = 0;
            this.btnSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitud.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitud.Location = new System.Drawing.Point(51, 15);
            this.btnSolicitud.Margin = new System.Windows.Forms.Padding(4);
            this.btnSolicitud.Name = "btnSolicitud";
            this.btnSolicitud.Size = new System.Drawing.Size(227, 55);
            this.btnSolicitud.TabIndex = 0;
            this.btnSolicitud.Text = "Nueva Solicitud de Mantenimiento";
            this.btnSolicitud.UseVisualStyleBackColor = true;
            this.btnSolicitud.Click += new System.EventHandler(this.btnSolicitud_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.AccessibleName = "btnHistorial";
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.Location = new System.Drawing.Point(529, 15);
            this.btnHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(227, 55);
            this.btnHistorial.TabIndex = 1;
            this.btnHistorial.Text = "Historial de Mantenimiento";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.pnlEditar);
            this.pnlCuerpo.Controls.Add(this.pnlNueva);
            this.pnlCuerpo.Controls.Add(this.pnlHistorial);
            this.pnlCuerpo.Location = new System.Drawing.Point(51, 92);
            this.pnlCuerpo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1389, 598);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // pnlNueva
            // 
            this.pnlNueva.Controls.Add(this.lblOFecha);
            this.pnlNueva.Controls.Add(this.lblOTipo);
            this.pnlNueva.Controls.Add(this.lblOTecnico);
            this.pnlNueva.Controls.Add(this.lblOPropiedad);
            this.pnlNueva.Controls.Add(this.dtpProgramada);
            this.pnlNueva.Controls.Add(this.label6);
            this.pnlNueva.Controls.Add(this.label5);
            this.pnlNueva.Controls.Add(this.cboTipo);
            this.pnlNueva.Controls.Add(this.label4);
            this.pnlNueva.Controls.Add(this.cboTecnico);
            this.pnlNueva.Controls.Add(this.label3);
            this.pnlNueva.Controls.Add(this.cboPropiedad);
            this.pnlNueva.Controls.Add(this.txtDescripcion);
            this.pnlNueva.Controls.Add(this.label2);
            this.pnlNueva.Controls.Add(this.label1);
            this.pnlNueva.Location = new System.Drawing.Point(0, 0);
            this.pnlNueva.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNueva.Name = "pnlNueva";
            this.pnlNueva.Size = new System.Drawing.Size(1381, 591);
            this.pnlNueva.TabIndex = 0;
            // 
            // lblOFecha
            // 
            this.lblOFecha.AutoSize = true;
            this.lblOFecha.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblOFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOFecha.Location = new System.Drawing.Point(325, 433);
            this.lblOFecha.Name = "lblOFecha";
            this.lblOFecha.Size = new System.Drawing.Size(93, 22);
            this.lblOFecha.TabIndex = 17;
            this.lblOFecha.Text = "Obligatorio";
            // 
            // lblOTipo
            // 
            this.lblOTipo.AutoSize = true;
            this.lblOTipo.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblOTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOTipo.Location = new System.Drawing.Point(449, 262);
            this.lblOTipo.Name = "lblOTipo";
            this.lblOTipo.Size = new System.Drawing.Size(93, 22);
            this.lblOTipo.TabIndex = 16;
            this.lblOTipo.Text = "Obligatorio";
            // 
            // lblOTecnico
            // 
            this.lblOTecnico.AutoSize = true;
            this.lblOTecnico.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblOTecnico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOTecnico.Location = new System.Drawing.Point(449, 185);
            this.lblOTecnico.Name = "lblOTecnico";
            this.lblOTecnico.Size = new System.Drawing.Size(93, 22);
            this.lblOTecnico.TabIndex = 15;
            this.lblOTecnico.Text = "Obligatorio";
            // 
            // lblOPropiedad
            // 
            this.lblOPropiedad.AutoSize = true;
            this.lblOPropiedad.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblOPropiedad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOPropiedad.Location = new System.Drawing.Point(449, 107);
            this.lblOPropiedad.Name = "lblOPropiedad";
            this.lblOPropiedad.Size = new System.Drawing.Size(93, 22);
            this.lblOPropiedad.TabIndex = 14;
            this.lblOPropiedad.Text = "Obligatorio";
            // 
            // dtpProgramada
            // 
            this.dtpProgramada.AccessibleName = "dtpProgramada";
            this.dtpProgramada.Location = new System.Drawing.Point(53, 433);
            this.dtpProgramada.Margin = new System.Windows.Forms.Padding(4);
            this.dtpProgramada.Name = "dtpProgramada";
            this.dtpProgramada.Size = new System.Drawing.Size(265, 22);
            this.dtpProgramada.TabIndex = 10;
            this.dtpProgramada.ValueChanged += new System.EventHandler(this.dtpProgramada_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(49, 407);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha Programada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(49, 319);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Descripción:";
            // 
            // cboTipo
            // 
            this.cboTipo.AccessibleName = "cboTipo";
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboTipo.Location = new System.Drawing.Point(53, 265);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(389, 24);
            this.cboTipo.TabIndex = 7;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(49, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de Mantenimiento:";
            // 
            // cboTecnico
            // 
            this.cboTecnico.AccessibleName = "cboTecnico";
            this.cboTecnico.FormattingEnabled = true;
            this.cboTecnico.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboTecnico.Location = new System.Drawing.Point(53, 185);
            this.cboTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.cboTecnico.Name = "cboTecnico";
            this.cboTecnico.Size = new System.Drawing.Size(389, 24);
            this.cboTecnico.TabIndex = 5;
            this.cboTecnico.SelectedIndexChanged += new System.EventHandler(this.cboTecnico_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(49, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Técnico Asignado:";
            // 
            // cboPropiedad
            // 
            this.cboPropiedad.AccessibleName = "cboPropiedad";
            this.cboPropiedad.FormattingEnabled = true;
            this.cboPropiedad.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboPropiedad.Location = new System.Drawing.Point(53, 107);
            this.cboPropiedad.Margin = new System.Windows.Forms.Padding(4);
            this.cboPropiedad.Name = "cboPropiedad";
            this.cboPropiedad.Size = new System.Drawing.Size(389, 24);
            this.cboPropiedad.TabIndex = 3;
            this.cboPropiedad.SelectedIndexChanged += new System.EventHandler(this.cboPropiedad_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AccessibleName = "txtDescripcion";
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(53, 342);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(769, 26);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(49, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Propiedad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(48, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(556, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "CREACIÓN DE NUEVA SOLICITUD DE MANTENIMIENTO";
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHistorial.Controls.Add(this.dgvHistorial);
            this.pnlHistorial.Controls.Add(this.pnlBuscar);
            this.pnlHistorial.Location = new System.Drawing.Point(0, 0);
            this.pnlHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1373, 583);
            this.pnlHistorial.TabIndex = 11;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AccessibleName = "dgvHistorial";
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(4, 79);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1369, 505);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistorial_CellFormatting);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.White;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.label7);
            this.pnlBuscar.Location = new System.Drawing.Point(4, 4);
            this.pnlBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(1377, 74);
            this.pnlBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleName = "btnBuscar";
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(544, 20);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 33);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.AccessibleName = "txtBuscar";
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(97, 23);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(426, 27);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(20, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Buscar:";
            // 
            // pnlEditar
            // 
            this.pnlEditar.Controls.Add(this.txtTecnicoActu);
            this.pnlEditar.Controls.Add(this.txtPropiedadActu);
            this.pnlEditar.Controls.Add(this.cmbEstado);
            this.pnlEditar.Controls.Add(this.label15);
            this.pnlEditar.Controls.Add(this.txtCosto);
            this.pnlEditar.Controls.Add(this.label14);
            this.pnlEditar.Controls.Add(this.cboSolicitud);
            this.pnlEditar.Controls.Add(this.dtpConclusion);
            this.pnlEditar.Controls.Add(this.label8);
            this.pnlEditar.Controls.Add(this.label9);
            this.pnlEditar.Controls.Add(this.label10);
            this.pnlEditar.Controls.Add(this.label11);
            this.pnlEditar.Controls.Add(this.txtDescripcionActu);
            this.pnlEditar.Controls.Add(this.label12);
            this.pnlEditar.Controls.Add(this.label13);
            this.pnlEditar.Location = new System.Drawing.Point(0, 0);
            this.pnlEditar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEditar.Name = "pnlEditar";
            this.pnlEditar.Size = new System.Drawing.Size(1385, 594);
            this.pnlEditar.TabIndex = 11;
            // 
            // cmbEstado
            // 
            this.cmbEstado.AccessibleName = "cmbEstado";
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(53, 534);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(265, 24);
            this.cmbEstado.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label15.Location = new System.Drawing.Point(49, 509);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 22);
            this.label15.TabIndex = 25;
            this.label15.Text = "Estado:";
            // 
            // txtCosto
            // 
            this.txtCosto.AccessibleName = "txtCosto";
            this.txtCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCosto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtCosto.Location = new System.Drawing.Point(53, 262);
            this.txtCosto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(235, 26);
            this.txtCosto.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label14.Location = new System.Drawing.Point(684, 32);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 22);
            this.label14.TabIndex = 23;
            this.label14.Text = "Solicitud:";
            // 
            // cboSolicitud
            // 
            this.cboSolicitud.AccessibleName = "cboSolicitud";
            this.cboSolicitud.FormattingEnabled = true;
            this.cboSolicitud.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboSolicitud.Location = new System.Drawing.Point(775, 30);
            this.cboSolicitud.Margin = new System.Windows.Forms.Padding(4);
            this.cboSolicitud.Name = "cboSolicitud";
            this.cboSolicitud.Size = new System.Drawing.Size(253, 24);
            this.cboSolicitud.TabIndex = 22;
            this.cboSolicitud.SelectedIndexChanged += new System.EventHandler(this.cboSolicitud_SelectedIndexChanged);
            // 
            // dtpConclusion
            // 
            this.dtpConclusion.AccessibleName = "dtpConclusion";
            this.dtpConclusion.Location = new System.Drawing.Point(53, 458);
            this.dtpConclusion.Margin = new System.Windows.Forms.Padding(4);
            this.dtpConclusion.Name = "dtpConclusion";
            this.dtpConclusion.Size = new System.Drawing.Size(265, 22);
            this.dtpConclusion.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label8.Location = new System.Drawing.Point(49, 433);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 22);
            this.label8.TabIndex = 20;
            this.label8.Text = "Fecha Conclusión:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label9.Location = new System.Drawing.Point(49, 318);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 22);
            this.label9.TabIndex = 19;
            this.label9.Text = "Descripción:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label10.Location = new System.Drawing.Point(49, 239);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 22);
            this.label10.TabIndex = 17;
            this.label10.Text = "Costo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label11.Location = new System.Drawing.Point(49, 160);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 22);
            this.label11.TabIndex = 15;
            this.label11.Text = "Técnico Asignado:";
            // 
            // txtDescripcionActu
            // 
            this.txtDescripcionActu.AccessibleName = "txtDescripcionActu";
            this.txtDescripcionActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcionActu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtDescripcionActu.Location = new System.Drawing.Point(53, 341);
            this.txtDescripcionActu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcionActu.Multiline = true;
            this.txtDescripcionActu.Name = "txtDescripcionActu";
            this.txtDescripcionActu.Size = new System.Drawing.Size(769, 84);
            this.txtDescripcionActu.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label12.Location = new System.Drawing.Point(49, 82);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 22);
            this.label12.TabIndex = 12;
            this.label12.Text = "Propiedad:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label13.Location = new System.Drawing.Point(48, 27);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(540, 30);
            this.label13.TabIndex = 11;
            this.label13.Text = "ACTUALIZACIÓN DE SOLICITUD DE MANTENIMIENTO";
            // 
            // pnlAccion
            // 
            this.pnlAccion.BackColor = System.Drawing.Color.White;
            this.pnlAccion.Controls.Add(this.btnGuardar);
            this.pnlAccion.Controls.Add(this.btnLimpiar);
            this.pnlAccion.Location = new System.Drawing.Point(51, 703);
            this.pnlAccion.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAccion.Name = "pnlAccion";
            this.pnlAccion.Padding = new System.Windows.Forms.Padding(13, 10, 13, 10);
            this.pnlAccion.Size = new System.Drawing.Size(1389, 57);
            this.pnlAccion.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(332, 10);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(267, 37);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Solicitud";
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
            this.btnLimpiar.Location = new System.Drawing.Point(57, 10);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(267, 37);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar Formulario";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.AccessibleName = "btnActualizar";
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(285, 15);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(236, 55);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualización de Solicitud de Mantenimiento";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pnlActualizar
            // 
            this.pnlActualizar.BackColor = System.Drawing.Color.White;
            this.pnlActualizar.Controls.Add(this.btnActualizarSoli);
            this.pnlActualizar.Controls.Add(this.btnLimpiarActu);
            this.pnlActualizar.Location = new System.Drawing.Point(51, 703);
            this.pnlActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlActualizar.Name = "pnlActualizar";
            this.pnlActualizar.Size = new System.Drawing.Size(1389, 57);
            this.pnlActualizar.TabIndex = 2;
            // 
            // btnActualizarSoli
            // 
            this.btnActualizarSoli.AccessibleName = "btnActualizarSoli";
            this.btnActualizarSoli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnActualizarSoli.FlatAppearance.BorderSize = 0;
            this.btnActualizarSoli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarSoli.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarSoli.ForeColor = System.Drawing.Color.White;
            this.btnActualizarSoli.Location = new System.Drawing.Point(332, 10);
            this.btnActualizarSoli.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizarSoli.Name = "btnActualizarSoli";
            this.btnActualizarSoli.Size = new System.Drawing.Size(267, 37);
            this.btnActualizarSoli.TabIndex = 3;
            this.btnActualizarSoli.Text = "Actualizar Solicitud";
            this.btnActualizarSoli.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarActu
            // 
            this.btnLimpiarActu.AccessibleName = "btnLimpiarActu";
            this.btnLimpiarActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLimpiarActu.FlatAppearance.BorderSize = 0;
            this.btnLimpiarActu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarActu.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarActu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLimpiarActu.Location = new System.Drawing.Point(57, 10);
            this.btnLimpiarActu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiarActu.Name = "btnLimpiarActu";
            this.btnLimpiarActu.Size = new System.Drawing.Size(267, 37);
            this.btnLimpiarActu.TabIndex = 2;
            this.btnLimpiarActu.Text = "Limpiar Formulario";
            this.btnLimpiarActu.UseVisualStyleBackColor = false;
            this.btnLimpiarActu.Click += new System.EventHandler(this.btnLimpiarActu_Click);
            // 
            // txtPropiedadActu
            // 
            this.txtPropiedadActu.AccessibleName = "txtPropiedadActu";
            this.txtPropiedadActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPropiedadActu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtPropiedadActu.Location = new System.Drawing.Point(53, 108);
            this.txtPropiedadActu.Margin = new System.Windows.Forms.Padding(4);
            this.txtPropiedadActu.Name = "txtPropiedadActu";
            this.txtPropiedadActu.ReadOnly = true;
            this.txtPropiedadActu.Size = new System.Drawing.Size(389, 26);
            this.txtPropiedadActu.TabIndex = 27;
            // 
            // txtTecnicoActu
            // 
            this.txtTecnicoActu.AccessibleName = "txtTecnicoActu";
            this.txtTecnicoActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTecnicoActu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtTecnicoActu.Location = new System.Drawing.Point(53, 186);
            this.txtTecnicoActu.Margin = new System.Windows.Forms.Padding(4);
            this.txtTecnicoActu.Name = "txtTecnicoActu";
            this.txtTecnicoActu.ReadOnly = true;
            this.txtTecnicoActu.Size = new System.Drawing.Size(389, 26);
            this.txtTecnicoActu.TabIndex = 28;
            // 
            // MantenimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 798);
            this.Controls.Add(this.pnlActualizar);
            this.Controls.Add(this.pnlAccion);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnSolicitud);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MantenimientoForm";
            this.Text = "MantenimientoForm";
            this.Load += new System.EventHandler(this.MantenimientoForm_Load);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlNueva.ResumeLayout(false);
            this.pnlNueva.PerformLayout();
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

        private System.Windows.Forms.Button btnSolicitud;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlAccion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlNueva;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cboPropiedad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTecnico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpProgramada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Panel pnlEditar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboSolicitud;
        private System.Windows.Forms.DateTimePicker dtpConclusion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescripcionActu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnlActualizar;
        private System.Windows.Forms.Button btnActualizarSoli;
        private System.Windows.Forms.Button btnLimpiarActu;
        private System.Windows.Forms.Label lblOTipo;
        private System.Windows.Forms.Label lblOTecnico;
        private System.Windows.Forms.Label lblOPropiedad;
        private System.Windows.Forms.Label lblOFecha;
        private System.Windows.Forms.TextBox txtTecnicoActu;
        private System.Windows.Forms.TextBox txtPropiedadActu;
    }
}