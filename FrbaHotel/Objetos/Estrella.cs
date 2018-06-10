using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Estrella
    {
        public int numero { get; set; }
        public string recargo { get; set; }

        public Estrella(SqlDataReader reader)
        {
            this.numero = reader.GetInt32(reader.GetOrdinal("estr_numero"));
            this.recargo = reader.GetString(reader.GetOrdinal("estr_recargo"));
        }

        public override string ToString()
        {
            return numero.ToString();
        }
    }
}
