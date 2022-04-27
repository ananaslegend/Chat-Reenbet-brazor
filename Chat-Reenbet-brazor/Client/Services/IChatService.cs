using System.Collections.Generic;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.Client.Services
{
    public interface IChatService
    {
        public List<User> Users { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Massage> Massages { get; set; }

        public Task GetAllUsers();
        public Task RegistrateUser(User user);
         public Task<bool> Login(User user);
    }
}