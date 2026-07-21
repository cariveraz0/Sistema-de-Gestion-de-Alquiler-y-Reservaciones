using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class ClientesForm : Form
    {
        private static readonly Color ColorActivo = ColorTranslator.FromHtml("#C84F24");

        private static readonly Color ColorInactivo = ColorTranslator.FromHtml("#E0DBD2");
        private static readonly Color TextoInactivo = ColorTranslator.FromHtml("#666666");
        private DataTable tablalocal;

        public ClientesForm()
        {
            InitializeComponent();
            ActivarTabNuevo();
            CargarDatosBD();
            ConfigurarDataGridView(dgvHistorial);
        }

        public void ConfigurarDataGridView(DataGridView grid)
        {
            System.Drawing.Color naranjaTitulo = System.Drawing.Color.FromArgb(216, 122, 45);

            grid.RowHeadersVisible = false;
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.RowTemplate.Height = 28;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = naranjaTitulo;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 9, FontStyle.Bold);

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
        }
        private void btnNuevoCliente_Click(object sender, EventArgs e) => ActivarTabNuevo();
        private void btnClienteHistorial_Click(object sender, EventArgs e) => ActivarTabHistorial();

        private void ActivarTabNuevo()
        {
            pnlCliente.Visible = true;
            pnlHistorial.Visible = false;
            pnlAccion.Visible = true;

            EstiloTabActivo(btnNuevoCliente);
            EstiloTabInactivo(btnClienteHistorial);
        }
        private void ActivarTabHistorial()
        {
            pnlHistorial.Visible = true;
            pnlCliente.Visible = false;
            pnlAccion.Visible = false;

            EstiloTabActivo(btnClienteHistorial);
            EstiloTabInactivo(btnNuevoCliente);
        }

        private void EstiloTabActivo(Button btn)
        {
            btn.BackColor = ColorActivo;
            btn.ForeColor = Color.White;
        }

        private void EstiloTabInactivo(Button btn)
        {
            btn.BackColor = ColorInactivo;
            btn.ForeColor = TextoInactivo;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void CargarDatosBD()
        {
            string query = @"
            SELECT 
                C.NombreCompleto AS [Nombre Completo],
                C.Identidad AS [Identidad],
                C.Telefono AS [Teléfono],
                C.CorreoElectronico AS [Correo Electrónico],
                C.NombreEmpresa AS [Nombre de Empresa],
                C.RTN AS [RTN de Empresa]
                FROM Clientes C
                ORDER BY C.NombreCompleto";

            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                        tablalocal = new DataTable();

                        adaptador.Fill(tablalocal);
                        dgvHistorial.DataSource = tablalocal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de clientes: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FiltrarHistorial();
                e.SuppressKeyPress = true;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarHistorial();
        }

        private void FiltrarHistorial()
        {
            if (tablalocal == null) return;

            string filtro = txtBuscar.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(filtro))
            {
                tablalocal.DefaultView.RowFilter = string.Empty;
                return;
            }

            try
            {
                tablalocal.DefaultView.RowFilter =
                    $"Convert([Nombre Completo], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert(Identidad, 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Nombre de Empresa], 'System.String') LIKE '%{filtro}%' OR " +
                    $"Convert([Correo Electrónico], 'System.String') LIKE '%{filtro}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los datos: " + ex.Message, "Error de Filtro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == String.Empty || txtIdentidad.Text == String.Empty)
            {
                MessageBox.Show(
                    "Los campos obligatorios no deben de estar vacíos",
                    "Campos vacíos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                //Esto solo va a estar aqui hasta que esté la funcion de insertar el cliente
                MessageBox.Show(
                    "Cleinte agregado exitosamente",
                    "Exito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                limpiarCampos();
            }
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtIdentidad.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtEmpresa.Clear();
            txtRtn.Clear();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if(txtNombre.Text.Length > 0)
            {
                if(txtNombre.Text.Length < 8)
                {
                    lblONombre.Visible = true;
                    lblONombre.Text = "Debe ingresar un nombre valido";
                    btnGuardar.Enabled = false;
                }
                else
                {
                    lblONombre.Visible = false;
                }
            }
            else
            {
                lblONombre.Visible = true;
                lblONombre.Text = "Obligatorio";
                btnGuardar.Enabled = false;
            }

            if (lblONombre.Visible == false && lblOIdentidad.Visible == false)
            {
                btnGuardar.Enabled = true;
            }
        }

        private void txtIdentidad_TextChanged(object sender, EventArgs e)
        {
            if (txtIdentidad.Text.Length > 0)
            {
                if (txtIdentidad.Text.Length < 15)
                {
                    lblOIdentidad.Visible = true;
                    lblOIdentidad.Text = "Debe ingresar un numero de identidad valido";
                    btnGuardar.Enabled = false;
                }
                else
                {
                    lblOIdentidad.Visible = false;
                }
            }
            else
            {
                lblOIdentidad.Visible = true;
                lblOIdentidad.Text = "Obligatorio";
                btnGuardar.Enabled = false;
            }

            if(lblONombre.Visible == false && lblOIdentidad.Visible == false)
            {
                btnGuardar.Enabled = true;
            }
        }

        private void agregarGionesIdentidad()
        {
            if (txtIdentidad.Text.Length == 4 || txtIdentidad.Text.Length == 9)
            {
                txtIdentidad.Text += "-";

                // Mueve el cursor al final del texto
                txtIdentidad.SelectionStart = txtIdentidad.Text.Length;
            }
        }
        private void agregarGionTelefono()
        {
            if (txtTelefono.Text.Length == 4)
            {
                txtTelefono.Text += "-";

                // Mueve el cursor al final del texto
                txtTelefono.SelectionStart = txtTelefono.Text.Length;
            }
        }

        private void txtIdentidad_KeyDown(object sender, KeyEventArgs e)
        {
            // 1. Detectar si la tecla presionado es un número (teclado principal o numérico)
            bool esNumero = (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                            (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);

            // 2. Permitir teclas de navegación y borrado
            bool esControl = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                             e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Tab;

            // 3. Bloquear si NO es número NI tecla de control
            if (!esNumero && !esControl)
            {
                e.SuppressKeyPress = true; // Cancela la tecla no numérica
                return;
            }

            // 4. Si la tecla es válida y no es de borrado, agregar guiones si corresponde
            //if (!esControl)
            //{
            //    agregarGionesIdentidad();
            //}

            if (txtIdentidad.Text.Length >= 16 && !esControl)
            {
                e.SuppressKeyPress = true; 
            }
            else if (!esControl)
            {
                agregarGionesIdentidad();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            // 1. Detectar si es número
            bool esNumero = (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                            (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);

            // 2. Teclas de navegación y borrado
            bool esControl = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                             e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Tab;

            // 3. Bloquear letras/símbolos
            if (!esNumero && !esControl)
            {
                e.SuppressKeyPress = true;
                return;
            }

            // 4. Limitar longitud máxima (9 caracteres contando el guion: XXXX-XXXX)
            if (txtTelefono.Text.Length >= 9 && !esControl)
            {
                e.SuppressKeyPress = true; // No permite escribir más de 8 números + 1 guion
            }
            else if (!esControl)
            {
                agregarGionTelefono();
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if(txtCorreo.Text.Length > 0)
            {
                if(!txtCorreo.Text.Contains(".") || !txtCorreo.Text.Contains("@"))
                {
                    lblVCorreo.Visible = true;
                    lblVCorreo.Text = "El correo debe estar en formato valido";
                }
                else
                {
                    lblVCorreo.Visible = false;
                }
            }
            else
            {
                lblVCorreo.Visible = false;
            }
        }
    }
}
