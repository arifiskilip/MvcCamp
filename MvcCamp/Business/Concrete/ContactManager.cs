using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void Add(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(p => p.Id == id);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }

        public List<Contact> GetListReadMessage()
        {
            return _contactDal.GetAll(p => p.State == false);
        }

        public List<Contact> GetListUnreadMessage()
        {
            return _contactDal.GetAll(p => p.State == true);
        }

    }
}
