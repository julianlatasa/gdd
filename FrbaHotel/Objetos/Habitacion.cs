using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Habitacion
    {
        public int numero { get; set; }
        public int piso { get; set; }
        public string vista { get; set; }
        public int tipo { get; set; }
        public string descripcion { get; set; }
        public bool habilitado { get; set; }

        public Habitacion(SqlDataReader reader)
        {
            this.numero = reader.GetInt32(reader.GetOrdinal("habi_numero"));
            this.piso = reader.GetInt32(reader.GetOrdinal("habi_piso"));
            this.vista = reader.GetString(reader.GetOrdinal("habi_vista"));
            this.tipo = reader.GetInt32(reader.GetOrdinal("habi_tipo"));
            this.habilitado = reader.GetString(reader.GetOrdinal("habi_habilitada")).Equals("1");
            try
            {
                this.descripcion = reader.GetString(reader.GetOrdinal("habi_descripcion"));
            }
            catch (Exception) { }
        }

        public override string ToString()
        {
            return String.Format("Nro: {0} Piso: {1}", numero, piso);
        }
    }
}
