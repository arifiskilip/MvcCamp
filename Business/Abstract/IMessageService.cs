﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService : IRepositoryService<Message>
    {
        List<Message> GetListInbox(string email);    
        List<Message> GetListSendbox(string email);

    }
}
