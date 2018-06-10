using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel
{
    public class Rol
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Rol(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("rol_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("rol_nombre"));
        }
    }
}
