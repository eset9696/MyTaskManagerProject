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

            builder.Services.AddScoped<ITaskService, TaskService>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute("default", "{controller=Task}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
