using Esfe.SysAsistencia.DAL;
using Esfe.SysAsistencia.EN;
using ESFE.SysAsistencia.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.SysAsistencia.DAL
{
    public class LocalLoginDAL
    {
        public List<Auth> LocalLogin(List<string> parametros)
        {
            List<string> parametros_sp = new List<string> { "correo", "contrasenia" };

            return ComunBD.EjecutarLoginSP<Auth>("LocalLogin", parametros);
        }

        public bool GuardarLog(Auth auth)
        {
            List<string> parametros = new() { "id","nombre","correo","contrasenia","telefono","carreraId"};

            int valor = ComunBD.EjecutarSP("InsertarAuth", auth, parametros);
            return valor > 0;
        }


    }
}
