using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Hotel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string domicilio { get; set; }
        public int ciudad { get; set; }
        public int pais { get; set; }
        public int estrellas { get; set; }

        public Hotel() { nombre = ""; }

        public Hotel(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("hote_id"));
            this.nombre = reader.GetString(reader.GetOrdinal("hote_nombre"));

            try
            {
                this.email = reader.GetString(reader.GetOrdinal("hote_email"));
                this.telefono = reader.GetString(reader.GetOrdinal("hote_telefono"));
                this.domicilio = reader.GetString(reader.GetOrdinal("hote_domicilio"));
                this.ciudad = reader.GetInt32(reader.GetOrdinal("hote_ciudad"));
                this.pais = reader.GetInt32(reader.GetOrdinal("hote_pais"));
                this.estrellas = reader.GetInt32(reader.GetOrdinal("hote_estrellas"));
            }
            catch (Exception) { }
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
