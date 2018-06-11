using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Cliente
    {
        public int id { get; set; }
        public int tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string domicilio { get; set; }
        public string fechaNacimiento { get; set; }
        public string localidad { get; set; }
        public int pais { get; set; }
        public int nacionalidad { get; set; }
        public bool habilitado { get; set; }

        public Cliente(SqlDataReader reader)
        {
            this.id = reader.GetInt32(reader.GetOrdinal("clie_id"));
            this.tipoDocumento = reader.GetInt32(reader.GetOrdinal("clie_tipo_doc"));
            this.numeroDocumento = reader.GetString(reader.GetOrdinal("clie_numero_doc"));
            this.nombre = reader.GetString(reader.GetOrdinal("clie_nombre"));
            this.apellido = reader.GetString(reader.GetOrdinal("clie_apellido"));
            this.email = reader.GetString(reader.GetOrdinal("clie_email"));
            this.telefono = reader.GetString(reader.GetOrdinal("clie_telefono"));
            this.domicilio = reader.GetString(reader.GetOrdinal("clie_domicilio"));
            //this.fechaNacimiento = ConvertFecha.fechaBdAVs(reader.GetDateTime(reader.GetOrdinal("clie_fecha_nac")).ToString());
            this.fechaNacimiento = reader.GetDateTime(reader.GetOrdinal("clie_fecha_nac")).ToString("dd/MM/yyyy");
            this.localidad = reader.GetString(reader.GetOrdinal("clie_localidad"));
            this.pais = reader.GetInt32(reader.GetOrdinal("clie_pais"));
            this.nacionalidad = reader.GetInt32(reader.GetOrdinal("clie_nacionalidad"));
            this.habilitado = reader.GetString(reader.GetOrdinal("clie_habilitado")).Equals("1");
        }

        public override string ToString()
        {
            return String.Format("Doc: {0} Apellido: {1} Nombre: {2}", numeroDocumento, apellido, nombre);
        }
    }
}
