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
    public partial class Medico_InicioCitass : Form
    {
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos

        private int idMedico { get; set; }//Atributo donde guardare el id del medico
        public int getid()
        {
            return idMedico;
        }
        public void setId(int id)//a este medoto le pasare el id, del inicio
        {
            this.idMedico = id;
        }


        public Medico_InicioCitass()
        {
            InitializeComponent();
        }

        private void Medico_InicioCitass_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)//Mostrar Form Crear Cita
        {
            this.Hide();
            Medico_CrearCita CrearCita = new Medico_CrearCita();
            CrearCita.setId(idMedico);
            CrearCita.Show();
            Visible = false;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            InicioMedico Inicio = new InicioMedico(); 
            Inicio.Show();
            Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string cadena = "Update Cita SET StatusS =@StatusS WHERE Folio=@Folio";
            SqlCommand Modificar = new SqlCommand(cadena, conn);
            Modificar.Parameters.AddWithValue("@Folio", dataGridView1.CurrentCell.Value);
            Modificar.Parameters.AddWithValue("@StatusS", "Eliminada");
            Modificar.ExecuteNonQuery();
            conn.Close();// se cierra la conexion
            MessageBox.Show("Cita Modificado");
            // limpiar los textbox
            textBox1.Clear();
            this.Hide();
            Medico_InicioCitass frm = new Medico_InicioCitass();
            frm.Show();
        }
        
       /* private void pictureBox5_Click(object sender, EventArgs e)
        {
            string cadena = "Update Cita SET StatusS =@StatusS WHERE Folio=@Folio";
            SqlCommand Modificar = new SqlCommand(cadena, conn);
            Modificar.Parameters.AddWithValue("@StatusS", "Cancelada");
            Modificar.ExecuteNonQuery();
            conn.Close();// se cierra la conexion
            MessageBox.Show("Cita Modificado");
            // limpiar los textbox
            textBox1.Clear();
            this.Hide();
            Medico_InicioCitass frm = new Medico_InicioCitass();
            frm.Show();
        }*/

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            try
            {
                //string cadena = "Update Cita SET StatusS =@StatusS WHERE IdMedico=@IdMedico";
                string cadena = "Update Cita SET StatusS =@StatusS WHERE folio=@folio";
                SqlCommand Modificar = new SqlCommand(cadena, conn);
                //Modificar.Parameters.AddWithValue("IdMedico", textBox1.Text);
                Modificar.Parameters.AddWithValue("@folio", Convert.ToInt32(textBox1.Text));
                Modificar.Parameters.AddWithValue("@StatusS", "Cancelada");
                conexion.AbrirConexion();// se abre la conexion
                Modificar.ExecuteNonQuery();
                //conn.Close();// se cierra la conexion
                MessageBox.Show("Cita Modificado");
                // limpiar los textbox
                textBox1.Clear();
                //this.Hide();
                //Medico_InicioCitass frm = new Medico_InicioCitass();
                //frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
        public DataTable llenar(int id)//Metodo ; Origen de los datos para llenar la tabla - LLENAR
        { 
            DataTable dt = new DataTable();
            string Consulta = "select * from Cita where IdMedico = "+id;
            SqlCommand cmd = new SqlCommand(Consulta, conn);
            SqlDataAdapter de = new SqlDataAdapter(cmd);
            de.Fill(dt);
            return dt;
        }

        private void pictureBox9_Click(object sender, EventArgs e)//Boton de actualizar
        {
            if (textBox1.Text == "")
            {
                string query = "Select * from Cita";
                conn.Open();//abrir conexion importante
                SqlCommand comando = new SqlCommand(query, conn);
                //comando.Parameters.AddWithValue("@Id", idMedico);
                //comando.ExecuteNonQuery();
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = llenar(idMedico);
                conn.Close();//Cerrar la conexcion importante
            }
            else
            {
                string query = "Select * from Cita where Folio = '" + textBox1.Text + "'";
                SqlCommand comando = new SqlCommand(query, conn);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            try
            {
                //string idMed = dataGridView1.CurrentRow.Cells["IdMedico"].Value.ToString();
                //string cadena = "Update Cita SET StatusS =@StatusS WHERE IdMedico=@IdMedico";
                string cadena = "Update Cita SET StatusS =@StatusS WHERE folio=@folio";
                SqlCommand Modificar = new SqlCommand(cadena, conn);
                //Modificar.Parameters.AddWithValue("@IdMedico", idMed);
                Modificar.Parameters.AddWithValue("@folio", Convert.ToInt32(textBox1.Text));
                Modificar.Parameters.AddWithValue("@StatusS", "Eliminada");
                conexion.AbrirConexion();// se abre la conexion
                Modificar.ExecuteNonQuery();
                //conn.Close();// se cierra la conexion
                MessageBox.Show("Cita Modificado");
                // limpiar los textbox
                textBox1.Clear();
                //this.Hide();
                //Medico_InicioCitass frm = new Medico_InicioCitass();
                //frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
