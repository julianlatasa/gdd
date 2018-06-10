using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Nacionalidad
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Nacionalidad(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("naci_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("naci_nombre"));
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
