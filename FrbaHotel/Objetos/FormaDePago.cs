using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class FormaDePago
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public FormaDePago(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("form_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("form_nombre"));
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
