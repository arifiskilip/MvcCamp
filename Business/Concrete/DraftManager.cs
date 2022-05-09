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
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;
        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }
        public void Add(Draft entity)
        {
            _draftDal.Add(entity);
        }

        public void Delete(Draft entity)
        {
            _draftDal.Delete(entity);
        }

        public List<Draft> GetAll()
        {
            return _draftDal.GetAll();
        }

        public Draft GetById(int id)
        {
            return _draftDal.Get(x=> x.Id==id);
        }

        public void Update(Draft entity)
        {
            _draftDal.Update(entity);
        }
    }
}
