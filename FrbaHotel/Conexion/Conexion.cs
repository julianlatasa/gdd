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
        private static SqlConnection sqlConnection;

        public static SqlConnection getSqlConnection()
        {
            if(sqlConnection == null)
                sqlConnection = new SqlConnection(Properties.Settings.Default.Conection);

            return sqlConnection;
        }
    }
}
