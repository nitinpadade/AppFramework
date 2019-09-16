using Microsoft.EntityFrameworkCore;

namespace Framework.Data
{
    public class FrameworkDataContext : DbContext
    {

        public FrameworkDataContext(DbContextOptions<FrameworkDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Role>().ToTable("Role");
            //modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=NGL010910;Initial Catalog=School;User ID=sa;Password=Password1;MultipleActiveResultSets=True;App=EntityFramework;");
        }
    }
}
