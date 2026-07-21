namespace Gestion_de_Alquiler_y_Reservaciones
{
    partial class ClientesForm
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
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnClienteHistorial = new System.Windows.Forms.Button();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.txtRtn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblONombre = new System.Windows.Forms.Label();
            this.lblOIdentidad = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtIdentidad = new System.Windows.Forms.TextBox();
            this.lblVCorreo = new System.Windows.Forms.Label();
            this.pnlCuerpo.SuspendLayout();
            this.pnlCliente.SuspendLayout();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.pnlAccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.AccessibleName = "btnNuevoCliente";
            this.btnNuevoCliente.FlatAppearance.BorderSize = 0;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCliente.Location = new System.Drawing.Point(51, 15);
            this.btnNuevoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(227, 42);
            this.btnNuevoCliente.TabIndex = 0;
            this.btnNuevoCliente.Text = "Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnClienteHistorial
            // 
            this.btnClienteHistorial.AccessibleName = "btnClienteHistorial";
            this.btnClienteHistorial.FlatAppearance.BorderSize = 0;
            this.btnClienteHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClienteHistorial.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClienteHistorial.Location = new System.Drawing.Point(285, 15);
            this.btnClienteHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.btnClienteHistorial.Name = "btnClienteHistorial";
            this.btnClienteHistorial.Size = new System.Drawing.Size(227, 42);
            this.btnClienteHistorial.TabIndex = 1;
            this.btnClienteHistorial.Text = "Historial de Clientes";
            this.btnClienteHistorial.UseVisualStyleBackColor = true;
            this.btnClienteHistorial.Click += new System.EventHandler(this.btnClienteHistorial_Click);
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.Controls.Add(this.pnlCliente);
            this.pnlCuerpo.Controls.Add(this.pnlHistorial);
            this.pnlCuerpo.Location = new System.Drawing.Point(51, 92);
            this.pnlCuerpo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1389, 667);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // pnlCliente
            // 
            this.pnlCliente.BackColor = System.Drawing.Color.White;
            this.pnlCliente.Controls.Add(this.lblVCorreo);
            this.pnlCliente.Controls.Add(this.txtIdentidad);
            this.pnlCliente.Controls.Add(this.txtTelefono);
            this.pnlCliente.Controls.Add(this.lblOIdentidad);
            this.pnlCliente.Controls.Add(this.lblONombre);
            this.pnlCliente.Controls.Add(this.txtRtn);
            this.pnlCliente.Controls.Add(this.label7);
            this.pnlCliente.Controls.Add(this.txtEmpresa);
            this.pnlCliente.Controls.Add(this.label6);
            this.pnlCliente.Controls.Add(this.txtCorreo);
            this.pnlCliente.Controls.Add(this.label5);
            this.pnlCliente.Controls.Add(this.label4);
            this.pnlCliente.Controls.Add(this.label3);
            this.pnlCliente.Controls.Add(this.txtNombre);
            this.pnlCliente.Controls.Add(this.label2);
            this.pnlCliente.Controls.Add(this.label1);
            this.pnlCliente.Location = new System.Drawing.Point(0, 0);
            this.pnlCliente.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(1381, 598);
            this.pnlCliente.TabIndex = 0;
            // 
            // txtRtn
            // 
            this.txtRtn.AccessibleName = "txtRtn";
            this.txtRtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRtn.Location = new System.Drawing.Point(52, 498);
            this.txtRtn.Margin = new System.Windows.Forms.Padding(4);
            this.txtRtn.Name = "txtRtn";
            this.txtRtn.Size = new System.Drawing.Size(287, 27);
            this.txtRtn.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(49, 475);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "RTN de la Empresa (*):";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.AccessibleName = "txtEmpresa";
            this.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.Location = new System.Drawing.Point(52, 418);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(347, 27);
            this.txtEmpresa.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(49, 395);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Nombre de la Empresa (*):";
            // 
            // txtCorreo
            // 
            this.txtCorreo.AccessibleName = "txtCorreo";
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(52, 338);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(347, 27);
            this.txtCorreo.TabIndex = 8;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(49, 315);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Correo Electrónico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(49, 235);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Número de Teléfono:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(49, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Número de Identidad:";
            // 
            // txtNombre
            // 
            this.txtNombre.AccessibleName = "txtNombre";
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(52, 98);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(417, 27);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(49, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Completo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(48, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "CREACIÓN DE NUEVO CLIENTE";
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHistorial.Controls.Add(this.dgvHistorial);
            this.pnlHistorial.Controls.Add(this.pnlBuscar);
            this.pnlHistorial.Location = new System.Drawing.Point(0, 0);
            this.pnlHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1381, 598);
            this.pnlHistorial.TabIndex = 13;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AccessibleName = "dgvHistorial";
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(4, 75);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1373, 519);
            this.dgvHistorial.TabIndex = 1;
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.White;
            this.pnlBuscar.Controls.Add(this.label8);
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Location = new System.Drawing.Point(4, 4);
            this.pnlBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(1377, 74);
            this.pnlBuscar.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label8.Location = new System.Drawing.Point(20, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "Buscar:";
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
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.btnGuardar.AccessibleName = "btnGuardar";
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
            this.btnGuardar.Text = "Guardar Cliente";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AccessibleName = "btnLimpiar";
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
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblONombre
            // 
            this.lblONombre.AutoSize = true;
            this.lblONombre.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblONombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblONombre.Location = new System.Drawing.Point(476, 98);
            this.lblONombre.Name = "lblONombre";
            this.lblONombre.Size = new System.Drawing.Size(93, 22);
            this.lblONombre.TabIndex = 13;
            this.lblONombre.Text = "Obligatorio";
            // 
            // lblOIdentidad
            // 
            this.lblOIdentidad.AutoSize = true;
            this.lblOIdentidad.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblOIdentidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOIdentidad.Location = new System.Drawing.Point(346, 178);
            this.lblOIdentidad.Name = "lblOIdentidad";
            this.lblOIdentidad.Size = new System.Drawing.Size(93, 22);
            this.lblOIdentidad.TabIndex = 14;
            this.lblOIdentidad.Text = "Obligatorio";
            // 
            // txtTelefono
            // 
            this.txtTelefono.AccessibleName = "txtTelefono";
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(53, 261);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(286, 27);
            this.txtTelefono.TabIndex = 17;
            this.txtTelefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelefono_KeyDown);
            // 
            // txtIdentidad
            // 
            this.txtIdentidad.AccessibleName = "txtIdentidad";
            this.txtIdentidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentidad.Location = new System.Drawing.Point(53, 181);
            this.txtIdentidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentidad.Name = "txtIdentidad";
            this.txtIdentidad.Size = new System.Drawing.Size(286, 27);
            this.txtIdentidad.TabIndex = 18;
            this.txtIdentidad.TextChanged += new System.EventHandler(this.txtIdentidad_TextChanged);
            this.txtIdentidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentidad_KeyDown);
            // 
            // lblVCorreo
            // 
            this.lblVCorreo.AutoSize = true;
            this.lblVCorreo.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold);
            this.lblVCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVCorreo.Location = new System.Drawing.Point(419, 338);
            this.lblVCorreo.Name = "lblVCorreo";
            this.lblVCorreo.Size = new System.Drawing.Size(48, 22);
            this.lblVCorreo.TabIndex = 19;
            this.lblVCorreo.Text = "texto";
            this.lblVCorreo.Visible = false;
            // 
            // ClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 798);
            this.Controls.Add(this.pnlAccion);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.btnClienteHistorial);
            this.Controls.Add(this.btnNuevoCliente);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientesForm";
            this.Text = "ClientesForm";
            this.Load += new System.EventHandler(this.ClientesForm_Load);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            this.pnlHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.pnlAccion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnClienteHistorial;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlAccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblOIdentidad;
        private System.Windows.Forms.Label lblONombre;
        private System.Windows.Forms.TextBox txtIdentidad;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblVCorreo;
    }
}