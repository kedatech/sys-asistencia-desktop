using ESFE.SysAsistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.SysAsistencia.BL
{
    public class RfidBL
    {
        RfidDAL rfidDAL = new RfidDAL();

        public async Task<bool> PostUid(string uid, int estudianteId)
        {
           return await rfidDAL.PostUid(uid, estudianteId);
        }
    }
}
