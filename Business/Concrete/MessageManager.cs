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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void Add(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(m=> m.Id == id);
        }

        public List<Message> GetListInbox(string email)
        {
            return _messageDal.GetAll(p => p.ReceiverMessage == email);
        }

        public List<Message> GetListSendbox(string email)
        {
            return _messageDal.GetAll(p => p.SenderMessage == email);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
