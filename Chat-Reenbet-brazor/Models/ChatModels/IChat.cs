using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Reenbet_brazor.Models
{
    public interface IChat
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public ICollection<User> ChatUsers { get; set; }
        public ICollection<Massage> Massages { get; set; }
    }
}