using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Regimen
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public bool habilitado { get; set; }
        public float precioBase { get; set; }

        public Regimen(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("regi_id"));
            this.descripcion = reader.GetString(reader.GetOrdinal("regi_descripcion"));

            try
            {
                this.habilitado = reader.GetString(reader.GetOrdinal("regi_habilitado")).Equals("1");
                this.precioBase = reader.GetFloat(reader.GetOrdinal("regi_precio_base"));
            }
            catch (Exception) { }
        }

        public override string ToString()
        {
            return descripcion;
        }
    }
}
