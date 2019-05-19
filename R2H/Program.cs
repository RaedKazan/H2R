using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace R2H
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                          .UseKestrel()
                          .ConfigureServices(services => services.AddAutofac())
                          .UseContentRoot(Directory.GetCurrentDirectory())
                          .UseIISIntegration()
                          .UseStartup<Startup>()
                          .Build();

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
