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
            this.pnlEditar = new System.Windows.Forms.Panel();
            this.lblVEstado = new System.Windows.Forms.Label();
            this.lblVFechaConclusion = new System.Windows.Forms.Label();
            this.lblVSolicitud = new System.Windows.Forms.Label();
            this.lblVCosto = new System.Windows.Forms.Label();
            this.txtTecnicoActu = new System.Windows.Forms.TextBox();
            this.txtPropiedadActu = new System.Windows.Forms.TextBox();
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
            this.pnlNueva = new System.Windows.Forms.Panel();
            this.lblVFecha = new System.Windows.Forms.Label();
            this.lblVTipo = new System.Windows.Forms.Label();
            this.lblVTecnico = new System.Windows.Forms.Label();
            this.lblVPropiedad = new System.Windows.Forms.Label();
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
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlActualizar = new System.Windows.Forms.Panel();
            this.btnActualizarSoli = new System.Windows.Forms.Button();
            this.btnLimpiarActu = new System.Windows.Forms.Button();
            this.pnlCuerpo.SuspendLayout();
            this.pnlEditar.SuspendLayout();
            this.pnlNueva.SuspendLayout();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlBuscar.SuspendLayout();
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
            this.btnSolicitud.Location = new System.Drawing.Point(38, 12);
            this.btnSolicitud.Name = "btnSolicitud";
            this.btnSolicitud.Size = new System.Drawing.Size(170, 45);
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
            this.btnHistorial.Location = new System.Drawing.Point(397, 12);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(170, 45);
            this.btnHistorial.TabIndex = 1;
            this.btnHistorial.Text = "Historial de Mantenimiento";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.pnlNueva);
            this.pnlCuerpo.Controls.Add(this.pnlEditar);
            this.pnlCuerpo.Controls.Add(this.pnlHistorial);
            this.pnlCuerpo.Location = new System.Drawing.Point(38, 75);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1042, 486);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // pnlEditar
            // 
            this.pnlEditar.Controls.Add(this.lblVEstado);
            this.pnlEditar.Controls.Add(this.lblVFechaConclusion);
            this.pnlEditar.Controls.Add(this.lblVSolicitud);
            this.pnlEditar.Controls.Add(this.lblVCosto);
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
            this.pnlEditar.Name = "pnlEditar";
            this.pnlEditar.Size = new System.Drawing.Size(1039, 483);
            this.pnlEditar.TabIndex = 11;
            // 
            // lblVEstado
            // 
            this.lblVEstado.AutoSize = true;
            this.lblVEstado.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVEstado.Location = new System.Drawing.Point(246, 435);
            this.lblVEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVEstado.Name = "lblVEstado";
            this.lblVEstado.Size = new System.Drawing.Size(39, 17);
            this.lblVEstado.TabIndex = 32;
            this.lblVEstado.Text = "texto";
            this.lblVEstado.Visible = false;
            // 
            // lblVFechaConclusion
            // 
            this.lblVFechaConclusion.AutoSize = true;
            this.lblVFechaConclusion.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVFechaConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVFechaConclusion.Location = new System.Drawing.Point(246, 382);
            this.lblVFechaConclusion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVFechaConclusion.Name = "lblVFechaConclusion";
            this.lblVFechaConclusion.Size = new System.Drawing.Size(39, 17);
            this.lblVFechaConclusion.TabIndex = 31;
            this.lblVFechaConclusion.Text = "texto";
            this.lblVFechaConclusion.Visible = false;
            // 
            // lblVSolicitud
            // 
            this.lblVSolicitud.AutoSize = true;
            this.lblVSolicitud.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVSolicitud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVSolicitud.Location = new System.Drawing.Point(776, 24);
            this.lblVSolicitud.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVSolicitud.Name = "lblVSolicitud";
            this.lblVSolicitud.Size = new System.Drawing.Size(73, 17);
            this.lblVSolicitud.TabIndex = 30;
            this.lblVSolicitud.Text = "Obligatorio";
            // 
            // lblVCosto
            // 
            this.lblVCosto.AutoSize = true;
            this.lblVCosto.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVCosto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVCosto.Location = new System.Drawing.Point(221, 216);
            this.lblVCosto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVCosto.Name = "lblVCosto";
            this.lblVCosto.Size = new System.Drawing.Size(39, 17);
            this.lblVCosto.TabIndex = 29;
            this.lblVCosto.Text = "texto";
            this.lblVCosto.Visible = false;
            // 
            // txtTecnicoActu
            // 
            this.txtTecnicoActu.AccessibleName = "txtTecnicoActu";
            this.txtTecnicoActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTecnicoActu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtTecnicoActu.Location = new System.Drawing.Point(40, 151);
            this.txtTecnicoActu.Name = "txtTecnicoActu";
            this.txtTecnicoActu.ReadOnly = true;
            this.txtTecnicoActu.Size = new System.Drawing.Size(292, 22);
            this.txtTecnicoActu.TabIndex = 28;
            // 
            // txtPropiedadActu
            // 
            this.txtPropiedadActu.AccessibleName = "txtPropiedadActu";
            this.txtPropiedadActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPropiedadActu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtPropiedadActu.Location = new System.Drawing.Point(40, 88);
            this.txtPropiedadActu.Name = "txtPropiedadActu";
            this.txtPropiedadActu.ReadOnly = true;
            this.txtPropiedadActu.Size = new System.Drawing.Size(292, 22);
            this.txtPropiedadActu.TabIndex = 27;
            // 
            // cmbEstado
            // 
            this.cmbEstado.AccessibleName = "cmbEstado";
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(40, 434);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(200, 21);
            this.cmbEstado.TabIndex = 26;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label15.Location = new System.Drawing.Point(37, 414);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 17);
            this.label15.TabIndex = 25;
            this.label15.Text = "Estado:";
            // 
            // txtCosto
            // 
            this.txtCosto.AccessibleName = "txtCosto";
            this.txtCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCosto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtCosto.Location = new System.Drawing.Point(40, 213);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(177, 22);
            this.txtCosto.TabIndex = 24;
            this.txtCosto.TextChanged += new System.EventHandler(this.txtCosto_TextChanged);
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label14.Location = new System.Drawing.Point(513, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 17);
            this.label14.TabIndex = 23;
            this.label14.Text = "Solicitud:";
            // 
            // cboSolicitud
            // 
            this.cboSolicitud.AccessibleName = "cboSolicitud";
            this.cboSolicitud.FormattingEnabled = true;
            this.cboSolicitud.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboSolicitud.Location = new System.Drawing.Point(581, 24);
            this.cboSolicitud.Name = "cboSolicitud";
            this.cboSolicitud.Size = new System.Drawing.Size(191, 21);
            this.cboSolicitud.TabIndex = 22;
            this.cboSolicitud.SelectedIndexChanged += new System.EventHandler(this.cboSolicitud_SelectedIndexChanged);
            // 
            // dtpConclusion
            // 
            this.dtpConclusion.AccessibleName = "dtpConclusion";
            this.dtpConclusion.Location = new System.Drawing.Point(40, 381);
            this.dtpConclusion.Name = "dtpConclusion";
            this.dtpConclusion.Size = new System.Drawing.Size(200, 20);
            this.dtpConclusion.TabIndex = 21;
            this.dtpConclusion.ValueChanged += new System.EventHandler(this.dtpConclusion_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label8.Location = new System.Drawing.Point(37, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Fecha Conclusión:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label9.Location = new System.Drawing.Point(37, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Descripción:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label10.Location = new System.Drawing.Point(37, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Costo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label11.Location = new System.Drawing.Point(37, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Técnico Asignado:";
            // 
            // txtDescripcionActu
            // 
            this.txtDescripcionActu.AccessibleName = "txtDescripcionActu";
            this.txtDescripcionActu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcionActu.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtDescripcionActu.Location = new System.Drawing.Point(40, 277);
            this.txtDescripcionActu.Multiline = true;
            this.txtDescripcionActu.Name = "txtDescripcionActu";
            this.txtDescripcionActu.Size = new System.Drawing.Size(577, 69);
            this.txtDescripcionActu.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label12.Location = new System.Drawing.Point(37, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Propiedad:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label13.Location = new System.Drawing.Point(36, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(422, 24);
            this.label13.TabIndex = 11;
            this.label13.Text = "ACTUALIZACIÓN DE SOLICITUD DE MANTENIMIENTO";
            // 
            // pnlNueva
            // 
            this.pnlNueva.Controls.Add(this.lblVFecha);
            this.pnlNueva.Controls.Add(this.lblVTipo);
            this.pnlNueva.Controls.Add(this.lblVTecnico);
            this.pnlNueva.Controls.Add(this.lblVPropiedad);
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
            this.pnlNueva.Name = "pnlNueva";
            this.pnlNueva.Size = new System.Drawing.Size(1036, 480);
            this.pnlNueva.TabIndex = 0;
            // 
            // lblVFecha
            // 
            this.lblVFecha.AutoSize = true;
            this.lblVFecha.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVFecha.Location = new System.Drawing.Point(246, 390);
            this.lblVFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVFecha.Name = "lblVFecha";
            this.lblVFecha.Size = new System.Drawing.Size(73, 17);
            this.lblVFecha.TabIndex = 17;
            this.lblVFecha.Text = "Obligatorio";
            // 
            // lblVTipo
            // 
            this.lblVTipo.AutoSize = true;
            this.lblVTipo.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVTipo.Location = new System.Drawing.Point(339, 217);
            this.lblVTipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVTipo.Name = "lblVTipo";
            this.lblVTipo.Size = new System.Drawing.Size(73, 17);
            this.lblVTipo.TabIndex = 16;
            this.lblVTipo.Text = "Obligatorio";
            // 
            // lblVTecnico
            // 
            this.lblVTecnico.AutoSize = true;
            this.lblVTecnico.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVTecnico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVTecnico.Location = new System.Drawing.Point(339, 152);
            this.lblVTecnico.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVTecnico.Name = "lblVTecnico";
            this.lblVTecnico.Size = new System.Drawing.Size(73, 17);
            this.lblVTecnico.TabIndex = 15;
            this.lblVTecnico.Text = "Obligatorio";
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
            // dtpProgramada
            // 
            this.dtpProgramada.AccessibleName = "dtpProgramada";
            this.dtpProgramada.Location = new System.Drawing.Point(40, 389);
            this.dtpProgramada.Name = "dtpProgramada";
            this.dtpProgramada.Size = new System.Drawing.Size(200, 20);
            this.dtpProgramada.TabIndex = 10;
            this.dtpProgramada.ValueChanged += new System.EventHandler(this.dtpProgramada_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(37, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha Programada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(37, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Descripción:";
            // 
            // cboTipo
            // 
            this.cboTipo.AccessibleName = "cboTipo";
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboTipo.Location = new System.Drawing.Point(40, 215);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(293, 21);
            this.cboTipo.TabIndex = 7;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(37, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de Mantenimiento:";
            // 
            // cboTecnico
            // 
            this.cboTecnico.AccessibleName = "cboTecnico";
            this.cboTecnico.FormattingEnabled = true;
            this.cboTecnico.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboTecnico.Location = new System.Drawing.Point(40, 150);
            this.cboTecnico.Name = "cboTecnico";
            this.cboTecnico.Size = new System.Drawing.Size(293, 21);
            this.cboTecnico.TabIndex = 5;
            this.cboTecnico.SelectedIndexChanged += new System.EventHandler(this.cboTecnico_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(37, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Técnico Asignado:";
            // 
            // cboPropiedad
            // 
            this.cboPropiedad.AccessibleName = "cboPropiedad";
            this.cboPropiedad.FormattingEnabled = true;
            this.cboPropiedad.Items.AddRange(new object[] {
            "--Seleccionar--"});
            this.cboPropiedad.Location = new System.Drawing.Point(40, 87);
            this.cboPropiedad.Name = "cboPropiedad";
            this.cboPropiedad.Size = new System.Drawing.Size(293, 21);
            this.cboPropiedad.TabIndex = 3;
            this.cboPropiedad.SelectedIndexChanged += new System.EventHandler(this.cboPropiedad_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AccessibleName = "txtDescripcion";
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(40, 278);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(577, 69);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(37, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Propiedad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "CREACIÓN DE NUEVA SOLICITUD DE MANTENIMIENTO";
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHistorial.Controls.Add(this.dgvHistorial);
            this.pnlHistorial.Controls.Add(this.pnlBuscar);
            this.pnlHistorial.Location = new System.Drawing.Point(0, 0);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1030, 474);
            this.pnlHistorial.TabIndex = 11;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AccessibleName = "dgvHistorial";
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(3, 64);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1027, 410);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistorial_CellFormatting);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.White;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.label7);
            this.pnlBuscar.Location = new System.Drawing.Point(3, 3);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(1033, 60);
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
            this.txtBuscar.AccessibleName = "txtBuscar";
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(73, 19);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(320, 23);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(15, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Buscar:";
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
            this.btnGuardar.AccessibleName = "btnGuardar";
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(249, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 30);
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
            this.btnLimpiar.Location = new System.Drawing.Point(43, 8);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 30);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar Formulario";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.AccessibleName = "btnActualizar";
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(214, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(177, 45);
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
            this.pnlActualizar.Location = new System.Drawing.Point(38, 571);
            this.pnlActualizar.Name = "pnlActualizar";
            this.pnlActualizar.Size = new System.Drawing.Size(1042, 46);
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
            this.btnActualizarSoli.Location = new System.Drawing.Point(249, 8);
            this.btnActualizarSoli.Name = "btnActualizarSoli";
            this.btnActualizarSoli.Size = new System.Drawing.Size(200, 30);
            this.btnActualizarSoli.TabIndex = 3;
            this.btnActualizarSoli.Text = "Actualizar Solicitud";
            this.btnActualizarSoli.UseVisualStyleBackColor = false;
            this.btnActualizarSoli.Click += new System.EventHandler(this.btnActualizarSoli_Click);
            // 
            // btnLimpiarActu
            // 
            this.btnLimpiarActu.AccessibleName = "btnLimpiarActu";
            this.btnLimpiarActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLimpiarActu.FlatAppearance.BorderSize = 0;
            this.btnLimpiarActu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarActu.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarActu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLimpiarActu.Location = new System.Drawing.Point(43, 8);
            this.btnLimpiarActu.Name = "btnLimpiarActu";
            this.btnLimpiarActu.Size = new System.Drawing.Size(200, 30);
            this.btnLimpiarActu.TabIndex = 2;
            this.btnLimpiarActu.Text = "Limpiar Formulario";
            this.btnLimpiarActu.UseVisualStyleBackColor = false;
            this.btnLimpiarActu.Click += new System.EventHandler(this.btnLimpiarActu_Click);
            // 
            // MantenimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 648);
            this.Controls.Add(this.pnlActualizar);
            this.Controls.Add(this.pnlAccion);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnSolicitud);
            this.Name = "MantenimientoForm";
            this.Text = "MantenimientoForm";
            this.Load += new System.EventHandler(this.MantenimientoForm_Load);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlEditar.ResumeLayout(false);
            this.pnlEditar.PerformLayout();
            this.pnlNueva.ResumeLayout(false);
            this.pnlNueva.PerformLayout();
            this.pnlHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
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
        private System.Windows.Forms.Label lblVTipo;
        private System.Windows.Forms.Label lblVTecnico;
        private System.Windows.Forms.Label lblVPropiedad;
        private System.Windows.Forms.Label lblVFecha;
        private System.Windows.Forms.TextBox txtTecnicoActu;
        private System.Windows.Forms.TextBox txtPropiedadActu;
        private System.Windows.Forms.Label lblVCosto;
        private System.Windows.Forms.Label lblVSolicitud;
        private System.Windows.Forms.Label lblVEstado;
        private System.Windows.Forms.Label lblVFechaConclusion;
    }
}