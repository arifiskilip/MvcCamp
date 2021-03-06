using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService : IRepositoryService<Contact>
    {
        string NumberOfContacts();
        List<Contact> GetListReadMessage();
        List<Contact> GetListUnreadMessage();
    }
}
