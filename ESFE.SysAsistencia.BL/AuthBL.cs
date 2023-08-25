using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.SysAsistencia.DAL;
using ESFE.SysAsistencia.EN;

namespace ESFE.SysAsistencia.BL
{
    public class AuthBL
    {
        AuthDAL auth = new AuthDAL();

        public async Task<Auth> Login(string correo, string contrasenia)
        {
            Auth value = await auth.Login(correo, contrasenia);
            return value;
        }
    }
}
