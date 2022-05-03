using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.DB
{
    public interface IMessageRepository : IRepository<Message>
    {
        public IList<Message> GetMessagePack(Guid chatId, int loaded);
    }
}