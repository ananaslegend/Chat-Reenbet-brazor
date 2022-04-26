using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.DB.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Massage> Massages { get; set; }
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

