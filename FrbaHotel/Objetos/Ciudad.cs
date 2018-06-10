using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Ciudad
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Ciudad(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("ciud_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("ciud_nombre"));
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
