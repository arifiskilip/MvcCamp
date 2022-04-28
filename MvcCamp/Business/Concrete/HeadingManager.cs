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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        public void Add(Heading entity)
        {
            _headingDal.Add(entity);
        }

        public void Delete(Heading entity) //statu control
        {
            _headingDal.Update(entity);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(p => p.Id == id);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }

        public void Update(Heading entity)
        {
            _headingDal.Update(entity);
        }

        public int HowMonyCategoriesOfSoftware()
        {
            return _headingDal.HowMonyCategoriesOfSoftware();
        }

        public string CategoryNameWithMostTitles()
        {
            return _headingDal.CategoryNameWithMostTitles();
        }

        public List<HeadingDetailDto> HeadingDetails()
        {
            return _headingDal.HeadingDetails();
        }

        public List<Heading> GetAllHeadingStatus(bool statu)
        {
            return _headingDal.GetAll(h=> h.Statu== statu);
        }
    }
}
