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
    public partial class ADM_RClientes : Form
    {
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos

        public ADM_RClientes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
            try
            {

                SqlCommand altas = new SqlCommand("insert into Paciente values(@ApellidoPaterno,@ApellidoMaterno,@Nombre,@Genero,@FechaNacimiento,@CorreoElectronico,@Contraseña)", conn);

                altas.Parameters.AddWithValue("ApellidoPaterno", textBox2.Text);
                altas.Parameters.AddWithValue("ApellidoMaterno", textBox3.Text);
                altas.Parameters.AddWithValue("Nombre", textBox4.Text);
                altas.Parameters.AddWithValue("Genero", comboBox1.Text.Substring(0, 1));
                altas.Parameters.AddWithValue("FechaNacimiento", textBox6.Text);
                altas.Parameters.AddWithValue("CorreoElectronico", textBox7.Text);
                altas.Parameters.AddWithValue("Contraseña", textBox8.Text);

                conn.Open();// se abre la conexion
                altas.ExecuteNonQuery();
                conn.Close();// se cierra la conexion
                MessageBox.Show("Se han guardado los datos");

                comboBox1.Text = null;
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Text= "YYYY-MM-DD";
                textBox7.Clear();
                textBox8.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Paciente where CorreoElectronico='"+ textBox7.Text+"'", conn);
                
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    CReg.Visible = true;
                }
                else { CReg.Visible = false; }
                conn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "YYYY-MM-DD") textBox6.Clear();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text)) { textBox6.Text = "YYYY-MM-DD"; };
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CReg_Click(object sender, EventArgs e)
        {

        }
    }
}
