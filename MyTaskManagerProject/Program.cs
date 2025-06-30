using Microsoft.EntityFrameworkCore;
using MyTaskManagerProject.Data;
using MyTaskManagerProject.Services;
using MyTaskManagerProject.Services.Implementations;

namespace MyTaskManagerProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                string? connectionString = builder.Configuration.GetConnectionString("Default");
                if(connectionString == null)
                {
                    throw new MissingFieldException("Connection string is null!");
                }
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseSession();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
