namespace Gestion_de_Alquiler_y_Reservaciones
{
    partial class ucPropiedadCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTipoArea = new System.Windows.Forms.Label();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblArrendatario = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoEllipsis = true;
            this.lblNombre.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(122)))), ((int)(((byte)(49)))));
            this.lblNombre.Location = new System.Drawing.Point(12, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(140, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre Propiedad";
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Gray;
            this.lblEstado.Font = new System.Drawing.Font("Montserrat", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(156, 10);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(80, 20);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTipoArea
            // 
            this.lblTipoArea.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTipoArea.Location = new System.Drawing.Point(12, 32);
            this.lblTipoArea.Name = "lblTipoArea";
            this.lblTipoArea.Size = new System.Drawing.Size(220, 16);
            this.lblTipoArea.TabIndex = 2;
            this.lblTipoArea.Text = "Tipo · Área";
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.pnlDivider.Location = new System.Drawing.Point(12, 58);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(221, 1);
            this.pnlDivider.TabIndex = 3;
            // 
            // lblArrendatario
            // 
            this.lblArrendatario.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrendatario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblArrendatario.Location = new System.Drawing.Point(10, 68);
            this.lblArrendatario.Name = "lblArrendatario";
            this.lblArrendatario.Size = new System.Drawing.Size(221, 16);
            this.lblArrendatario.TabIndex = 4;
            this.lblArrendatario.Text = "Sin arrendatario";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(79)))), ((int)(((byte)(36)))));
            this.lblPrecio.Location = new System.Drawing.Point(12, 91);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(221, 24);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "L. 0.00";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucPropiedadCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblArrendatario);
            this.Controls.Add(this.pnlDivider);
            this.Controls.Add(this.lblTipoArea);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblNombre);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ucPropiedadCard";
            this.Size = new System.Drawing.Size(245, 120);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucPropiedadCard_Paint);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTipoArea;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblArrendatario;
        private System.Windows.Forms.Label lblPrecio;
    }
}
