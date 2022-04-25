using System;
using System.Collections.Generic;

namespace Chat_Reenbet_brazor.Models
{
    public class Chat : IChat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public ICollection<User> ChatUsers { get; set; }
        public ICollection<Massage> Massages { get; set; }
    }
}