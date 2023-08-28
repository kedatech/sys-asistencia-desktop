using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esfe.SysAsistencia.EN
{
    /// <summary>
    /// Clase que representa a un Docente
    /// Creador: Daniel Rodriguez
    /// </summary>
    public class Docente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public byte CarreraId { get; set; }
    }
}