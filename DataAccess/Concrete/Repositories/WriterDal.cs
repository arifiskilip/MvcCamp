using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public List<WriterDto> GetWriterListDto()
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = from x in context.Writers
                             select new WriterDto
                             {
                                 WriterName = x.FirstName,
                                 WriteContentCount = context.Contents.Where(c => c.WriterId == x.Id).Count()
                             };
                return result.ToList();
            }
        }
    }
}
