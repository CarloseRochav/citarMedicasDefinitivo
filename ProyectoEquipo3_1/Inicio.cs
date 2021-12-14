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
    public partial class Inicio : Form
    {

        string consultaAdmin = "SELECT * FROM Administrador WHERE CorreoElectronico = @correo AND contraseña=@contraseña";
        static Conexion conexion = new Conexion();

        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos
        //
        SqlDataReader reader;
        public int adminConsultado(string corre, string contra)
        {// 1

            SqlCommand stmt = new SqlCommand(consultaAdmin, conn);//No lo soluciono
            //Agregando parametros -->
            stmt.Parameters.AddWithValue("@correo", corre);
            stmt.Parameters.AddWithValue("@contraseña", contra);
            conn.Open();
            reader = stmt.ExecuteReader();
            //SqlDataAdapter adapt = new SqlDataAdapter(stmt);//no lo soluciono 2
            //adapt.Fill(paciente);//Pasamos la tabla al adapter para nos poble la tabla con los datos que recibio
            //Conexion.Open();
            //int i = stmt.ExecuteNonQuery();//Este regresa una cantidad de resultados devueltos            
            //Conexion.Close();


            if (reader.Read())
            {

                conn.Close();
                return 1;//encontrado 
            }
            else
            {

                conn.Close();
                return 0;//no encontrado
            }
            //if (paciente.Rows.Count > 0)
            //{
            //    return "Paciente Encontrado";

            //}
            //else
            //{
            //    return "No hay registros";

            //}

        }

        public Inicio()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int mensaje = adminConsultado(textBox1.Text, textBox2.Text);//Buscar los valores en la tabla paciente

            if (mensaje == 1)
            {
                Form1 dashboardAdmin = new Form1();
                this.Hide();
                dashboardAdmin.Show();
            }
            else
            {
                MessageBox.Show("Usuario no registrado");
            }
            textBox1.Clear();
            textBox2.Clear();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Main start = new Main();
            this.Hide();
            start.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (textBox2.PasswordChar == '*')
                {
                    textBox2.PasswordChar = '\0';
                }
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
