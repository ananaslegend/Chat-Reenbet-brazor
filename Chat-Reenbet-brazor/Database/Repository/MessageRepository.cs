using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat_Reenbet_brazor.DB
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationContext context) : base(context) 
        {

        }

        public IList<Message> GetMessagePack(Guid chatId, int loaded)
        {
            var arr = ApplicationContext.Messages
                                            .Include(a => a.Author) 
                                            .Include(r => r.Reply)
                                            .Where(c => c.Chat.Id == chatId)
                                            .OrderByDescending(d => d.Date)
                                            .Skip(loaded)
                                            .Take(20);
                                                 
            var list = arr.ToList();
            list.Reverse();

            return list;
        }

         public async Task AddMessageToDb(Chat chat)
        {
            //chat.Messages = new List<Message>();

            Chat chatToAdd = new Chat();
            chatToAdd.Name = chat.Name;
            chatToAdd.Type = chat.Type;
            chatToAdd.Messages = new List<Message>();


            foreach(var user in chat.ChatUsers)
            {
                chatToAdd.ChatUsers.Add(ApplicationContext.Users.Where(u => u.Id == user.Id).FirstOrDefault());
            }

            ApplicationContext.Chats.Add(chatToAdd);

            await ApplicationContext.SaveChangesAsync();
        }

        //downcast from generic 
        public ApplicationContext ApplicationContext 
        { 
            get { return _context as ApplicationContext; }
        }
    }
}