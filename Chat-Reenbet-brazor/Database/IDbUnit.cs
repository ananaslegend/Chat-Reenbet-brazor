using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Reenbet_brazor.DB
{
    public interface IDbUnit : IDisposable
    {
        public IUserRepository Users { get; }
        public IChatRepository Chats { get; }  
        public IMessageRepository Messages { get; }
        Task<int> CompleteAsync();
    }
}