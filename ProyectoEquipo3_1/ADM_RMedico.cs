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
    public partial class ADM_RMedico : Form
    {
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos
        ComboBoxes boxes = new ComboBoxes();

        private void ADM_RMedico_Load(object sender, EventArgs e)
        {
            try{
                llenarcb(comboBox2, "Especialidad", "IDEspecialidad_Nombre");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            
        }

        public ADM_RMedico()
        {
            InitializeComponent();
            //LLenar Combobox Especialidad
            boxes.mostrarEspecialidades(comboBox2);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand altas = new SqlCommand("insert into Medico values(@ApellidoPaterno,@ApellidoMaterno,@Nombre,@Genero,@FechaNacimiento,@CorreoElectronico,@Contraseña,@IDEspecialidad_Nombre)", conn);

            
            altas.Parameters.AddWithValue("ApellidoPaterno", textBox2.Text);
            altas.Parameters.AddWithValue("ApellidoMaterno", textBox3.Text);
            altas.Parameters.AddWithValue("Nombre", textBox4.Text);
            altas.Parameters.AddWithValue("Genero", comboBox1.Text);
            altas.Parameters.AddWithValue("FechaNacimiento", textBox6.Text);
            altas.Parameters.AddWithValue("CorreoElectronico", textBox7.Text);
            altas.Parameters.AddWithValue("Contraseña", textBox8.Text);
            altas.Parameters.AddWithValue("IDEspecialidad_Nombre", comboBox2.Text);

            
            conn.Open();// se abre la conexion
            altas.ExecuteNonQuery();
            conn.Close();// se cierra la conexion
            MessageBox.Show("Se han guardado los datos");

                comboBox1.Text = null;
                //textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();          
                textBox4.Clear();          
                textBox6.Text = "YYYY-MM-DD";
                textBox7.Clear();          
                textBox8.Clear();
            
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void llenarcb(ComboBox cb, string nombre_tabla, string nombre_columna)
        {
            try
            {
                cb.Items.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from " + nombre_tabla, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr[nombre_columna].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Medico where CorreoElectronico='" + textBox7.Text + "'", conn);

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

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "YYYY-MM-DD") textBox6.Clear();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox6.Text)) { textBox6.Text = "YYYY-MM-DD"; };
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //panel
        }

        private void CReg_Click(object sender, EventArgs e)
        {

        }

    }
}
