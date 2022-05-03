using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat_Reenbet_brazor.Client.Services
{
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;

        public ChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<User> Users { get ; set ; } = new List<User>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
        public List<Message> Messages { get; set; } = new List<Message>();

        public async Task GetAllUsers()
        {
           var result = await _httpClient.GetFromJsonAsync<List<User>>("api/Registration");
        }

        public async Task RegistrateUser(User user)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Registration", user);
        }

        public async Task<bool> Login(User user)
        {
            //var res = await result.Content.ReadFromJsonAsync<List<User>>();

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/Login", user);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;  
        }

        public async Task<User> GetUserbyLogin(string login)
        {
           var result = await _httpClient.GetFromJsonAsync<User>($"/api/Login/User/{login}");
            
            if(result != null)
            {
                return result;
            }

            throw new Exception("User not found");
        }

        public async Task CreateChat(Chat chat)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Chat/CreateChat", chat);
        }

        public async Task<List<ChatNav>> GetAllUserChats(string login)
        {
            List<ChatNav> result = await _httpClient.GetFromJsonAsync<List<ChatNav>>($"/api/Chat/GetAllUserChats/{login}");
            
           return result;            
        }

        public async Task JoinRoom(string connectionId, Guid chat)
        {            
            await _httpClient.GetFromJsonAsync<Object>($"api/Chat/JoinChat/{connectionId}/{chat}");

            System.Console.WriteLine("Connected to room");
        }

        public async Task<Chat> GetChatById(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<Chat>($"api/Chat/GetChatById/{id}");

            return result;
        }
    }
}