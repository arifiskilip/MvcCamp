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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void Add(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void Delete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(p => p.Id == id);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public void Update(Writer entity)
        {
            _writerDal.Update(entity);
        }

        public int NameStartingWithA()
        {
           return _writerDal.NameStartingWithA();
        }

        public string NumberOfWriters()
        {
            return _writerDal.GetAll().Count().ToString();
        }

        public List<WriterDto> GetWriterListDto()
        {
            return _writerDal.GetWriterListDto();
        }
    }
}
