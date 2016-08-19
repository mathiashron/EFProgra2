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
    public partial class Form2 : Form
    {
        ControladorEmpleado controladorempleado = new ControladorEmpleado();
        EntidadEmpleado entidadempleado = new EntidadEmpleado();
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cargarGrid();
            cargarCombo();
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                // textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                //textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorempleado.leermateria();
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
            comboBox1.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Agregar
            cargarEntidad();
            controladorempleado.insertarmateria(entidadempleado);
            cargarGrid();
            limpiarCampos();
        }



        private void cargarEntidad()
        {
            entidadempleado.Id_materia = Convert.ToInt16(textBox1.Text);
            entidadempleado.Nombre = textBox2.Text;
           // entidadempleado.Apellido = textBox3.Text;
           // entidadempleado.Direccion = textBox4.Text;
            //entidadempleado.Edad = Convert.ToInt16(textBox5.Text);
            entidadempleado.Id_profesor = Convert.ToInt16(comboBox1.SelectedItem);
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
            dt = controladorempleado.buscarmateria(Convert.ToInt16(textBox1.Text));
            textBox2.Text = dt.Rows[0][1].ToString();
            //textBox3.Text = dt.Rows[0][2].ToString();
            //textBox4.Text = dt.Rows[0][3].ToString();
            //textBox5.Text = dt.Rows[0][4].ToString();
            comboBox1.Text = dt.Rows[0][2].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Eliminar
            controladorempleado.eliminarmateria(Convert.ToInt16(textBox1.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Modifcar
            cargarEntidad();
            controladorempleado.modificarmateria(entidadempleado);
            cargarGrid();
            limpiarCampos();
        }
        private void cargarCombo()
        {
            DataTable dt = new DataTable();
            dt = controladorempleado.leerprofe();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                comboBox1.Items.Insert(i, dt.Rows[i][0].ToString());
            }
            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
