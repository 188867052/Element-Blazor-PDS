using IssueManage.Pages.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.ServerRender
{
    public partial class DocsDbContext : IdentityDbContext<IdentityUser>
    {
        public DocsDbContext(DbContextOptions<DocsDbContext> options) : base(options)
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
