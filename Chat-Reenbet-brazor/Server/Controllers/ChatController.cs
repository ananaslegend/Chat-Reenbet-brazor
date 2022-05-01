using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chat_Reenbet_brazor.DB;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;
using Microsoft.AspNetCore.SignalR;
using Chat_Reenbet_brazor.Server.Hubs;
using Microsoft.AspNetCore.Authorization;

namespace Chat_Reenbet_brazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChatController : ControllerBase
    {
        private readonly IDbUnit _dbUnit;
        private readonly IHubContext<ChatHub> _chatHub;

        public ChatController(IDbUnit dbUnit, IHubContext<ChatHub> chatHub)
        {
            _dbUnit = dbUnit;
            _chatHub = chatHub;
        }
        
        [HttpPost("[action]/{connectionId}/{chatName}")]
        public async Task<ActionResult> JoinChat(string connectionId, string chatName)
        {
            await _chatHub.Groups.AddToGroupAsync(connectionId, chatName);

            return Ok();
        }

        [HttpPost("[action]/{connectionId}/{chatName}")]
        public async Task<ActionResult> LeaveChat(string connectionId, string chatName)
        {
            await _chatHub.Groups.RemoveFromGroupAsync(connectionId, chatName);

            return Ok();
        }

        // public async Task<ActionResult> SendMessage(Guid chatId, Message message, string chatName)
        // {
        //     _dbUnit.Messages.Add(message);
        //     await _dbUnit.CompleteAsync();

        //     await _chatHub.Clients.Group(chatName)
        //         .SendAsync("ReceiveMessage", message);

        //     return Ok();
        // }

        [HttpPost("[action]/")]
        public async Task<ActionResult> CreateChat(Chat chat) 
        {
            //сюда бы мапер...
            Chat chatToAdd = new Chat()
            {
                Name = chat.Name,
                Type = chat.Type,
                Messages = new List<Message>(),
                ChatUsers = new List<User>()
            };
            // chatToAdd.Name = chat.Name;
            // chatToAdd.Type = chat.Type;
            // chatToAdd.Messages = new List<Message>();
            // chatToAdd.ChatUsers = new List<User>();

            foreach(var user in chat.ChatUsers)
            {
                chatToAdd.ChatUsers.Add(_dbUnit.Users.Find(u => u.Id == user.Id).FirstOrDefault());
            }

            _dbUnit.Chats.Add(chatToAdd);

            await _dbUnit.CompleteAsync();

            return Ok();
        }
    
        [HttpGet("[action]/{login}")]
        public ActionResult<List<ChatNav>> GetAllUserChats([FromRoute]string login)
        {
            var result = _dbUnit.Users.GetUserChats(login).ToList();

            if(result != null)
                return Ok(result);
            
            return NotFound(result);
        }
    }
    
}