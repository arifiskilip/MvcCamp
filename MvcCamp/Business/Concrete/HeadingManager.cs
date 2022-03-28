﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Delete(Heading entity)
        {
            _headingDal.Delete(entity);
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
    }
}
