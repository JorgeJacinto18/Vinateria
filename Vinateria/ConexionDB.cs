using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Vinateria
{
    class ConexionDB
    {

        public NpgsqlConnection conexion()
        {
            //Conexion a base de datos
            NpgsqlConnection con = new NpgsqlConnection(
           "Server = localhost; " +
           "User Id = empleado2;" +
           "Password = 1234567890; " +
           "Database = Vinateria;");
            //Abrir conexion
            con.Open();

            return con;
        }

        
        


    }
}
