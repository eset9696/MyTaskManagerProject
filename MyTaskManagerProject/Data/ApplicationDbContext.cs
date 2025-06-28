using Microsoft.EntityFrameworkCore;

namespace MyTaskManagerProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
    }
}
