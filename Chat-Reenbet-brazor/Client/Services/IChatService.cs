using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;
using Microsoft.AspNetCore.SignalR.Client;


namespace Chat_Reenbet_brazor.Client.Services
{
    public interface IChatService
    {
        public List<User> Users { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Message> Messages { get; set; }

        public Task GetAllUsers();
        public Task RegistrateUser(User user);
        public Task<bool> Login(User user);
        public Task<User> GetUserbyLogin(string login);
        public Task CreateChat(Chat chat);
        public Task<List<ChatNav>> GetAllUserChats(string login);
        public Task JoinRoom(string connectionId, Guid chat);
        public Task<Chat> GetChatById(Guid id);
    }
}