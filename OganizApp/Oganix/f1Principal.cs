using System;
using System.Collections;
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
    public partial class OrganizApp : Form
    {
        //variables globales
        string connectionString = "";//para la conexión

        public OrganizApp()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            //ejecutar consulta de usuarios
            string consultaUsuarios = "SELECT nombre_usuario FROM usuarios";

            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(consultaUsuarios, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            //definir array para almacenar usuarios
            ArrayList misUusarios = new ArrayList();

            try
            {
                // Abre la base de datos
                databaseConnection.Open();

                // Ejecuta la consultas
                reader = commandDatabase.ExecuteReader();

                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //se llena el array con los usuarios de la consulta
                        misUusarios.Add(reader.GetString(0));
                        Console.WriteLine("se agregó: " + reader.GetString(0));
                        //usuarios[i] = { reader.GetString(0), reader.GetString(1) };
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros...");
                }
                //cerrar la conexión
                databaseConnection.Close();
            }catch( Exception ex)
            {
                MessageBox.Show("Falló la conexión..."+ex);
            }

            String usr = txtUsuario.Text;
            String pass = txtContra.Text;
            String passEsperado = "";
            if (misUusarios.Contains(usr)){
                //comprobar contraseña
                string consultaPass = "SELECT contra FROM usuarios WHERE nombre_usuario='"+usr+"'";
                //databaseConnection = new MySqlConnection(connectionString);
                commandDatabase = new MySqlCommand(consultaPass, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader2;
                databaseConnection.Open();
                reader2 = commandDatabase.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        passEsperado = reader2.GetString(0);
                        
                    }
                }

            }

            //si las contraseñas coinciden
            if (pass.Equals(passEsperado))
            {
                //antes de pasar al sig form buscar el id del usr
                String id_usuario="";
                string consultaId = "SELECT id_usuario FROM usuarios WHERE nombre_usuario='" + usr + "'";
                commandDatabase = new MySqlCommand(consultaId, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader3;
                reader3 = commandDatabase.ExecuteReader();
                if (reader3.HasRows)
                {
                    while (reader3.Read())
                    {
                        id_usuario = reader3.GetString(0);

                    }
                }

                //pasar al sig. form
                this.Hide();
                f2Menu NuevaVentana = new f2Menu(id_usuario);
                NuevaVentana.Show();
            }
            else
            {
                MessageBox.Show("Error al iniciar sesión.");
                txtUsuario.Text = "";
                txtContra.Text = "";
                databaseConnection.Close();
            }

            
        }

        private void OrganizApp_Load(object sender, EventArgs e)
        {
            try
            {
                // La siguiente linea es la que provee la conexión entre C# y MySQL.
                // Debes cambiar el nombre de usuario, contrasenia y nombre de base de datos
                // de acuerdo a tus datos
                // Puedes ignorar la opción de base de datos (database) si quieres acceder a todas

                // 127.0.0.1 es de localhost y el puerto predeterminado para conectar
                connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=organizapp1;";
                
                // Tu consulta en SQL
                //string query = "SELECT * FROM user";

                // Prepara la conexión
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
               // MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                //commandDatabase.CommandTimeout = 60;
                //MySqlDataReader reader;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo conectar..."+ex);
            }
            
        }
    }
}
