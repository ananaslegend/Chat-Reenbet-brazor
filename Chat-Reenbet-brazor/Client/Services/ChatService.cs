using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;
using System.Net.Http;
using System.Net.Http.Json;

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
        public List<Massage> Massages { get; set; } = new List<Massage>();

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
            //var result = await req.Content.ReadFromJsonAsync<>
            //HttpResponseMessage response;  
        }
    }
}