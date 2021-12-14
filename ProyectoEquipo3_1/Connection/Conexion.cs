using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoEquipo3_1.Connection
{
    class Conexion
    {
        SqlConnection conn = new SqlConnection(@"Data Source=localhost; Initial Catalog=CitasMedicas2; integrated security=true;MultipleActiveResultSets=true");//Habilitar MARS

        public SqlConnection getConnection()
        {
            return conn;
        }

        //Metodo para abrir conexion
        public SqlConnection AbrirConexion()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;
        }

        //Metodo para cerrar conexion
        public SqlConnection CerrarConexion()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;
        }
    }
}
