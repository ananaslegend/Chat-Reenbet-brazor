using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Chat_Reenbet_brazor.Models
{
    public class User : IdentityUser
    {
        public ICollection<Chat> UserChats { get; set; }
    }
}