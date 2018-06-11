using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaHotel.Objetos
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string email { get; set; }
        public bool habilitado { get; set; }
        public int tipoDocumento { get; set; }
        public string nroDocumento { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string domicilio { get; set; }
        public string fechaDeNacimiento { get; set; }

        public Usuario(SqlDataReader reader)
        {
            this.usuario = reader.GetString(reader.GetOrdinal("usua_usuario"));
            this.email = reader.GetString(reader.GetOrdinal("usua_email"));
            this.habilitado = reader.GetString(reader.GetOrdinal("usua_habilitado")).Equals("1")?true:false;
            this.tipoDocumento = reader.GetInt32(reader.GetOrdinal("usua_tipo_doc"));
            this.nroDocumento = reader.GetString(reader.GetOrdinal("usua_numero_doc"));

            try
            {
                this.nombre = reader.GetString(reader.GetOrdinal("pers_nombre"));
                this.apellido = reader.GetString(reader.GetOrdinal("pers_apellido"));
                this.telefono = reader.GetString(reader.GetOrdinal("pers_telefono"));
                this.domicilio = reader.GetString(reader.GetOrdinal("pers_domicilio"));
                this.fechaDeNacimiento = ConvertFecha.fechaBdAVs(reader.GetString(reader.GetOrdinal("pers_fecha_nac")));
            }
            catch (Exception) { }
        }

        public override string ToString()
        {
            return usuario;
        }
    }
}
