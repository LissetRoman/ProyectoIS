using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oganix
{
    public partial class OrganizApp : Form
    {
        public OrganizApp()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Coordi" && txtContra.Text == "123")
            {
                this.Hide();
                f2Menu NuevaVentana = new f2Menu();
                NuevaVentana.Show();
            }
            else
            {
                MessageBox.Show("Error al iniciar sesión.");
                txtUsuario.Text = "";
                txtContra.Text = "";
            }
        }

        private void OrganizApp_Load(object sender, EventArgs e)
        {

        }
    }
}
