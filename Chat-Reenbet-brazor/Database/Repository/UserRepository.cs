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
    }
}