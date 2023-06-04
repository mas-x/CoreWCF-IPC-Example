using CoreWCF.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreWCFIPCExample.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                IWebHost host = CreateWebHostBuilder().Build();
                host.Run();
            });

            Console.WriteLine("Server started... Press any key to exit.");
            Console.ReadKey();
        }

        public static IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder()
                          .UseNetNamedPipe(options =>
                          {
                              options.Listen(new Uri("net.pipe://localhost/"));
                          })
                       .UseStartup<Startup>();
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices();
            services.AddSingleton<CalculatorService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseServiceModel(builder =>
            {
                builder.AddService<CalculatorService>();
                builder.AddServiceEndpoint<CalculatorService, ICalculatorDuplex>(new CoreWCF.NetNamedPipeBinding(), "PipedService");
            });
        }
    }
}