using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gestion_de_Alquiler_y_Reservaciones
{
    public partial class LoginForm : Form
    {
        public static string empleadoID; //Para que esta variable pueda ser leida desde cualqueir ventana
        public static string nombreCompleto; //Para que esta variable pueda ser leida desde cualqueir ventana

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContra.Clear();
            empleadoID = string.Empty;
            txtUsuario.Focus();

            iniciarSesion();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tpUsuario.SetToolTip(txtUsuario, "Ingrese el usuario");
            tpContra.SetToolTip(txtContra, "Ingrese el la contraseña");
            tpIngresar.SetToolTip(btnIngresar, "Validar credenciales e iniciar sesion");
        }

        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iniciarSesion();
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
                        "Los campos no deben de estar vacios",
                        "Campos vacios", MessageBoxButtons.OK,
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

                        // Limpiamos los campos para mayor seguridad
                        txtUsuario.Clear();
                        txtContra.Clear();
                        txtUsuario.Focus();

                        obtenerDatos(empleadoID); //Esto es solo para probar la conexion a la DB y mostrar nuestros nombres

                        MenuPrincipalForm frm = new MenuPrincipalForm();
                        frm.ShowDialog();
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


        private void obtenerDatos(string empleadoID)
        {
            //Esta funcion solo es de prueba, es para que vean cómo se usarán las consultas.
            try
            {
                string queryObtenerDatos = "select * from Empleados where Empleado_ID = @id;";
                using (SqlConnection conectar = Conexion.ObtenerConexion())
                {
                    conectar.Open();
                    SqlCommand cmdObtenerDatos = new SqlCommand(queryObtenerDatos, conectar);
                    cmdObtenerDatos.Parameters.AddWithValue("@id", empleadoID);
                    SqlDataReader readerObtenerDatos = cmdObtenerDatos.ExecuteReader();
                    if (readerObtenerDatos.Read())
                    {
                        nombreCompleto = readerObtenerDatos["Nombre"].ToString();
                        string[] nombrePartes = nombreCompleto.Split(' ');
                        string nombre3 = "";

                        for (int i = 0; i <= 2; i++)
                        {
                            nombre3 += nombrePartes[i];
                            if (i < 2)
                            {
                                nombre3 += " ";
                            }
                        }
                        //Para ver el texto en la consola
                        System.Diagnostics.Debug.WriteLine("Hola " + nombre3);

                        MessageBox.Show(
                            "Hola " + nombre3,
                            "Empleados",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
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
                    "Algo salió mal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
