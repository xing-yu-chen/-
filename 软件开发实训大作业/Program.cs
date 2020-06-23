using ERestaurant.DAO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ERestaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var web = CreateHostBuilder(args).Build();

            using (var scope = web.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MyContext>();
                context.Database.EnsureCreated();

                context.Database.Migrate();
            }

            web.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
