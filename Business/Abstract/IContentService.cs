using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService : IRepositoryService<Content>
    {
        List<Content> GetListByHeadingId(int id);
        List<Content> GetListByWriterId(int id);

        List<Content> GetAllSearch(string p);
    }
}
