namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    partial class ReporteContratosVigentes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvContratos = new System.Windows.Forms.DataGridView();
            this.btnPaginaSiguiente = new System.Windows.Forms.Button();
            this.btnPaginaAnterior = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.btnImprimir);
            this.pnlPrincipal.Controls.Add(this.btnPaginaAnterior);
            this.pnlPrincipal.Controls.Add(this.btnPaginaSiguiente);
            this.pnlPrincipal.Controls.Add(this.dgvContratos);
            this.pnlPrincipal.Size = new System.Drawing.Size(984, 548);
            // 
            // lblPagina
            // 
            this.lblPagina.Location = new System.Drawing.Point(840, 24);
            // 
            // dgvContratos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContratos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContratos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContratos.Location = new System.Drawing.Point(60, 36);
            this.dgvContratos.Name = "dgvContratos";
            this.dgvContratos.Size = new System.Drawing.Size(859, 310);
            this.dgvContratos.TabIndex = 0;
            this.dgvContratos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvContratos_CellFormatting);
            // 
            // btnPaginaSiguiente
            // 
            this.btnPaginaSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnPaginaSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaSiguiente.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnPaginaSiguiente.Location = new System.Drawing.Point(569, 361);
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(160, 35);
            this.btnPaginaSiguiente.TabIndex = 1;
            this.btnPaginaSiguiente.Text = "Página Siguiente";
            this.btnPaginaSiguiente.UseVisualStyleBackColor = false;
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnPaginaAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaAnterior.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaAnterior.ForeColor = System.Drawing.Color.White;
            this.btnPaginaAnterior.Location = new System.Drawing.Point(301, 361);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(160, 35);
            this.btnPaginaAnterior.TabIndex = 2;
            this.btnPaginaAnterior.Text = "Página Anterior";
            this.btnPaginaAnterior.UseVisualStyleBackColor = false;
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Montserrat SemiBold", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(417, 444);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(160, 35);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // ReporteContratosVigentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Name = "ReporteContratosVigentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de Contratos Vigentes y su Estado";
            this.pnlPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContratos;
        private System.Windows.Forms.Button btnPaginaAnterior;
        private System.Windows.Forms.Button btnPaginaSiguiente;
        private System.Windows.Forms.Button btnImprimir;
    }
}