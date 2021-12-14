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

namespace ProyectoEquipo3_1
{
    public partial class ADM_REspecialidad : Form
    {
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos

        public ADM_REspecialidad()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
            SqlCommand altas = new SqlCommand("insert into Especialidad (IDEspecialidad_Nombre,Descripcion) values(@IDEspecialidad_Nombre,@Descripcion)", conn);

            altas.Parameters.AddWithValue("IDEspecialidad_Nombre", textBox1.Text);
            altas.Parameters.AddWithValue("Descripcion", textBox2.Text);

            conn.Open();// se abre la conexion
            altas.ExecuteNonQuery();
            conn.Close();// se cierra la conexion
            MessageBox.Show("Se han guardado los datos");

            textBox1.Clear();
            textBox2.Clear();

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
        }
    }
}
