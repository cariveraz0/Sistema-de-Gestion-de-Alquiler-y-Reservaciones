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

        public ClientesForm()
        {
            InitializeComponent();
            ActivarTabNuevo();
            CargarDatosBD();
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
            txtNombre.Clear();
            txtIdentidad.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtEmpresa.Clear();
            txtRtn.Clear();
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
                // Utilizamos tu clase de conexión centralizada
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);

                        DataTable tablalocal = new DataTable();

                        adaptador.Fill(tablalocal);
                        dgvHistorial.DataSource = tablalocal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de contratos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void ClientesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
