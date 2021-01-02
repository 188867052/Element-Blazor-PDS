using IssueManage.Pages.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.ServerRender
{
    public partial class DocsDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<RoleResource> RoleResources { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
