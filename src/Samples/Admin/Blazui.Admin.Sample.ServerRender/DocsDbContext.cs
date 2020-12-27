﻿using Element.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.ServerRender
{
    public class DocsDbContext : IdentityDbContext<IdentityUser>
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
        }

        public DbSet<RoleResource> RoleResources { get; set; }
        public DbSet<Issue> Issues { get; set; }
    }
}
