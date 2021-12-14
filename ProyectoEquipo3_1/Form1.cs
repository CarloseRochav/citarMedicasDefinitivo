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
    public partial class Form1 : Form
    {
        SqlConnection Conexion = new SqlConnection(@"Data Source=DESKTOP-K7L73JK; Initial Catalog=CitasMedicas3; integrated security=true");

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form ADM_RClientes = new ADM_RClientes();
            ADM_RClientes.Show();
            Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form Inicio = new Inicio();
            Inicio.Show();
            Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form ADM_RMedico = new ADM_RMedico();
            ADM_RMedico.Show();
            Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form ADM_REspecialidad = new ADM_REspecialidad();
            ADM_REspecialidad.Show();
            Visible = false;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form ADM_RHorarioMedicos = new ADM_RHorarioMedicos();
            ADM_RHorarioMedicos.Show();
            Visible = false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form ADM_Citas = new ADM_Citas();
            ADM_Citas.Show();
            Visible = false;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            //When we are running a winform application & need to exit or close ENTIRE APPLICATION
            //Cerrar APP
            System.Windows.Forms.Application.Exit();
        }
    }
}
