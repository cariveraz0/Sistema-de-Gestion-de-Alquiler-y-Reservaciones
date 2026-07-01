using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}
