using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProyectoEquipo3_1.Connection;
using ProyectoEquipo3_1.comboBoxes;

namespace ProyectoEquipo3_1
{
    public partial class ADM_RHorarioMedicos : Form
    {
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos

        public ADM_RHorarioMedicos()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            Visible = false;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            SqlCommand altas = new SqlCommand("insert into Horarios (Hora_Entrada,Hora_Salida,IdMedico) values(@Hora_Entrada,@Hora_Salida,@IdMedico)", conn);

            //altas.Parameters.AddWithValue("IDHorario", textBox1.Text);
            altas.Parameters.AddWithValue("Hora_Entrada", comboBox2.Text);
            altas.Parameters.AddWithValue("Hora_Salida", comboBox3.Text);
            altas.Parameters.AddWithValue("IdMedico", Convert.ToInt32(comboBox1.SelectedValue));

            conn.Open();// se abre la conexion
            altas.ExecuteNonQuery();
            conn.Close();// se cierra la conexion
            MessageBox.Show("Se han guardado los datos");

            //textBox1.Clear();

        }

        private void MostarMedicos()//Metodo que pasa la tabla 
        {
            DataTable dt = new DataTable();
            ComboBoxes funcion = new ComboBoxes();//CObjeto de la clase Boxes
            funcion.MostrarMedicos(ref dt);//Mostrar los clientes
            comboBox1.ValueMember = "idMedico";//Valor id
            comboBox1.DisplayMember = "Nombre";//Mostrar el nombre
            comboBox1.DataSource = dt;//El origen es la tablasss
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ADM_RHorarioMedicos_Load(object sender, EventArgs e)
        {
            MostarMedicos();//Mostar medicos en comboBox
        }
    }
}
