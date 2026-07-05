namespace Gestion_de_Alquiler_y_Reservaciones.Reportes
{
    partial class EstadisticasOcupacionPropiedad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstadisticasOcupacionPropiedad));
            this.dgvInformacion = new System.Windows.Forms.DataGridView();
            this.PropiedadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPropiedad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTiposPropiedad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.chartOcupacionPropiedades = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOcupacionPropiedades)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.chartOcupacionPropiedades);
            this.pnlPrincipal.Controls.Add(this.btnConsultar);
            this.pnlPrincipal.Controls.Add(this.label7);
            this.pnlPrincipal.Controls.Add(this.dtpHasta);
            this.pnlPrincipal.Controls.Add(this.label6);
            this.pnlPrincipal.Controls.Add(this.dtpDesde);
            this.pnlPrincipal.Controls.Add(this.label5);
            this.pnlPrincipal.Controls.Add(this.cmbTiposPropiedad);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.dgvInformacion);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(5);
            this.pnlPrincipal.Size = new System.Drawing.Size(1312, 675);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(343, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Size = new System.Drawing.Size(618, 31);
            this.label1.Text = "ESTADÍSTICAS DE OCUPACIÓN POR PROPIEDAD";
            // 
            // dgvInformacion
            // 
            this.dgvInformacion.AllowUserToAddRows = false;
            this.dgvInformacion.AllowUserToDeleteRows = false;
            this.dgvInformacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropiedadID,
            this.TipoPropiedad,
            this.Cantidad});
            this.dgvInformacion.Location = new System.Drawing.Point(90, 446);
            this.dgvInformacion.Name = "dgvInformacion";
            this.dgvInformacion.ReadOnly = true;
            this.dgvInformacion.RowHeadersVisible = false;
            this.dgvInformacion.RowHeadersWidth = 51;
            this.dgvInformacion.RowTemplate.Height = 24;
            this.dgvInformacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInformacion.Size = new System.Drawing.Size(1109, 125);
            this.dgvInformacion.TabIndex = 0;
            // 
            // PropiedadID
            // 
            this.PropiedadID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PropiedadID.HeaderText = "ID de la propiedad";
            this.PropiedadID.MinimumWidth = 6;
            this.PropiedadID.Name = "PropiedadID";
            this.PropiedadID.ReadOnly = true;
            this.PropiedadID.Width = 136;
            // 
            // TipoPropiedad
            // 
            this.TipoPropiedad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TipoPropiedad.HeaderText = "Tipo de propiedad";
            this.TipoPropiedad.MinimumWidth = 6;
            this.TipoPropiedad.Name = "TipoPropiedad";
            this.TipoPropiedad.ReadOnly = true;
            this.TipoPropiedad.Width = 137;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.HeaderText = "Cantidad de reservaciones";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(378, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Seleccione el tipo de propiedad";
            // 
            // cmbTiposPropiedad
            // 
            this.cmbTiposPropiedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTiposPropiedad.FormattingEnabled = true;
            this.cmbTiposPropiedad.Items.AddRange(new object[] {
            "Plaza Universitaria",
            "Casa Vacacional",
            "Apartamento"});
            this.cmbTiposPropiedad.Location = new System.Drawing.Point(686, 22);
            this.cmbTiposPropiedad.Name = "cmbTiposPropiedad";
            this.cmbTiposPropiedad.Size = new System.Drawing.Size(206, 30);
            this.cmbTiposPropiedad.TabIndex = 2;
            this.cmbTiposPropiedad.SelectedIndexChanged += new System.EventHandler(this.cmbTiposPropiedad_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(490, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Seleccione el rango de fecha deseado";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(346, 135);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 22);
            this.dtpDesde.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(271, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Desde";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(599, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(668, 134);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 22);
            this.dtpHasta.TabIndex = 6;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(922, 127);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(112, 39);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.cmdConsultar_Click);
            // 
            // chartOcupacionPropiedades
            // 
            chartArea1.Name = "ChartArea1";
            this.chartOcupacionPropiedades.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOcupacionPropiedades.Legends.Add(legend1);
            this.chartOcupacionPropiedades.Location = new System.Drawing.Point(276, 176);
            this.chartOcupacionPropiedades.Name = "chartOcupacionPropiedades";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartOcupacionPropiedades.Series.Add(series1);
            this.chartOcupacionPropiedades.Size = new System.Drawing.Size(758, 246);
            this.chartOcupacionPropiedades.TabIndex = 9;
            this.chartOcupacionPropiedades.Text = "chart1";
            // 
            // EstadisticasOcupacionPropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 814);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "EstadisticasOcupacionPropiedad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas de Ocupacion por Propiedad";
            this.Load += new System.EventHandler(this.EstadisticasOcupacionPropiedad_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOcupacionPropiedades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInformacion;
        private System.Windows.Forms.ComboBox cmbTiposPropiedad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOcupacionPropiedades;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropiedadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPropiedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}