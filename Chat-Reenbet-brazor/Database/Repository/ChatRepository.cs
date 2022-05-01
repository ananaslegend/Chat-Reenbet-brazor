using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.DB
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        public ChatRepository(ApplicationContext context) : base(context) 
        {

        }

        public async Task AddChatToDb(Chat chat)
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

        // public async Task AddChat(Chat chat)
        // {
        //     await AddChatToDb(chat);

        //     foreach(var user in chat.ChatUsers)
        //     {
        //         var userAcc = ApplicationContext.Users.Where(u => u.Id == user.Id).FirstOrDefault();

        //         userAcc.UserChats.Add(chat);         
        //     }
        //     await ApplicationContext.SaveChangesAsync();       
        // }

        //downcast from generic 
        public ApplicationContext ApplicationContext 
        { 
            get { return _context as ApplicationContext; }
        }
    }
}