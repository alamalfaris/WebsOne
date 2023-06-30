using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace WebsOne.Api.Databases
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {
            
        }
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Users", "dbo");
            });
        }
    }
}
