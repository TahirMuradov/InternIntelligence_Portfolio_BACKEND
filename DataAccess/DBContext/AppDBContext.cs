using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBContext
{
   public class AppDBContext: IdentityDbContext<User, Role, Guid>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Main> Mains { get; set; }
        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<Skill> Skills { get; set; }    
        public DbSet<Education> Educations { get; set; }
        public DbSet<CotactMe> CotactMes { get; set; }
        public DbSet<Project> Projects { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");

            builder.Entity<Role>().ToTable("Roles");
        }
    }
}
