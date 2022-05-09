using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class RolDal : IRolDal
    {
        public string[] GetRolesForUser(string username)
        {
            using(DictionaryContext context=new DictionaryContext())
            {
                var _username = context.Admins.FirstOrDefault(x => x.UserName == username);
                return new string[] { _username.Role };
            }
        }
    }
}
