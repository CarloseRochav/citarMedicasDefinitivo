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
    public partial class Cliente_CrearCitas : Form
    {
        string consultaPacienteNombre = "SELECT IdPaciente,Nombre,ApellidoPaterno FROM PACIENTE WHERE IdPaciente = @id";//SQL obtener nombre/apellido
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos

        private int idPaciente { get; set; }//Atributo donde guardare el id del medico
        public int getid()
        {
            return idPaciente;
        }
        public void setId(int id)//a este medoto le pasare el id, del inicio
        {
            this.idPaciente = id;
        }

        public Cliente_CrearCitas()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand altas = new SqlCommand("insert into Cita values(@IdPaciente,@IdMedico,@Fecha,@Hora,@Folio,@StatusS)", conn);

                altas.Parameters.AddWithValue("IdPaciente", Convert.ToInt32(idPaciente));
                altas.Parameters.AddWithValue("IdMedico", Convert.ToInt32(idMedico));//Conversion Importante de nvarchar to int
                altas.Parameters.AddWithValue("Fecha", Convert.ToDateTime(textBox4.Text));
                altas.Parameters.AddWithValue("Hora", comboBox1.Text);
                altas.Parameters.AddWithValue("Folio", Convert.ToInt32(textBox2.Text));
                altas.Parameters.AddWithValue("StatusS", textBox3.Text); ;
                altas.CommandType = CommandType.Text;//Importante indicar que es un de tipo Text
                conexion.AbrirConexion();// se abre la conexion
                altas.ExecuteNonQuery();
                //conn.Close();// se cierra la conexion
                MessageBox.Show("Se han guardado los datos");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }catch(Exception ex)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Cliente_InicioCitas clienteCitas = new Cliente_InicioCitas();
            clienteCitas.setIdPaciente(idPaciente);
            clienteCitas.Show();
            Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int idMedico;//Valor para mostrar
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//Combo box, valor seleccionado
        {
            idMedico = Convert.ToInt32(cboMedico.SelectedValue);//Valor seleccionado del comboBox
        }

        private void MostarMedicos()//Metodo que pasa la tabla 
        {
            DataTable dt = new DataTable();
            ComboBoxes funcion = new ComboBoxes();//CObjeto de la clase Boxes
            funcion.MostrarMedicos(ref dt);//Mostrar los clientes
            cboMedico.ValueMember = "idMedico";//Valor id
            cboMedico.DisplayMember = "Nombre";//Mostrar el nombre
            cboMedico.DataSource = dt;//El origen es la tablasss
        }

        //Cambiar valor de label
        public void labelPacienteNombreApellido(int id)
        {
            string nombre;
            SqlCommand stmt = new SqlCommand(consultaPacienteNombre, conn);//No lo soluciono
            //Agregando parametros -->
            stmt.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader reader = stmt.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                    //    reader.GetString(1));
                    nombre = reader.GetInt32(0)+" "+reader.GetString(1) + " " + reader.GetString(2);//Retorna un numero, que es el id
                    label1.Text = nombre;
                }
                conn.Close();

            }
            else
            {
                //Console.WriteLine("No rows found.");
                nombre = "Medico";
                label1.Text = nombre;
                conn.Close();

            }

            //Label Transparente
            label1.BackColor = System.Drawing.Color.Transparent;


        }

        private void Cliente_CrearCitas_Load(object sender, EventArgs e)//Formulario
        {
            MostarMedicos();//Ejercutar metodo
            labelPacienteNombreApellido(idPaciente);
        }
    }
}
