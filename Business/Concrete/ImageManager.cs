using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _ımageDal;
        public ImageManager(IImageDal ımageDal)
        {
            _ımageDal = ımageDal;
        }
        public void Add(Image entity)
        {
            _ımageDal.Add(entity);
        }

        public void Delete(Image entity)
        {
            _ımageDal.Delete(entity);
        }

        public List<Image> GetAll()
        {
            return _ımageDal.GetAll();

        }

        public Image GetById(int id)
        {
            return _ımageDal.Get(x=> x.Id==id);
        }

        public void Update(Image entity)
        {
             _ımageDal.Update(entity);
        }
    }
}
