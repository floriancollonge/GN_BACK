using Microsoft.EntityFrameworkCore;
using nursery.prospect.models;

namespace nursery.context
{
    public class MyDbContext : DbContext
     {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserDAO> Users { get; set; }
        public DbSet<ProspectDAO> Prospects { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
        }
     }
}