using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esfe.SysAsistencia.EN
{
    /// <summary>
    /// Clase para tomar la asistencia de los estudiantes por medio del RFID
    /// Creadora: Khaterine Romualdo
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