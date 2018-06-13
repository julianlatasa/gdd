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
        public float precio { get; set; }
        public int habitaciones { get; set; }

        public Consulta(SqlDataReader reader)
        {
            this.idRegimen = reader.GetInt32(reader.GetOrdinal("regi_id"));
            this.descripcionRegimen = reader.GetString(reader.GetOrdinal("regi_descripcion"));
            this.precio = float.Parse(reader.GetDecimal(reader.GetOrdinal("precio")).ToString());
            this.habitaciones = reader.GetInt32(reader.GetOrdinal("habitaciones"));
        }

        public override string ToString()
        {
            return String.Format("Regimen: {0} Precio: {1} Habitaciones: {2}", descripcionRegimen, precio, habitaciones);
        }
    }
}
