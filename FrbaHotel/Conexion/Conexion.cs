using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public static class Conexion
    {
        public static String usuario { get; set; }
        public static int hotel { get; set; }
        public static int rol { get; set; }
        public static string rolNombre { get; set; }
        private static SqlConnection sqlConnection;

        public static SqlConnection getSqlConnection()
        {
            if(sqlConnection == null)
                sqlConnection = new SqlConnection(Properties.Settings.Default.Conection);

            return sqlConnection;
        }
    }
}
