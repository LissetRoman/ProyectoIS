using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//para la conexión a la bd
using MySql.Data.MySqlClient;


namespace Oganix
{
    public partial class f2Menu : Form
    {
        //variables globales
        String responsable = "";
        String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=organizapp1;";
        Boolean banderaReg = false;

        public f2Menu(String id_usuario)
        {
            responsable = id_usuario;
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            //antes de pasar a la ventana 

            //comprobar, si hay registros y presionó nueva entonces eliminar los registros existentes
            if (banderaReg == true)
            {

            }
            this.Hide();
            f3NuevaConf NuevaVentana = new f3NuevaConf(responsable);
            NuevaVentana.Show();
        }

        private void f2Menu_Load(object sender, EventArgs e)
        {
            //cuando el form carga checar si hay registros de proyeccion
            string consultaProyecciones = "SELECT * FROM proyeccion";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(consultaProyecciones, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                // Abre la base de datos
                databaseConnection.Open();

                // Ejecuta la consultas
                reader = commandDatabase.ExecuteReader();

                //si hay registros activar bandera
                if (reader.HasRows)
                {
                    banderaReg = true;
                    /*while (reader.Read())
                    {
                        //se llena el array con los usuarios de la consulta
                        misUusarios.Add(reader.GetString(0));
                        Console.WriteLine("se agregó: " + reader.GetString(0));
                        //usuarios[i] = { reader.GetString(0), reader.GetString(1) };
                    }*/
                }
                else
                {
                    MessageBox.Show("No hay registros...");
                    //si no hay registros activar el boton de nueva configuración
                    btnNueva.Enabled = true;
                }
                //cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló la conexión..." + ex);
            }
        }
    }
}
