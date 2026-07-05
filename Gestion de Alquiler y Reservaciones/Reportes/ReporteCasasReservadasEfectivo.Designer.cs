namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    partial class ReporteCasasReservadasEfectivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCasas = new System.Windows.Forms.DataGridView();
            this.ReservacionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumPersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCasas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.dgvCasas);
            this.pnlPrincipal.Controls.Add(this.cmbAño);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.cmbClientes);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(186, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Size = new System.Drawing.Size(648, 30);
            this.label1.Text = "CASAS VACACIONALES RESERVADAS CON PAGO EN EFECTIVO";
            // 
            // cmbClientes
            // 
            this.cmbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.ItemHeight = 17;
            this.cmbClientes.Location = new System.Drawing.Point(234, 88);
            this.cmbClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(229, 25);
            this.cmbClientes.TabIndex = 4;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(173, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Cliente:";
            // 
            // cmbAño
            // 
            this.cmbAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026"});
            this.cmbAño.Location = new System.Drawing.Point(586, 88);
            this.cmbAño.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(156, 25);
            this.cmbAño.TabIndex = 6;
            this.cmbAño.SelectedIndexChanged += new System.EventHandler(this.cmbAño_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(546, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Año:";
            // 
            // dgvCasas
            // 
            this.dgvCasas.AllowUserToAddRows = false;
            this.dgvCasas.AllowUserToDeleteRows = false;
            this.dgvCasas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCasas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCasas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCasas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReservacionID,
            this.Reservacion,
            this.FechaCreacion,
            this.FechaEntrada,
            this.FechaSalida,
            this.NumPersonas,
            this.CostoTotal});
            this.dgvCasas.Location = new System.Drawing.Point(45, 149);
            this.dgvCasas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCasas.Name = "dgvCasas";
            this.dgvCasas.ReadOnly = true;
            this.dgvCasas.RowHeadersVisible = false;
            this.dgvCasas.RowHeadersWidth = 51;
            this.dgvCasas.RowTemplate.Height = 24;
            this.dgvCasas.Size = new System.Drawing.Size(880, 284);
            this.dgvCasas.TabIndex = 7;
            // 
            // ReservacionID
            // 
            this.ReservacionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ReservacionID.HeaderText = "ReservacionID";
            this.ReservacionID.MinimumWidth = 6;
            this.ReservacionID.Name = "ReservacionID";
            this.ReservacionID.ReadOnly = true;
            this.ReservacionID.Width = 118;
            // 
            // Reservacion
            // 
            this.Reservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reservacion.HeaderText = "Reservación";
            this.Reservacion.MinimumWidth = 6;
            this.Reservacion.Name = "Reservacion";
            this.Reservacion.ReadOnly = true;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaCreacion.HeaderText = "Fecha Creación";
            this.FechaCreacion.MinimumWidth = 6;
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            this.FechaCreacion.Width = 114;
            // 
            // FechaEntrada
            // 
            this.FechaEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaEntrada.HeaderText = "Fecha de Entrada";
            this.FechaEntrada.MinimumWidth = 6;
            this.FechaEntrada.Name = "FechaEntrada";
            this.FechaEntrada.ReadOnly = true;
            this.FechaEntrada.Width = 125;
            // 
            // FechaSalida
            // 
            this.FechaSalida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaSalida.HeaderText = "Fecha de Salida";
            this.FechaSalida.MinimumWidth = 6;
            this.FechaSalida.Name = "FechaSalida";
            this.FechaSalida.ReadOnly = true;
            this.FechaSalida.Width = 115;
            // 
            // NumPersonas
            // 
            this.NumPersonas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumPersonas.HeaderText = "Numero de Personas";
            this.NumPersonas.MinimumWidth = 6;
            this.NumPersonas.Name = "NumPersonas";
            this.NumPersonas.ReadOnly = true;
            this.NumPersonas.Width = 142;
            // 
            // CostoTotal
            // 
            this.CostoTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CostoTotal.HeaderText = "Costo Total";
            this.CostoTotal.MinimumWidth = 6;
            this.CostoTotal.Name = "CostoTotal";
            this.CostoTotal.ReadOnly = true;
            this.CostoTotal.Width = 89;
            // 
            // ReporteCasasReservadasEfectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReporteCasasReservadasEfectivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Casas Vacacionales Reservadas con Pago en Efectivo";
            this.Load += new System.EventHandler(this.ReporteCasasReservadasEfectivo_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCasas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCasas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservacionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoTotal;
    }
}