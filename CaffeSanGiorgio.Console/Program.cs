using CaffeSanGiorgio.Application;
using CaffeSanGiorgio.Application.Manager.Interface;
using CaffeSanGiorgio.Infrastructure;
using CaffeSanGiorgio.Infrastructure.Manager;
using CaffeSanGiorgio.Infrastructure.Persistence;
using CaffeSanGiorgio.Infrastructure.Persistence.DbSeed;
using CaffeSanGiorgio.Presentation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CaffeSanGiorgio
{
    class Program()
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            InitializeDatabase(host);

            Console.WriteLine("App Ready to perform..::");

            var manager = new SanGiorgioManager(host.Services.GetService<IMediator>());
            await Ui.Interface(manager);
            await host.RunAsync();
        }

        private static void InitializeDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<SanGiorgioContext>();
                var seedResult = DbSeed.Initialize(context);

                Console.WriteLine($"Database Seeding Result: {seedResult}");
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                    configuration.AddEnvironmentVariables();
                    configuration.AddCommandLine(args);
                })
                .ConfigureServices((context, services) =>
                {
                    // AddING my Application and Infrastructure layers services
                    services.AddApplication();
                    services.AddInfrastructure(context.Configuration);
                    services.AddScoped<ISanGiorgioManager, SanGiorgioManager>();
                });
    }
}