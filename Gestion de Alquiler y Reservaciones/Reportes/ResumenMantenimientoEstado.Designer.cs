using System;
using System.Windows.Forms;

namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    partial class ResumenMantenimientoEstado
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTotalCentro = new System.Windows.Forms.Label();
            this.cBxEstados = new System.Windows.Forms.ComboBox();
            this.cBxPropiedades = new System.Windows.Forms.ComboBox();
            this.chartEstados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlResumenEjecutivo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPropiedades = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstados)).BeginInit();
            this.pnlResumenEjecutivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.lblTotalCentro);
            this.pnlPrincipal.Controls.Add(this.btnLimpiar);
            this.pnlPrincipal.Controls.Add(this.label7);
            this.pnlPrincipal.Controls.Add(this.label6);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Controls.Add(this.panel4);
            this.pnlPrincipal.Controls.Add(this.cBxPropiedades);
            this.pnlPrincipal.Controls.Add(this.cBxEstados);
            this.pnlPrincipal.Controls.Add(this.dgvPropiedades);
            this.pnlPrincipal.Controls.Add(this.pnlResumenEjecutivo);
            this.pnlPrincipal.Controls.Add(this.lblSubtitulo);
            this.pnlPrincipal.Controls.Add(this.btnGenerar);
            this.pnlPrincipal.Controls.Add(this.dtpFin);
            this.pnlPrincipal.Controls.Add(this.dtpInicio);
            this.pnlPrincipal.Size = new System.Drawing.Size(984, 548);
            this.pnlPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPrincipal_Paint);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(177, 44);
            this.label1.Size = new System.Drawing.Size(637, 26);
            this.label1.Text = "RESUMEN DE SOLICITUDES DE MANTENIMIENTO POR ESTADO";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(30, 188);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(140, 20);
            this.dtpInicio.TabIndex = 0;
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(30, 214);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(140, 20);
            this.dtpFin.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(179)))), ((int)(((byte)(64)))));
            this.btnGenerar.Location = new System.Drawing.Point(26, 125);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(144, 34);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(984, 24);
            this.lblSubtitulo.TabIndex = 3;
            this.lblSubtitulo.Text = "SUbtitulo";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitulo.Click += new System.EventHandler(this.lblSubtitulo_Click);
            // 
            // lblTotalCentro
            // 
            this.lblTotalCentro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCentro.AutoSize = true;
            this.lblTotalCentro.Location = new System.Drawing.Point(544, 42);
            this.lblTotalCentro.Name = "lblTotalCentro";
            this.lblTotalCentro.Size = new System.Drawing.Size(31, 13);
            this.lblTotalCentro.TabIndex = 5;
            this.lblTotalCentro.Text = "Total";
            this.lblTotalCentro.Visible = false;
            // 
            // cBxEstados
            // 
            this.cBxEstados.FormattingEnabled = true;
            this.cBxEstados.Location = new System.Drawing.Point(30, 27);
            this.cBxEstados.Name = "cBxEstados";
            this.cBxEstados.Size = new System.Drawing.Size(140, 21);
            this.cBxEstados.TabIndex = 8;
            // 
            // cBxPropiedades
            // 
            this.cBxPropiedades.FormattingEnabled = true;
            this.cBxPropiedades.Location = new System.Drawing.Point(30, 82);
            this.cBxPropiedades.Name = "cBxPropiedades";
            this.cBxPropiedades.Size = new System.Drawing.Size(140, 21);
            this.cBxPropiedades.TabIndex = 9;
            // 
            // chartEstados
            // 
            this.chartEstados.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chartEstados.BackColor = System.Drawing.Color.Transparent;
            this.chartEstados.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chartEstados.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartEstados.ChartAreas.Add(chartArea1);
            this.chartEstados.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartEstados.Legends.Add(legend1);
            this.chartEstados.Location = new System.Drawing.Point(0, 0);
            this.chartEstados.Name = "chartEstados";
            this.chartEstados.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Estados";
            this.chartEstados.Series.Add(series1);
            this.chartEstados.Size = new System.Drawing.Size(319, 207);
            this.chartEstados.TabIndex = 4;
            this.chartEstados.Text = "chart1";
            this.chartEstados.Click += new System.EventHandler(this.chartEstados_Click);
            // 
            // pnlResumenEjecutivo
            // 
            this.pnlResumenEjecutivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlResumenEjecutivo.Controls.Add(this.label3);
            this.pnlResumenEjecutivo.Location = new System.Drawing.Point(608, 27);
            this.pnlResumenEjecutivo.Name = "pnlResumenEjecutivo";
            this.pnlResumenEjecutivo.Size = new System.Drawing.Size(351, 207);
            this.pnlResumenEjecutivo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "RESUMEN EJECUTIVO";
            // 
            // dgvPropiedades
            // 
            this.dgvPropiedades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropiedades.Location = new System.Drawing.Point(0, 251);
            this.dgvPropiedades.Name = "dgvPropiedades";
            this.dgvPropiedades.Size = new System.Drawing.Size(984, 228);
            this.dgvPropiedades.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chartEstados);
            this.panel4.Location = new System.Drawing.Point(198, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(319, 207);
            this.panel4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Estado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Propiedad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fecha(Opcional):";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(179)))), ((int)(((byte)(64)))));
            this.btnLimpiar.Location = new System.Drawing.Point(538, 125);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(55, 34);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // ResumenMantenimientoEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Name = "ResumenMantenimientoEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Solicitudes de Mantenimiento por Estado";
            this.Load += new System.EventHandler(this.ResumenMantenimientoEstado_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstados)).EndInit();
            this.pnlResumenEjecutivo.ResumeLayout(false);
            this.pnlResumenEjecutivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblTotalCentro;
        private System.Windows.Forms.ComboBox cBxEstados;
        private System.Windows.Forms.ComboBox cBxPropiedades;
        private System.Windows.Forms.DataGridView dgvPropiedades;
        private System.Windows.Forms.Panel pnlResumenEjecutivo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEstados;
        private Panel panel4;
        private Label label3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btnLimpiar;
    }
}