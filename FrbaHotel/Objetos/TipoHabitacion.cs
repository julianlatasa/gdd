using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class TipoHabitacion
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }

        public TipoHabitacion(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("tipo_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("tipo_descripcion"));
            this.precio = reader.GetFloat(reader.GetOrdinal("tipo_precio"));
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
