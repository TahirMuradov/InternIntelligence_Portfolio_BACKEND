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





        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");

            builder.Entity<Role>().ToTable("Roles");
        }
    }
}
