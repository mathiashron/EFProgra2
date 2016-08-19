using System;
using System.Data;
using System.Windows.Forms;

namespace WFA4
{
    public partial class Form1 : Form
    {
        ControladorEmpleado controladorempleado = new ControladorEmpleado();
        EntidadEmpleado entidadempleado = new EntidadEmpleado();

        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
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
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Limpiar
            limpiarCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Agregar
            cargarEntidad();
            controladorempleado.insertar(entidadempleado);
            cargarGrid();
            limpiarCampos();
        }       

        private void button3_Click(object sender, EventArgs e)
        {
            //Modifcar
            cargarEntidad();
            controladorempleado.modificar(entidadempleado);
            cargarGrid();
            limpiarCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Eliminar
            controladorempleado.eliminar(Convert.ToInt16(textBox1.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Buscar
            DataTable dt = new DataTable();
            dt = controladorempleado.buscar(Convert.ToInt16(textBox1.Text));
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            textBox4.Text = dt.Rows[0][3].ToString();
            textBox5.Text = dt.Rows[0][4].ToString();
            comboBox1.Text = dt.Rows[0][5].ToString();
            //int index = Convert.ToInt16(dt.Rows[0][4].ToString()) + 1;
            //comboBox1.SelectedIndex = index;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Refrescar
            cargarGrid();
        }

        private void limpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
        }       

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorempleado.leer();
        }

        private void cargarCombo()
        {
            DataTable dt = new DataTable();
            dt = controladorempleado.leermateria();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                comboBox1.Items.Insert(i, dt.Rows[i][0].ToString());
            }
            comboBox1.SelectedIndex = 0;
            //comboBox1.DataSource = dt;
            //comboBox1.DisplayMember = "nombre";
            //comboBox1.ValueMember = "id_materia";
            //comboBox1.SelectedIndex = 0;
        }

        private void cargarEntidad()
        {
            entidadempleado.Id_estudiante = Convert.ToInt16(textBox1.Text);
            entidadempleado.Nombre = textBox2.Text;
            entidadempleado.Apellido = textBox3.Text;
            entidadempleado.Direccion = textBox4.Text;
            entidadempleado.Edad = Convert.ToInt16(textBox5.Text);
            entidadempleado.Id_curso = Convert.ToInt16(comboBox1.SelectedValue);
        }

        private void estudianteToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void materiaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 materia = new Form2();
            materia.Show();
        }

        private void profesorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 profe = new Form3();
            profe.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            estadistica estadis = new estadistica();
            estadis.menu();

        }

            


          
            

        

    
    }
}
