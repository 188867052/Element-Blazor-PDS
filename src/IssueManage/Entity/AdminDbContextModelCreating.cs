using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IssueManage
{
    public partial class AdminDbContext : IdentityDbContext<IdentityUser>
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RoleResource>(e =>
            {
                e.HasKey(x => new
                {
                    x.ResourceId,
                    x.RoleId
                });
            });

            builder.Entity<Issue>(e =>
            {
                e.HasKey(x => new
                {
                    x.Id,
                });
            });

            builder.Entity<Customer>(e =>
            {
                e.HasKey(x => new
                {
                    x.Id,
                });
            });

            builder.Entity<Product>(e =>
            {
                e.HasKey(x => new
                {
                    x.Id,
                });
            });

            builder.Entity<Meeting>(e =>
            {
                e.HasKey(x => new
                {
                    x.Id,
                });
            });
        }
    }
}
