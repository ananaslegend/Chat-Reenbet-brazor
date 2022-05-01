using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }

        // public ApplicationContext() { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
             
        // }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
            
        // }
        
    }
}

