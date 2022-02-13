using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Productora.Extensions;
using Microsoft.Extensions.Logging;
using Productora.Services;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Productora
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string json = File.ReadAllText(Path.Combine(projectDirectory, @"Data\JSONFile\Productora_data.json"));



            var host = CreateHostBuilder(args).Build();


            await using (var scope = host.Services.CreateAsyncScope())
            {
                var bulkService = scope.ServiceProvider.GetRequiredService<IBulkDataService>();
                await bulkService.BulkData(json);
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                        .ConfigureAppConfiguration((hostContext, config) =>
                        {
                            config.AddJsonFile(Path.Combine(Path.Combine(hostContext.HostingEnvironment.ContentRootPath, "Configuration"), "settings.json"));
                            config.AddEnvironmentVariables();
                            if (args != null)
                                config.AddCommandLine(args);
                        })
                        .ConfigureServices((hostContext, services) =>
                        {
                            services.AddAutoMapper(typeof(Program));
                            services.AddApplicationServices(hostContext.Configuration);
                        })
                        .ConfigureLogging((hostContext, logging) =>
                        {
                            logging.AddConsole();
                        });
        }
    }
}
