using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class LineaFactura
    {
        public int nro { get; set; }
        public string fecha { get; set; }
        public int total { get; set; }
        public string descripcion { get; set; }
        public int monto { get; set; }
        public int cantidad { get; set; }

        public LineaFactura(SqlDataReader reader)
        {
            this.nro = reader.GetInt32(reader.GetOrdinal("fact_numero"));
            this.total = reader.GetInt32(reader.GetOrdinal("fact_total"));
            this.monto = reader.GetInt32(reader.GetOrdinal("fact_line_monto"));
            this.cantidad = reader.GetInt32(reader.GetOrdinal("fact_line_cantidad"));
            this.fecha = ConvertFecha.fechaBdAVs(reader.GetString(reader.GetOrdinal("fact_fecha")));
            this.descripcion = reader.GetString(reader.GetOrdinal("fact_line_descripcion"));
        }

        public override string ToString()
        {
            return String.Format("{0} - USD {1} x {2}", descripcion, monto, cantidad);
        }
    }
}
