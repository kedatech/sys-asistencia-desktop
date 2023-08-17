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
    public class Asistencia
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public int CriterioId { get; set; }
        public int NomenclaturaId { get; set; }
    }
}