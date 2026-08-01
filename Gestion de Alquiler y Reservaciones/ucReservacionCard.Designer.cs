namespace Gestion_de_Alquiler_y_Reservaciones
{
    partial class ucReservacionCard
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblSalida = new System.Windows.Forms.Label();
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
            this.lblEstado.Location = new System.Drawing.Point(153, 10);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(80, 20);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblCliente.Location = new System.Drawing.Point(10, 36);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(221, 18);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(224)))), ((int)(((byte)(216)))));
            this.pnlDivider.Location = new System.Drawing.Point(12, 60);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(221, 1);
            this.pnlDivider.TabIndex = 3;
            // 
            // lblEntrada
            // 
            this.lblEntrada.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblEntrada.Location = new System.Drawing.Point(12, 70);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(221, 16);
            this.lblEntrada.TabIndex = 4;
            this.lblEntrada.Text = "Entrada: -";
            // 
            // lblSalida
            // 
            this.lblSalida.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSalida.Location = new System.Drawing.Point(12, 90);
            this.lblSalida.Name = "lblSalida";
            this.lblSalida.Size = new System.Drawing.Size(221, 16);
            this.lblSalida.TabIndex = 5;
            this.lblSalida.Text = "Salida: -";
            // 
            // ucReservacionCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblSalida);
            this.Controls.Add(this.lblEntrada);
            this.Controls.Add(this.pnlDivider);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblNombre);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ucReservacionCard";
            this.Size = new System.Drawing.Size(245, 120);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucReservacionCard_Paint);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblSalida;
    }
}
