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
    public partial class f2Menu : Form
    {
        public f2Menu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            this.Hide();
            f3NuevaConf NuevaVentana = new f3NuevaConf();
            NuevaVentana.Show();
        }
    }
}
