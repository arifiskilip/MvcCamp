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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public void Add(Content entity)
        {
            _contentDal.Add(entity);
        }

        public void Delete(Content entity)
        {
            _contentDal.Delete(entity);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(p => p.Id == id);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public void Update(Content entity)
        {
            _contentDal.Update(entity);
        }

        public List<Content> GetListById(int id)
        {
            return  _contentDal.GetAll(c => c.HeadingId == id);
        }
    }
}
