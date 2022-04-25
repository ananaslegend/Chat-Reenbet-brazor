using System;

namespace Chat_Reenbet_brazor.Models
{
    public class Massage
    {
        public Guid Id { get; set; }
        public User Author { get; set; }
        public IChat Chat { get; set; }
        public DateTime Date { get; set; }
        public string Data { get; set; }    
    }
}