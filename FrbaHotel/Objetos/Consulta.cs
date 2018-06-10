using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Consulta
    {
        public int idRegimen { get; set; }
        public string descripcionRegimen { get; set; }
        public int precio { get; set; }
        public int habitaciones { get; set; }

        public Consulta(SqlDataReader reader)
        {
            this.idRegimen = reader.GetInt32(reader.GetOrdinal("regi_id"));
            this.descripcionRegimen = reader.GetString(reader.GetOrdinal("regi_descripcion"));
            this.precio = reader.GetInt32(reader.GetOrdinal("precio"));
            this.habitaciones = reader.GetInt32(reader.GetOrdinal("habitaciones"));
        }

        public override string ToString()
        {
            return String.Format("Regimen: {0} Precio: {1} Habitaciones: {2}", descripcionRegimen, precio, habitaciones);
        }
    }
}
