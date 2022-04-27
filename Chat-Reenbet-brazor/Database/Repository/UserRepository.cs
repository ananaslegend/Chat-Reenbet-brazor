using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.DB
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context) 
        {

        }

        //downcast from generic 
        public ApplicationContext ApplicationContext 
        { 
            get { return _context as ApplicationContext; }
        }

        public User FindbyLogin(string login)
        {
            var user = ApplicationContext.Users
                        .Where(u => u.Login == login)
                        .First();

            return user;
        }

        public bool LoginUser(User user)
        {
            var item = ApplicationContext.Users
                        .Where(u => u.Login == user.Login)
                        .First();
            if (item.Password == user.Password)
            {
                return true;
            }
            
            return false;
        }
    }
}