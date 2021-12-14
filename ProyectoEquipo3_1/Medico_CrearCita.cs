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
using ProyectoEquipo3_1.comboBoxes;
using ProyectoEquipo3_1.Connection;


namespace ProyectoEquipo3_1
{
    public partial class Medico_CrearCita : Form
    {

        string consultaMedicoNombre = "SELECT Nombre,ApellidoPaterno FROM MEDICO WHERE IdMedico = @id";//SQL obtener nombre/apellido
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos cierra toda tus conexiones        
        ComboBoxes boxes = new ComboBoxes();

        private int idMedico { get; set; }//Atributo donde guardare el id del medico
        public int getid()
        {
            return idMedico;
        }


        public void setId(int id)//a este medoto le pasare el id, del inicio
        {
            this.idMedico = id;
        }




        public Medico_CrearCita()
        {
            InitializeComponent();
            //mostratCom();
            //boxes.mostraridPacientes(cboCliente);//Muestra paciente en comboBox
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Medico_InicioCitass medicoCitas = new Medico_InicioCitass();
            medicoCitas.setId(idMedico);
            medicoCitas.Show();
            Visible = false;
        }

        private void pictureBox11_Click(object sender, EventArgs e)//Crear Cita -- > Funcioando
        {
            try
            {
                SqlCommand altas = new SqlCommand("insert into Cita values(@IdPaciente,@IdMedico,@Fecha,@Hora,@Folio,@StatusS)", conn);
                
                altas.Parameters.AddWithValue("IdMedico", Convert.ToInt32(idMedico));//Conversiones
                altas.Parameters.AddWithValue("IdPaciente", Convert.ToInt32(idPaciente));//EL id del paciente capturado
                altas.Parameters.AddWithValue("Fecha",Convert.ToDateTime( textBox4.Text));
                altas.Parameters.AddWithValue("Hora", comboBox3.Text);
                altas.Parameters.AddWithValue("Folio",Convert.ToInt32( txtFolio.Text));
                altas.Parameters.AddWithValue("StatusS", textBox3.Text); ;
                altas.CommandType = CommandType.Text;
                conexion.AbrirConexion();// se abre la conexion
                altas.ExecuteNonQuery();
                //conn.Close();// se cierra la conexion
                MessageBox.Show("Se han guardado los datos");

                textBox1.Clear();
                txtFolio.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);
                //conn.Close();
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
        int idPaciente;//Valor para mostrar

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//Asignacion del valor seleccionado
        {
            idPaciente =Convert.ToInt32(cboCliente.SelectedValue);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void MostarCliente()//Metodo que pasa la tabla 
        {
            DataTable dt = new DataTable();
            ComboBoxes funcion = new ComboBoxes();//CObjeto de la clase Boxes
            funcion.MostrarCliente(ref dt);//Mostrar los clientes
            cboCliente.ValueMember = "idPaciente";//Valor id
            cboCliente.DisplayMember = "Nombre";//Mostrar el nombre
            cboCliente.DataSource = dt;//El origen es la tablasss
        }

        //Cambiar valor de label
        public void labelMedicoNombreApellido(int idM)
        {
            string nombreMedico;
            SqlCommand stmt = new SqlCommand(consultaMedicoNombre, conn);//No lo soluciono
            //Agregando parametros -->
            stmt.Parameters.AddWithValue("@id", idM);            
            conexion.AbrirConexion();//Hay que conocer si la base esta cerrada o abierta
            SqlDataReader reader = stmt.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                    //    reader.GetString(1));
                    nombreMedico= reader.GetString(0)+" "+ reader.GetString(1);//Retorna un numero, que es el id
                    label1.Text = nombreMedico;
                }
                conexion.CerrarConexion();
            }
            else
            {
                //Console.WriteLine("No rows found.");
                nombreMedico = "Medico";
                label1.Text = nombreMedico;
                conexion.CerrarConexion();
            }

            //Label Transparente
            label1.BackColor = System.Drawing.Color.Transparent;


        }

        private void Medico_CrearCita_Load(object sender, EventArgs e)//Cuando carga el Form
        {

            MostarCliente();
            labelMedicoNombreApellido(idMedico);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
