using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel
{
    class Funcionalidad
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Funcionalidad(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("func_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("func_nombre"));
        }
    }
}
