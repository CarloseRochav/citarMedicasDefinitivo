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
    public partial class InicioPaciente : Form
    {
        string pacConsulta = "SELECT * FROM Paciente WHERE CorreoElectronico = @correo AND contraseña=@contraseña";
        string consultaPacID = "SELECT IdPaciente FROM Paciente WHERE CorreoElectronico = @correo AND contraseña=@contraseña";//SQL para obetener el id 


        static Conexion conexion = new Conexion();
        //SqlConnection conn = conexion.getConnection();//Conexion a la base de datos
        Conexion conn = new Conexion();
        //
        SqlDataReader reader;
        public int pacConsultado(string corre, string contra)
        {// 1

            SqlCommand stmt = new SqlCommand(pacConsulta, conn.getConnection());//No lo soluciono
            //Agregando parametros -->
            stmt.Parameters.AddWithValue("@correo", corre);
            stmt.Parameters.AddWithValue("@contraseña", contra);
            conn.AbrirConexion();
            reader = stmt.ExecuteReader();            
            //SqlDataAdapter adapt = new SqlDataAdapter(stmt);//no lo soluciono 2
            //adapt.Fill(paciente);//Pasamos la tabla al adapter para nos poble la tabla con los datos que recibio
            //Conexion.Open();
            //int i = stmt.ExecuteNonQuery();//Este regresa una cantidad de resultados devueltos                      


            if (reader.Read())
            {

                conn.CerrarConexion();
                return 1;//encontrado 
            }
            else
            {

                conn.CerrarConexion();
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

        public int idPacienteConsulta(string correo, string contra)//Obtener ID de consulta SQL
        {
            SqlCommand stmt = new SqlCommand(consultaPacID, conn.getConnection());//No lo soluciono
            //Agregando parametros -->
            stmt.Parameters.AddWithValue("@correo", correo);
            stmt.Parameters.AddWithValue("@contraseña", contra);
            conn.AbrirConexion();
            reader = stmt.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                    //    reader.GetString(1));
                    return reader.GetInt32(0);//Retorna un numero, que es el id
                }
                return 0;
            }
            else
            {
                //Console.WriteLine("No rows found.");
                return 0;
            }

        }

        public InicioPaciente()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InicioPaciente_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //boton
            int mensaje = pacConsultado(textBox1.Text, textBox2.Text);//Buscar los valores en la tabla paciente
            int idPaciente = idPacienteConsulta(textBox1.Text, textBox2.Text);//Regresa el id de la consulta

            if (mensaje == 1)
            {
                Cliente_InicioCitas dashboard = new Cliente_InicioCitas();
                //MessageBox.Show("ID Paciente _ "+idPaciente);
                dashboard.setIdPaciente(idPaciente);
                this.Hide();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Usuario no registrado");
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Main start = new Main();
            this.Hide();
            start.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
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
