using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel
{
    class Hotel
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Hotel(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("hote_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("hote_nombre"));
        }
    }
}
