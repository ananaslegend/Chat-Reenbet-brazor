using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Chat_Reenbet_brazor.Models;

namespace Chat_Reenbet_brazor.DB.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {

        

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        
    }
}

