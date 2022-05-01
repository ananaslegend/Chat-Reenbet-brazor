using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;
using Microsoft.EntityFrameworkCore;

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
                        .FirstOrDefault();

            return user;
        }

        public ICollection<ChatNav> GetUserChats(string login)
        {
            var items = ApplicationContext.Users
                        .Include(u => u.UserChats)
                        .FirstOrDefault(u => u.Login == login)
                        .UserChats;

            ICollection<ChatNav> result = new List<ChatNav>();
            foreach(var item in items)
            {
                result.Add(new ChatNav(){
                    Id = item.Id,
                    Name = item.Name,
                    Type = item.Type
                });
            }

            return result;
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