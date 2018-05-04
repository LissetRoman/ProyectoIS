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


namespace Oganix.Resources
{
    public partial class FrmProyeccion : Form
    {
        //variables globales 
        String excel, msj;
        public FrmProyeccion(String archivoExcel, String mensaje)
        {
            excel = archivoExcel;
            msj = mensaje;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmProyeccion_Load(object sender, EventArgs e)
        {
            //cuando se carga el formulario cargar los elementos


            //cargar el msj
            textBox1.Text = msj;

            //cargar el excel
            ExcelFile ef = ExcelFile.Load(excel);
            DataGridViewConverter.ExportToDataGridView(ef.Worksheets.ActiveWorksheet, this.dataGridView1, new ExportToDataGridViewOptions() { ColumnHeaders = true });
        }

        private void btn_cerrarProyeccion_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
