using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.SysAsistencia.EN;
using ESFE.SysAsistencia.DAL;

namespace ESFE.SysAsistencia.BL
{
    public class LocalLoginBL
    {
        LocalLoginDAL localloginDal = new LocalLoginDAL();
        public List<Auth> Login(string email, string password)
        {
            List<string> p = new() { email, password };
            return localloginDal.LocalLogin(p);
        }

        public bool GuardarSesion(Auth auth)
        {
            return localloginDal.GuardarLog(auth);
        }
    }
}
