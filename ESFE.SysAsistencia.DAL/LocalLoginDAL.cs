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
    /// <summary>
    /// Clase para iniciar sesion de forma local con una Base de Datos
    /// Creador: Daniel Rodriguez
    /// </summary>
    public class LocalLoginDAL
    {
        public List<Auth> LocalLogin(List<string> parametros)
        {
            List<string> parametros_sp = new List<string> { "Correo", "Contrasenia" };

            return ComunBD.EjecutarLoginSP<Auth>("LocalLogin", parametros);
        }

        public bool GuardarLog(Auth auth)
        {
            List<string> parametros = new() { "Id","Nombre","Correo","Contrasenia","Telefono","CarreraId"};

            int valor = ComunBD.EjecutarSP("InsertarAuth", auth, parametros);
            return valor > 0;
        }


    }
}
