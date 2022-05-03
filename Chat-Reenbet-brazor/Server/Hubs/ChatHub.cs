using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Chat_Reenbet_brazor.DB;
using System;
using System.Linq;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.Server.Hubs
{

    public class ChatHub : Hub
    {

        private readonly IDbUnit _dbUnit;
       
        public ChatHub(IDbUnit dbUnit)
        {
            _dbUnit = dbUnit;
        }
        public async Task JoinRoom(string chatGuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatGuid);
        }

        public async Task LeaveRoom(string chatGuid)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatGuid);
        }

        public async Task SendMessage(string msg, string author, string chatGuid)
        {
            Message message = new Message()
            {
                Chat = _dbUnit.Chats.Find(i => i.Id == Guid.Parse(chatGuid)).FirstOrDefault(), //!переробити
                Author = _dbUnit.Users.FindbyLogin(author), //!переробити
                Date = DateTime.Now,
                Reply = null,
                Data = msg
            };
            await Clients.Group(chatGuid).SendAsync("AddMessage", message);

            _dbUnit.Messages.Add(message);
            await _dbUnit.CompleteAsync();
        }

        public async Task ReplyMessage(string msg, string author, string chatGuid, Guid replyId)
        {
            Message message = new Message()
            {
                Chat = _dbUnit.Chats.Find(i => i.Id == Guid.Parse(chatGuid)).FirstOrDefault(), //!переробити
                Author = _dbUnit.Users.FindbyLogin(author), //!переробити
                Date = DateTime.Now,
                Reply = _dbUnit.Messages.Find(m => m.Id == replyId).FirstOrDefault(),
                Data = msg
            };

            _dbUnit.Messages.Add(message);
            await _dbUnit.CompleteAsync();

            await Clients.Group(chatGuid).SendAsync("AddReply", message);

            // _dbUnit.Messages.Add(message);
            // await _dbUnit.CompleteAsync();
        }

        public async Task EditMessage(Guid messageId, string data) 
        {
            var message = _dbUnit.Messages.Find(m => m.Id == messageId).FirstOrDefault();
            message.Data = data;

            await _dbUnit.CompleteAsync();
        }

        public async Task RemoveMessage(Guid messageId)
        {
            var message = _dbUnit.Messages.Find(m => m.Id == messageId).FirstOrDefault();
            _dbUnit.Messages.Remove(message);
            await _dbUnit.CompleteAsync();
        }

        public async Task GetMassagePack(Guid chatId, int loaded, string hubConnection)
        {
            var pack = _dbUnit.Messages.GetMessagePack(chatId, loaded);
            await Clients.Caller.SendAsync("AddMessagePack", pack);
        }        
    }
}