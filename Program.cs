using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ERP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*.localhost:4369", "https://*.localhost:4369");
                });
    }
}
