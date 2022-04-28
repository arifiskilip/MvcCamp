using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<HeadingDetailDto> HeadingDetails()
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = from h in context.Headings
                             join c in context.Categories
                             on h.CategoryId equals c.Id
                             join w in context.Writers
                             on h.WriterId equals w.Id
                             select new HeadingDetailDto
                             {
                                 Id = h.Id,
                                 CategoryName = c.Name,
                                 HeadingName = h.Name,
                                 WriterName = w.FirstName + " " + w.LastName
                             };
                return result.ToList();
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
