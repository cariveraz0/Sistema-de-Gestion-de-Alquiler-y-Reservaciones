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
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Size = new System.Drawing.Size(984, 548);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(177, 44);
            this.label1.Size = new System.Drawing.Size(644, 32);
            this.label1.Text = "RESUMEN DE SOLICITUDES DE MANTENIMIENTO POR ESTADO";
            // 
            // ResumenMantenimientoEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Name = "ResumenMantenimientoEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Solicitudes de Mantenimiento por Estado";
            this.ResumeLayout(false);

        }

        #endregion
    }
}