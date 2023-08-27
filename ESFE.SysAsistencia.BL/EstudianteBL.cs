using Esfe.SysAsistencia.EN;
using ESFE.SysAsistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.SysAsistencia.BL
{
    public class EstudianteBL
    {
        EstudianteDAL estudianteDAL = new EstudianteDAL();
        public async Task<Estudiante[]> GetEstudiantes(int idDocente)
        {
            var estudiantes = await estudianteDAL.GetEstudiantes(idDocente);
            return estudiantes;
        }
    }
}
