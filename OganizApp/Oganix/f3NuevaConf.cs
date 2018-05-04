using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//para excel
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using Oganix.Resources;

//para la conexión a la bd
using MySql.Data.MySqlClient;


namespace Oganix
{
    public partial class f3NuevaConf : Form
    {
        //variables globales
        String archivoExcel = "";
        String mensaje = "";

        String idResp = "";
        String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=organizapp1;";
        

        public f3NuevaConf(String responsable)
        {
            idResp = responsable;
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            f4Ayuda NuevaVentana = new f4Ayuda();
            NuevaVentana.Show();
        }

        private void btn_agregarImg_Click(object sender, EventArgs e)
        {
            //filtro
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Imagen|*.png";
            openFileDialog1.Title = "Seleccione una imagen";


            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String nombreImagen = openFileDialog1.FileName;
                    //sr.Close();
                    MessageBox.Show(nombreImagen);

                    //en qué pictureBox se mostrará?
                    if (pictureBox1.Image == null)
                    {
                        pictureBox1.Visible = true;
                        pictureBox1.Image = Image.FromFile(nombreImagen);
                        btn_eliminarImg1.Visible = true;
                        btn_agregarTime1.Visible = true;
                    }
                    else
                    {
                        if (pictureBox2.Image == null)
                        {
                            pictureBox2.Visible = true;
                            pictureBox2.Image = Image.FromFile(nombreImagen);
                            btn_eliminarImg2.Visible = true;
                            btn_agregarTime2.Visible = true;
                        }
                        else
                        {
                            if (pictureBox3.Image == null)
                            {
                                pictureBox3.Visible = true;
                                pictureBox3.Image = Image.FromFile(nombreImagen);
                                btn_eliminarImg3.Visible = true;
                                btn_agregarTime3.Visible = true;
                            }
                            else
                            {
                                if (pictureBox4.Image == null)
                                {
                                    pictureBox4.Visible = true;
                                    pictureBox4.Image = Image.FromFile(nombreImagen);
                                    btn_eliminarImg4.Visible = true;
                                    btn_agregarTime4.Visible = true;
                                }
                                else
                                {
                                    MessageBox.Show("Sólo puede agregar un máximo de 4 imágenes");
                                }
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void btn_eliminarImg1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Visible = false;
            btn_eliminarImg1.Visible = false;
            btn_agregarTime1.Visible = false;
        }

        private void btn_agregarTime1_Click(object sender, EventArgs e)
        {
            String identificadorImg = "img1";
            String identificadorForm = "f3NuevaConf";
            f6Tiempo NuevaVentana = new f6Tiempo(identificadorImg,identificadorForm);
            NuevaVentana.Show();
        }

        private void btn_agregarTime2_Click(object sender, EventArgs e)
        {
            String identificadorImg = "img2";
            String identificadorForm = "f3NuevaConf";
            f6Tiempo NuevaVentana = new f6Tiempo(identificadorImg, identificadorForm);
            NuevaVentana.Show();
        }

        private void btn_agregarTime3_Click(object sender, EventArgs e)
        {
            String identificadorImg = "img3";
            String identificadorForm = "f3NuevaConf";
            f6Tiempo NuevaVentana = new f6Tiempo(identificadorImg, identificadorForm);
            NuevaVentana.Show();
        }

        private void btn_agregarTime4_Click(object sender, EventArgs e)
        {
            String identificadorImg = "img4";
            String identificadorForm = "f3NuevaConf";
            f6Tiempo NuevaVentana = new f6Tiempo(identificadorImg, identificadorForm);
            NuevaVentana.Show();
        }

        private void btn_eliminarImg2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            pictureBox2.Visible = false;
            btn_eliminarImg2.Visible = false;
            btn_agregarTime2.Visible = false;
        }

        private void btn_eliminarImg3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = null;
            pictureBox3.Visible = false;
            btn_eliminarImg3.Visible = false;
            btn_agregarTime3.Visible = false;
        }

        private void btn_eliminarImg4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = null;
            pictureBox4.Visible = false;
            btn_eliminarImg4.Visible = false;
            btn_agregarTime4.Visible = false;
        }

        private void btn_agregarMsj_Click(object sender, EventArgs e)
        {
            
            textBox1.Enabled = true;
        }

        private void btn_agregarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm";
            //openFileDialog.FilterIndex = 2;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //aquí se guarda el excel
                archivoExcel = openFileDialog.FileName;

                ExcelFile ef = ExcelFile.Load(openFileDialog.FileName);

                // Export Excel worksheet to DataGridView control.
                DataGridViewConverter.ExportToDataGridView(ef.Worksheets.ActiveWorksheet, this.dataGridView1, new ExportToDataGridViewOptions() { ColumnHeaders = true });
            }
        }

        private void btn_fijarMsj_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("Escriba un anuncio"))
            {
                mensaje = "";
            }
            else
            {
                mensaje = textBox1.Text;
                textBox1.Enabled = false;
            }
            
        }

        private void btn_proyectar_Click(object sender, EventArgs e)
        {
            //aquí se mandan todos los datos al form de la proyección
            FrmProyeccion NuevaVentana = new FrmProyeccion(archivoExcel, mensaje);
            NuevaVentana.Show();
        }

        private void f3NuevaConf_Load(object sender, EventArgs e)
        {

        }
    }
}
