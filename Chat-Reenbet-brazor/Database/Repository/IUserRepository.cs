using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.DB
{
    public interface IUserRepository : IRepository<User>
    {
        public User FindbyLogin(string login);
        public bool LoginUser(User user);
    }

    
}