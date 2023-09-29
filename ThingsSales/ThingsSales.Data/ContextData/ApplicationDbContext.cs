using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThingsSales.Model.Identity;

namespace ThingsSales.Data.ContextData
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
   
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
