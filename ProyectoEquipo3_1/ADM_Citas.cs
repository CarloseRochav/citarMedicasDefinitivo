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


namespace ProyectoEquipo3_1
{
    public partial class ADM_Citas : Form
    {

        SqlConnection Conexion = new SqlConnection(@"Data Source=localhost; Initial Catalog=CitasMedicas2; integrated security=true");

        public ADM_Citas()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        public DataTable llenar()
        {
            DataTable dt = new DataTable();
            string Consulta = "select * from Cita";
            SqlCommand cmd = new SqlCommand(Consulta, Conexion);
            SqlDataAdapter de = new SqlDataAdapter(cmd);
            de.Fill(dt);
            return dt;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                //string cadena = "Update Cita SET StatusS =@StatusS WHERE idCita=@idCita";
                string cadena = "Update Cita SET StatusS =@StatusS WHERE folio=@folio";
                SqlCommand Modificar = new SqlCommand(cadena, Conexion);
                //Modificar.Parameters.AddWithValue("idCita", textBox1.Text);
                Modificar.Parameters.AddWithValue("@folio", Convert.ToInt32(textBox1.Text));
                Modificar.Parameters.AddWithValue("@StatusS", "Cancelada");
                Conexion.Open();// se abre la conexion
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
                Conexion.Close();
            }
        }

        public void llenarDataGrid() {
            if (textBox1.Text == "")
            {
                string query = "Select * from Cita";
                SqlCommand comando = new SqlCommand(query, Conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = llenar();
            }
            else
            {
                string query = "Select * from Cita where Folio = '" + textBox1.Text + "'";
                SqlCommand comando = new SqlCommand(query, Conexion);
                SqlDataAdapter data = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                dataGridView1.DataSource = tabla;
            }

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

        private void ADM_Citas_Load(object sender, EventArgs e)//CARGA DE FORMULARIO
        {
            llenarDataGrid();//Metodo para cargar citas al dataGrid
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            llenarDataGrid();//C a r g a r Tabla
        }

        private void pictureBox5_Click(object sender, EventArgs e)//Eliminar
        {
            try
            {
                //string cadena = "Update Cita SET StatusS =@StatusS WHERE idCita=@idCita";
                string cadena = "Update Cita SET StatusS =@StatusS WHERE folio=@folio";
                SqlCommand Modificar = new SqlCommand(cadena, Conexion);
                //Modificar.Parameters.AddWithValue("idCita", textBox1.Text);
                Modificar.Parameters.AddWithValue("@folio", Convert.ToInt32(textBox1.Text));
                Modificar.Parameters.AddWithValue("@StatusS", "Eliminada");
                Conexion.Open();// se abre la conexion
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
                Conexion.Close();
            }
        }
    }
}
