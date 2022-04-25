using System.Collections;

namespace Chat_Reenbet_brazor.Models
{
    public class ChatRoom : Chat
    {
        public ICollection Admins { get; set; }
    }
}