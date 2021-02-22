using Core;
using Core.Country.Queries;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TemplateJob
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            await host.StartAsync();
            await Task.Delay(1000);

            // Application code should start here.
            Console.WriteLine("Countries list:");
            Console.WriteLine();
            Console.WriteLine("[ID]- Name");
            await GetAllCountriesAsync(host.Services);

            // After this line, the code will not be executed
            await host.StopAsync();
        }

        private static async Task GetAllCountriesAsync(IServiceProvider services)
        {
            var mediator = services.GetRequiredService<IMediator>();

            var countries = await mediator.Send(new GetAllCountriesQuery());

            foreach (var country in countries)
            {
                Console.WriteLine($"[{country.Id}]- {country.Name}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    var env = hostingContext.HostingEnvironment;

                    configuration
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    var configurationRoot = configuration.Build();
                    ServiceCollectionExtension.Configuration = configurationRoot;
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                    logging.AddConsole();
                })
                .ConfigureServices((_, services) =>
                    services.AddMediatR(typeof(Program), typeof(CoreAssemblies))
                    .RegisterInfrastructureDependencies());

            return host;
        }
    }
}
