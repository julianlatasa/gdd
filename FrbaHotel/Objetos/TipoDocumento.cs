using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel
{
    public class TipoDocumento
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public TipoDocumento(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("tipo_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("tipo_nombre"));
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
