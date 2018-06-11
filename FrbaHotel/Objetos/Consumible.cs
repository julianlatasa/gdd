using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Consumible
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Consumible(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("cons_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("cons_descripcion"));
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
