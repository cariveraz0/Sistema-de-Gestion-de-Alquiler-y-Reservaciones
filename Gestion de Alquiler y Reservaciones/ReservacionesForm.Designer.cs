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
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlCuerpo.SuspendLayout();
            this.pnlReservacion.SuspendLayout();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.pnlAccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevaReservacion
            // 
            this.btnNuevaReservacion.FlatAppearance.BorderSize = 0;
            this.btnNuevaReservacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaReservacion.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaReservacion.Location = new System.Drawing.Point(51, 15);
            this.btnNuevaReservacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevaReservacion.Name = "btnNuevaReservacion";
            this.btnNuevaReservacion.Size = new System.Drawing.Size(227, 42);
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
            this.btnHistorialReservaciones.Location = new System.Drawing.Point(285, 15);
            this.btnHistorialReservaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHistorialReservaciones.Name = "btnHistorialReservaciones";
            this.btnHistorialReservaciones.Size = new System.Drawing.Size(251, 42);
            this.btnHistorialReservaciones.TabIndex = 1;
            this.btnHistorialReservaciones.Text = "Historial de Reservaciones";
            this.btnHistorialReservaciones.UseVisualStyleBackColor = true;
            this.btnHistorialReservaciones.Click += new System.EventHandler(this.btnHistorialReservaciones_Click);
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.pnlReservacion);
            this.pnlCuerpo.Controls.Add(this.pnlHistorial);
            this.pnlCuerpo.Location = new System.Drawing.Point(51, 92);
            this.pnlCuerpo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1389, 598);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // pnlReservacion
            // 
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
            this.pnlReservacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlReservacion.Name = "pnlReservacion";
            this.pnlReservacion.Size = new System.Drawing.Size(1381, 591);
            this.pnlReservacion.TabIndex = 0;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(53, 496);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(769, 26);
            this.txtObservaciones.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label7.Location = new System.Drawing.Point(49, 471);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Observaciones:";
            // 
            // txtMonto
            // 
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(53, 416);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(266, 26);
            this.txtMonto.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label6.Location = new System.Drawing.Point(49, 391);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Monto a Pagar:";
            // 
            // dtpSalida
            // 
            this.dtpSalida.Location = new System.Drawing.Point(53, 340);
            this.dtpSalida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpSalida.Name = "dtpSalida";
            this.dtpSalida.Size = new System.Drawing.Size(265, 22);
            this.dtpSalida.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label5.Location = new System.Drawing.Point(49, 315);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha Salida:";
            // 
            // dtpEntrada
            // 
            this.dtpEntrada.Location = new System.Drawing.Point(53, 263);
            this.dtpEntrada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEntrada.Name = "dtpEntrada";
            this.dtpEntrada.Size = new System.Drawing.Size(265, 22);
            this.dtpEntrada.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(49, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha Entrada:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label3.Location = new System.Drawing.Point(49, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cliente:";
            // 
            // cboPropiedad
            // 
            this.cboPropiedad.FormattingEnabled = true;
            this.cboPropiedad.Location = new System.Drawing.Point(53, 107);
            this.cboPropiedad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPropiedad.Name = "cboPropiedad";
            this.cboPropiedad.Size = new System.Drawing.Size(389, 24);
            this.cboPropiedad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.label2.Location = new System.Drawing.Point(48, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "CREACIÓN DE NUEVA RESERVACIÓN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(49, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Propiedad:";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(53, 185);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(417, 26);
            this.txtCliente.TabIndex = 0;
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHistorial.Controls.Add(this.dgvHistorial);
            this.pnlHistorial.Controls.Add(this.pnlBuscar);
            this.pnlHistorial.Location = new System.Drawing.Point(0, 0);
            this.pnlHistorial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(1381, 591);
            this.pnlHistorial.TabIndex = 13;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(4, 79);
            this.dgvHistorial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1377, 512);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistorial_CellFormatting);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.White;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.label8);
            this.pnlBuscar.Location = new System.Drawing.Point(4, 4);
            this.pnlBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(1377, 74);
            this.pnlBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(544, 20);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 33);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(97, 23);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(426, 27);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
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
            this.label8.TabIndex = 0;
            this.label8.Text = "Buscar:";
            // 
            // pnlAccion
            // 
            this.pnlAccion.BackColor = System.Drawing.Color.White;
            this.pnlAccion.Controls.Add(this.btnGuardar);
            this.pnlAccion.Controls.Add(this.btnLimpiar);
            this.pnlAccion.Location = new System.Drawing.Point(51, 703);
            this.pnlAccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlAccion.Name = "pnlAccion";
            this.pnlAccion.Padding = new System.Windows.Forms.Padding(13, 10, 13, 10);
            this.pnlAccion.Size = new System.Drawing.Size(1389, 57);
            this.pnlAccion.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(332, 10);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(267, 37);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Reservación";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLimpiar.Location = new System.Drawing.Point(57, 10);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(267, 37);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar Formulario";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ReservacionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 798);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlAccion);
            this.Controls.Add(this.btnHistorialReservaciones);
            this.Controls.Add(this.btnNuevaReservacion);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.pnlAccion.ResumeLayout(false);
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
    }
}