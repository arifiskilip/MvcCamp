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
    public class CategoryDal : RepositoryDal<Category, DictionaryContext>, ICategoryDal
    {
        public int NumberOfCategories()
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = from p in context.Categories select p;
                int number = result.Count();
                return number - 1;
            }
        }
        public int DifferenceBetweenStatus()
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = from c in context.Categories
                             orderby c.Status
                             group c by c.Status into order
                             select new { category = order.Key, mostCategory = order.Count() };
                var max = result.Max(c => c.mostCategory);
                var min = result.Min(c => c.mostCategory);

                return max - min;
            }
        }

        public List<CategoryDto> GetCategoryListDto()
        {
            using (DictionaryContext context = new DictionaryContext())
            {
                var result = from x in context.Categories
                             select new CategoryDto
                             {
                                 CategoryName = x.Name,
                                 CategoryCount = context.Headings.Where(h => h.CategoryId == x.Id).Count()
                             };
                return result.ToList();
            }
        }
    }
}
