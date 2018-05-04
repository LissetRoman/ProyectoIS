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
                    label3.Text = "Establecer el tiempo para Img:" + idImg;
                    break;
                case "img2":
                    label3.Text = "Establecer el tiempo para Img:" + idImg;
                    break;
                case "img3":
                    label3.Text = "Establecer el tiempo para Img:" + idImg;
                    break;
                case "img4":
                    label3.Text = "Establecer el tiempo para Img:" + idImg;
                    break;
                default:
                    MessageBox.Show("No seleccionó imagen");
                    break;
            }

            
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            //¿qué form lo llamó?
            switch (idForm)
            {
                case "f3NuevaConf":
                    MessageBox.Show("Regresando al form:" + idForm);

                    //f3NuevaConf NuevaVentana = new f3NuevaConf();
                    //NuevaVentana.Show();
                    
                    this.Hide();
                    break;
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            //aquí hay que ingresar el registro del tiempo para la imagen seleccionada
        }
    }
}
