using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel
{
    public static class ConvertFecha
    {
        public static string fechaBdAVs(DateTime fecha)
        {
            if (fecha.Year < 1800)
                throw new Exception();

            return fecha.ToString("dd/MM/yyyy");
        }
        public static string fechaVsABd(string fecha)
        {
            return DateTime.ParseExact(fecha, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
        }
    }
}
