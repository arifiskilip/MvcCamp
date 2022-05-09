using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILoginService : IRepositoryService<Admin>
    {
       
    }
}
