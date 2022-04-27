using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Reenbet_brazor.DB
{
    public class DbUnit : IDbUnit
    {
        private readonly ApplicationContext _context;
        public DbUnit(ApplicationContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Chats = new ChatRepository(_context);
            Massages = new MassageRepository(_context);
        }
        public IUserRepository Users { get; private set; }

        public IChatRepository Chats { get; private set; }

        public IMassageRepository Massages { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}