using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IRepositoryDal<Category>
    {
        int NumberOfCategories();
        int DifferenceBetweenStatus();
    }
}
