using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class HeadingDal : RepositoryDal<Heading, DictionaryContext>, IHeadingDal
    {
        public string CategoryNameWithMostTitles()
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = from h in context.Headings
                             orderby h.CategoryId
                             group h by h.CategoryId into heading
                             select new { category = heading.Key, mostCategory = heading.Count() };
                var x = result.Max(p => p.mostCategory);
                var x2 = result.SingleOrDefault(p => p.mostCategory == x);
                var categoryName = context.Categories.SingleOrDefault(c => c.Id == x2.category).Name;
                return categoryName;
            }
        }

        public int HowMonyCategoriesOfSoftware()
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = from h in context.Headings
                             where
                             h.CategoryId == 6
                             select h;
                return result.Count();
            }
        }
      
    }
}
