using IssueManage.Pages.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.ServerRender
{
    public partial class DocsDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<RoleResource> RoleResources { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DrugStock> DrugStocks { get; set; }
        public DbSet<Score> Departments { get; set; }
    }
}
