using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Reenbet_brazor.DB
{
    public interface IDbUnit
    {
        public IUserRepository Users { get; }
        public IChatRepository Chats { get; }  
        public IMassageRepository Massages { get; }
        
        Task<int> CompleteAsync();
    }
}