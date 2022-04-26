using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Chat_Reenbet_brazor.Models
{
    public class User //: IdentityUser
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Chat>? UserChats { get; set; }
        
    }
}