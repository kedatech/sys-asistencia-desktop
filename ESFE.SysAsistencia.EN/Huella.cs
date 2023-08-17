using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esfe.SysAsistencia.EN
{
    /// <summary>
    /// Clase que representa a un Estudiante.
    /// </summary>
    public class Huella
    {
        public int Id { get; set; }
        public byte[] Muestra { get; set; }
        public int RolId { get; set; }
        public int DocenteId { get; set; }
        public int EstudianteId { get; set; }
    }
}