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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            MenuPrincipalForm frm = new MenuPrincipalForm();
            frm.ShowDialog();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //string queryMostrarNombres = "select * from Empleados";
            //using (SqlConnection conectar = Conexion.ObtenerConexion())
            //{
            //    conectar.Open();
            //    SqlCommand cmdMostrarNombres = new SqlCommand(queryMostrarNombres, conectar);
            //    SqlDataReader readerQueryPrueba = cmdMostrarNombres.ExecuteReader();
            //    while (readerQueryPrueba.Read())
            //    {
            //        string nombre = readerQueryPrueba["Nombre"].ToString();
            //        MessageBox.Show(
            //            nombre,
            //            "Empleados",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information
            //        );
            //    }    
            //}
        }
    }
}
