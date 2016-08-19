using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA4
{
    public partial class Form3 : Form
    {
        ControladorEmpleado controladorempleado = new ControladorEmpleado();
        EntidadEmpleado entidadempleado = new EntidadEmpleado();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                //textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
        }
        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorempleado.leerprofe();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Limpiar
            limpiarCampos();
        }
        private void limpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Agregar
            cargarEntidad();
            controladorempleado.insertarprofesor(entidadempleado);
            cargarGrid();
            limpiarCampos();
        }
        private void cargarEntidad()
        {
            entidadempleado.Id_profesor = Convert.ToInt16(textBox1.Text);
            entidadempleado.Nombre = textBox2.Text;
            entidadempleado.Apellido = textBox3.Text;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Refrescar
            cargarGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Buscar
            DataTable dt = new DataTable();
            dt = controladorempleado.buscarprofe(Convert.ToInt16(textBox1.Text));
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            //textBox4.Text = dt.Rows[0][3].ToString();
            //textBox5.Text = dt.Rows[0][4].ToString();
            //comboBox1.Text = dt.Rows[0][2].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Eliminar
            controladorempleado.eliminarprofe(Convert.ToInt16(textBox1.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Modifcar
            cargarEntidad();
            controladorempleado.modificarprofe(entidadempleado);
            cargarGrid();
            limpiarCampos();
        }
    }
}
