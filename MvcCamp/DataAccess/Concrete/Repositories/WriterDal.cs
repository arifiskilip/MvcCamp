using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class WriterDal : RepositoryDal<Writer, DictionaryContext>, IWriterDal
    {
        public int NameStartingWithA()
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = from w in context.Writers
                             where w.FirstName.StartsWith("a")
                             select w;

                return result.Count();
            }
        }
    }
}
