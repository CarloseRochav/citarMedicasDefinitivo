using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;
using ProyectoEquipo3_1.Connection;

namespace ProyectoEquipo3_1.comboBoxes
{
    class ComboBoxes
    {
        static Conexion conexion = new Conexion();
        SqlConnection conn = conexion.getConnection();//Conexion a la base de datos
        //static string conexion2 = "Data Source=localhost; Initial Catalog=CitasMedicas2; integrated security=true";
        DataSet dset;

        //Este es el bueno
        public void MostrarCliente(ref DataTable dt) { //Mostrar clientes
           
            conn.Open();
             SqlDataAdapter da = new SqlDataAdapter("select IdPaciente, Nombre from Paciente", conn);//Consulta de los valores
            da.Fill(dt);//Le pasamos la tabla recibida
            conn.Close();

        }
        public void MostrarMedicos(ref DataTable dt)
        {
            conexion.AbrirConexion();
            SqlDataAdapter da = new SqlDataAdapter("SELECT IdMedico, Nombre FROM MEDICO",conn);
            da.Fill(dt);
            conexion.CerrarConexion();
        }
        
        public void mostraridPacientes(ComboBox comboBox)//Mostar datos de una tabla en un combo box
        {
            //string consulta = "SELECT IdPaciente, Nombre FROM PACIENTE ";
            //SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion2);//Consulta con los datos que queremos recoger
            ////SqlDataReader reader = new SqlDataReader(consulta,conexion2);
            //dset = new DataSet();
            //DataTableMapping mapping = adapter.TableMappings.Add("Table", "PACIENTE");//Referencia a un objeto tabla y el nombre de la tabla
            //adapter.Fill(dset);
            //this.comboBox1.DataSource = dset.DefaultViewManager;//dataViewManeger provides through the dataSet property
            //this.comboBox1.DisplayMember = "Paciente.IdPaciente";

            //string query = "select IdPaciente, Nombre from Paciente";
            //SqlDataAdapter da = new SqlDataAdapter(query, conn);
            //conn.Open();
            //DataSet ds = new DataSet();
            //da.Fill(ds, "Paciente");
            //comboBox.DisplayMember = "Nombre";//El valor que se mostrara //Nombre del valor
            //comboBox.ValueMember = "IdPaciente";//El valor que se enviara //Valor del registro            
            //comboBox.DataSource = ds.Tables["Paciente"];
        }

        public void mostrarEspecialidades(ComboBox CB)
        {
            string consulta = "SELECT * FROM ESPECIALIDAD ";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);//Consulta con los datos que queremos recoger
            //SqlDataReader reader = new SqlDataReader(consulta,conexion2);
            dset = new DataSet();
            DataTableMapping mapping = adapter.TableMappings.Add("Table", "ESPECIALIDAD");//Referencia a un objeto tabla y el nombre de la tabla
            adapter.Fill(dset);
            CB.DataSource = dset.DefaultViewManager;//dataViewManeger provides through the dataSet property
            CB.DisplayMember = "Especialidad.IDEspecialidad_Nombre";
        }

    }
}
