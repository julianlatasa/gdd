using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Pais
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Pais() { nombre = ""; id = 0; }

        public Pais(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("pais_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("pais_nombre"));
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
