using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Comodidad
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Comodidad(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("como_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("como_descripcion"));
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
