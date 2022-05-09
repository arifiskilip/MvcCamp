using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(p => p.Id == id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public int NumberOfCategories()
        {
           return _categoryDal.NumberOfCategories();
        }

        public int DifferenceBetweenStatus()
        {
            return _categoryDal.DifferenceBetweenStatus();
        }

        public List<CategoryDto> GetCategoryListDto()
        {
            return _categoryDal.GetCategoryListDto();
        }
    }
}
