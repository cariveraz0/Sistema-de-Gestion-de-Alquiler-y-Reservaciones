using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class LoginForm : Form
    {
        public static string empleadoID;
        public static string nombreCompleto;
        public static string cargo;

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
            nombreCompleto = string.Empty;
            cargo = string.Empty;
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
                nombreCompleto = string.Empty;
                cargo= string.Empty;
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
                MessageBox.Show(
                    ex.Message,
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Verifica si el usuario o contraseña proporcionados existen en la DB y luego compara si
        /// son exactamente iguales 
        /// </summary>
        private void validarCredenciales()
        {
            try
            {
                string usuarioDB, contraDB;
                string queryPrueba = "select * from Credenciales where Usuario = @usuario or Contra = @contra;";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdQueryPrueba = new SqlCommand(queryPrueba, conectar);
                    cmdQueryPrueba.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmdQueryPrueba.Parameters.AddWithValue("@contra", txtContra.Text);
                    SqlDataReader readerQueryPrueba = cmdQueryPrueba.ExecuteReader();
                    if (readerQueryPrueba.Read())
                    {
                        //Consultamos en la DB las credenciales del usuario que coinciden con alguno de
                        //los dos datos proporcionados
                        usuarioDB = readerQueryPrueba["Usuario"].ToString();
                        contraDB = readerQueryPrueba["Contra"].ToString();

                        if(txtUsuario.Text == usuarioDB && txtContra.Text == contraDB)
                        {
                            empleadoID = readerQueryPrueba["Empleado_ID"].ToString();
                            nombreCompleto = obtenerDatosEmpleado(empleadoID);
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
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        
        /// <summary>
        /// Devuelve el nombre completo del usuario dependiendo del EmpleadoID que le demos como arametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string obtenerDatosEmpleado(string id)
        {
            string nombreCompleto = string.Empty;
            try
            {
                string queryObtenerNombreCompleto = "select * from Empleados where Empleado_ID = @id;";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdObtenerNombreCompleto = new SqlCommand(queryObtenerNombreCompleto, conectar);
                    cmdObtenerNombreCompleto.Parameters.AddWithValue("@id", id);
                    SqlDataReader readerObtenerNombreCompleto = cmdObtenerNombreCompleto.ExecuteReader();
                    if (readerObtenerNombreCompleto.Read())
                    {
                        nombreCompleto = readerObtenerNombreCompleto["Nombre"].ToString();
                        cargo = readerObtenerNombreCompleto["Cargo"].ToString();
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
                    "Algos salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return nombreCompleto;
        }
    }
}
