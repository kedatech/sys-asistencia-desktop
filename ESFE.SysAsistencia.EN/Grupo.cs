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
    public class Grupo
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int Anio { get; set; }
        public int CarreraId { get; set; }
    }
}