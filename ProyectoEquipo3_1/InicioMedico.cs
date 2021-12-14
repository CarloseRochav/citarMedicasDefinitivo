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
    public partial class InicioMedico : Form
    {
        string consultaMedico = "SELECT * FROM MEDICO WHERE CorreoElectronico = @correo AND contraseña=@contraseña";
        string consultaMedicoID= "SELECT IdMedico FROM MEDICO WHERE CorreoElectronico = @correo AND contraseña=@contraseña";//SQL para obetener el id 
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos
        //
        SqlDataReader reader;        
        public int medicConsultado(string corre, string contra)
        {// 1

            SqlCommand stmt = new SqlCommand(consultaMedico, conn);//No lo soluciono
            //Agregando parametros -->
            stmt.Parameters.AddWithValue("@correo", corre);
            stmt.Parameters.AddWithValue("@contraseña", contra);
            if (conn.State != ConnectionState.Open) conn.Open();//Validar si la conexion no es Open then open
            reader = stmt.ExecuteReader();

            //SqlDataAdapter adapt = new SqlDataAdapter(stmt);//no lo soluciono 2
            //adapt.Fill(paciente);//Pasamos la tabla al adapter para nos poble la tabla con los datos que recibio
            //Conexion.Open();
            //int i = stmt.ExecuteNonQuery();//Este regresa una cantidad de resultados devueltos            
            //Conexion.Close();          

            if (reader.Read())
            {
                reader.Close();//Cerrar read
                conn.Close();
                return 1;//encontrado 

            }
            else
            {
                reader.Close();
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

        public int idMedicoConsulta(string correo, string contra)//Obtener ID de consulta SQL
        {
            SqlCommand stmt = new SqlCommand(consultaMedicoID, conn);//No lo soluciono
            //Agregando parametros -->
            stmt.Parameters.AddWithValue("@correo", correo);
            stmt.Parameters.AddWithValue("@contraseña", contra);
            conn.Open();
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


        public InicioMedico()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //BTON
            int mensaje = medicConsultado(textBox1.Text, textBox2.Text);//Buscar los valores en la tabla paciente
            int idMedico = idMedicoConsulta(textBox1.Text, textBox2.Text); //Guardo el id del medico 
            //MessageBox.Show(" TU VALOR : - >> " +mensaje);
            
            if (mensaje == 1)
            {
                Medico_InicioCitass dashboard = new Medico_InicioCitass();
                //MessageBox.Show("ID Medico : " + idMedico);
                //dashboard.llenar(idMedico);//Le paso el id que recupere
                dashboard.setId(idMedico);
                //Le paso el id que recupere
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        /*public void logear(string usuario, string contraseña)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM MEDICO WHERE CorreoElectronico = @correo AND contraseña=@contraseña");
                cmd.Parameters.AddWithValue("@correo", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count ==1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString()== "correo")
                    {
                        new Medico_CrearCita(dt.Rows[0][0].ToString()).Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña Incorrecta");
                    }
                }    
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            { }

        }*/
    }
}
