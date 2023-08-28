using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ESFE.SysAsistencia.EN
{
    /// <summary>
    /// Clase para autenticación de usuario como Docente
    /// Creadora: Gabriela Herrera
    /// </summary>
    public class Auth
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set;}

        [JsonPropertyName("correo")]
        public string Correo { get; set; }

        [JsonPropertyName("contrasenia")]
        public string Contrasenia { get; set; }

        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }

        [JsonPropertyName("carreraId")]
        public int CarreraId { get; set; }
    }
}