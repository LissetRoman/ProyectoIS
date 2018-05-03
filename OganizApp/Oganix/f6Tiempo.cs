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
    public partial class f6Tiempo : Form
    {
        //variables
        String idImg = "";
        String idForm = "";

        //constructor default
        public f6Tiempo()
        {
            InitializeComponent();
        }

        //constructor que recibe el identificador de la img
        public f6Tiempo(String identificadorImg, String identificadorForm)
        {
            idImg = identificadorImg;
            idForm = identificadorForm;
            InitializeComponent();
        }

        private void f6Tiempo_Load(object sender, EventArgs e)
        {
            //para establecer el tiempo a cada img
            switch (idImg)
            {
                case "img1":
                    break;
                case "img2":
                    break;
            }

            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        
    }
}
