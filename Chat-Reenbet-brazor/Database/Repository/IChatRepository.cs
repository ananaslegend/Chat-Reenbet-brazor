using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.DB
{
    public interface IChatRepository : IRepository<Chat>
    {
        //public Task AddChat(Chat chat);

        public Task AddChatToDb(Chat chat);
    }
}