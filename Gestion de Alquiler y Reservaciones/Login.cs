using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class LoginForm : Form
    {
        public static string empleadoID;
        public static string nombreCompleto;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            iniciarSesion();
            txtUsuario.Clear();
            txtContra.Clear();
            empleadoID = string.Empty;
            txtUsuario.Focus();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tpUsuario.SetToolTip(txtUsuario, "Ingrese el usuario");
            tpContra.SetToolTip(txtContra, "Ingrese la contraseña");
            tpIngresar.SetToolTip(btnIngresar, "Validar credenciales e iniciar sesión");
        }

        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iniciarSesion();
                txtUsuario.Clear();
                txtContra.Clear();
                empleadoID = string.Empty;
                txtUsuario.Focus();
            }
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void iniciarSesion()
        {
            try
            {
                if (txtUsuario.Text == String.Empty || txtContra.Text == String.Empty)
                {
                    MessageBox.Show(
                        "Los campos no deben de estar vacíos",
                        "Campos vacíos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    if (txtContra.Text.Length < 4)
                    {
                        MessageBox.Show("La contraseña debe tener al menos 4 caracteres",
                            "Contraseña no segura",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    else
                    {
                        validarCredenciales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void validarCredenciales()
        {
            try
            {
                string queryPrueba = "select * from Credenciales where Usuario = @usuario and Contra = @contra;";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdQueryPrueba = new SqlCommand(queryPrueba, conectar);
                    cmdQueryPrueba.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmdQueryPrueba.Parameters.AddWithValue("@contra", txtContra.Text);
                    SqlDataReader readerQueryPrueba = cmdQueryPrueba.ExecuteReader();
                    if (readerQueryPrueba.Read())
                    {
                        empleadoID = readerQueryPrueba["Empleado_ID"].ToString();
                        readerQueryPrueba.Close();

                        this.Hide();

                        MenuPrincipalForm frm = new MenuPrincipalForm();
                        frm.ShowDialog();

                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta. Intente de nuevo",
                            "Credenciales invalidas",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }   
    }
}
