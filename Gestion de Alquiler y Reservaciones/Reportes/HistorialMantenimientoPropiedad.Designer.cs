namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    partial class HistorialMantenimientoPropiedad
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
            this.label3 = new System.Windows.Forms.Label();
            this.cboPropiedades = new System.Windows.Forms.ComboBox();
            this.dgvMantenimiento = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantenimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.btnImprimir);
            this.pnlPrincipal.Controls.Add(this.dgvMantenimiento);
            this.pnlPrincipal.Controls.Add(this.cboPropiedades);
            this.pnlPrincipal.Controls.Add(this.label3);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(327, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Size = new System.Drawing.Size(675, 39);
            this.label1.Text = "HISTORIAL DE MANTENIMIENTO POR PROPIEDAD";
            // 
            // lblPagina
            // 
            this.lblPagina.Location = new System.Drawing.Point(1120, 28);
            this.lblPagina.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(299, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seleccione una Propiedad:";
            // 
            // cboPropiedades
            // 
            this.cboPropiedades.FormattingEnabled = true;
            this.cboPropiedades.Location = new System.Drawing.Point(592, 41);
            this.cboPropiedades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPropiedades.Name = "cboPropiedades";
            this.cboPropiedades.Size = new System.Drawing.Size(296, 24);
            this.cboPropiedades.TabIndex = 1;
            this.cboPropiedades.SelectedIndexChanged += new System.EventHandler(this.cboPropiedades_SelectedIndexChanged);
            // 
            // dgvMantenimiento
            // 
            this.dgvMantenimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMantenimiento.Location = new System.Drawing.Point(27, 92);
            this.dgvMantenimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMantenimiento.Name = "dgvMantenimiento";
            this.dgvMantenimiento.RowHeadersWidth = 51;
            this.dgvMantenimiento.Size = new System.Drawing.Size(1257, 345);
            this.dgvMantenimiento.TabIndex = 2;
            this.dgvMantenimiento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMantenimiento_CellFormatting);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(592, 546);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(213, 43);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // HistorialMantenimientoPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 814);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "HistorialMantenimientoPropiedad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Mantenimiento por Propiedad";
            this.Load += new System.EventHandler(this.HistorialMantenimientoPropiedad_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMantenimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPropiedades;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMantenimiento;
        private System.Windows.Forms.Button btnImprimir;
    }
}