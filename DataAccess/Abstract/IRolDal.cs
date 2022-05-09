using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRolDal
    {
        string[] GetRolesForUser(string username);
    }
}
