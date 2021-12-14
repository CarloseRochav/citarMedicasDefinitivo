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
    public partial class Cliente_InicioCitas : Form
    {
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos

        private int idPaciente { get; set; }//Atributo donde guardare el id del medico
        public int getidPaciente()
        {
            return idPaciente;
        }
        public void setIdPaciente(int id)//a este medoto le pasare el id, del inicio
        {
            this.idPaciente= id;
        }


        public Cliente_InicioCitas()
        {
            InitializeComponent();
        }

        private void Cliente_InicioCitas_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void pictureBox8_Click(object sender, EventArgs e)//Abrir Form Crear Cita
        {
            this.Hide();
            Cliente_CrearCitas crearCita = new Cliente_CrearCitas();
            crearCita.setId(idPaciente);
            crearCita.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            InicioPaciente Inicio = new InicioPaciente();
            Inicio.Show();

            Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                // string cadena = "Update Cita SET StatusS =@StatusS WHERE idCita=@idCita";
                string cadena = "Update Cita SET StatusS =@StatusS WHERE folio=@folio";
                SqlCommand Modificar = new SqlCommand(cadena, conn);
                //Modificar.Parameters.AddWithValue("idCita", textBox1.Text);
                Modificar.Parameters.AddWithValue("@StatusS", "Eliminada");
                Modificar.Parameters.AddWithValue("@folio", Convert.ToInt32(textBox1.Text));
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
        public DataTable llenar(int id)
        {
            DataTable dt = new DataTable();
            string Consulta = "select * from Cita where idPaciente ="+id;
            SqlCommand cmd = new SqlCommand(Consulta, conn);
            SqlDataAdapter de = new SqlDataAdapter(cmd);
            de.Fill(dt);
            return dt;
        }

        private void pictureBox5_Click(object sender, EventArgs e)//Boton para actualizar
        {
            try
            {
                //string cadena = "Update Cita SET StatusS =@StatusS WHERE idCita=@idCita";
                string cadena = "Update Cita SET StatusS =@StatusS WHERE folio=@folio";
                SqlCommand Modificar = new SqlCommand(cadena, conn);
                //Modificar.Parameters.AddWithValue("idCita", textBox1.Text);
                Modificar.Parameters.AddWithValue("@StatusS", "Cancelada");
                Modificar.Parameters.AddWithValue("@folio", Convert.ToInt32(textBox1.Text));
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

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
        }


        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string query = "Select * from Cita";
                SqlCommand comando = new SqlCommand(query, conn);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = llenar(idPaciente);
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
    }
}
