using Microsoft.EntityFrameworkCore;
using MyTaskManagerProject.Models.Domain;

namespace MyTaskManagerProject.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }
    }
}
