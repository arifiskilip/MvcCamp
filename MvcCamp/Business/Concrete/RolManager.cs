using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RolManager : IRolService
    {
        IRolDal _rolDal;
        public RolManager(IRolDal rolDal)
        {
            _rolDal = rolDal;
        }
        public string[] GetRolesForUser(string username)
        {
           return _rolDal.GetRolesForUser(username);
        }
    }
}
