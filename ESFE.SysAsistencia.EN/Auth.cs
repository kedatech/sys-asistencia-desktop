using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.SysAsistencia.EN
{
    public class Auth
    {
        public int id { get; set; }
        public string nombre { get; set;}
        public string correo { get; set; }
        public string contrasenia { get; set; }
        public string telefono { get; set; }
        public int carreraId { get; set; }
    }
}