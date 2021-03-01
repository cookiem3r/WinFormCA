using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Extensions.Autofac.DependencyInjection;
using System.Windows.Forms;
using WinFormCA.Common.IOC;
using WinFormCA.Infrastructure.Common.Extensions;
using WinFormCA.Infrastructure.Common.IOC;
using WinFormCA.Persistence.Common.Extensions;
using WinFormCA.Persistence.IOC;
using WinFromCA.Application.Common.Extensions;
using WinFromCA.Application.Common.IOC;

namespace WinFormCA
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static void Main()
        {
            var host = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<MainForm>()
                .AddApplicationInjections()
                .AddInfrastructureInjections()
                .AddPersistenceInjections();
                
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
               

                //Registering Components in the Autofac ContainerBuilder
                builder.RegisterModule(new InfrastructureModule());
                builder.RegisterModule(new PersistenceModule());
                builder.RegisterModule(new ApplicationModule());
                builder.RegisterModule(new FormModule());
                builder.Register<ILogger>((c, p) =>
                {
                    var Logger = new LoggerConfiguration()
                                   .MinimumLevel.Debug()
                                   .WriteTo.Console()
                                   .WriteTo.File("logs/WinFormCAlog.txt", rollingInterval: RollingInterval.Day)
                                   .CreateLogger();
                    return Logger;
                }).SingleInstance();

                //builder.RegisterSerilog(new LoggerConfiguration()
                //.MinimumLevel.Debug()
                //.WriteTo.Console()
                //.WriteTo.File("logs/WinFormCAlog.txt", rollingInterval: RollingInterval.Day));
            
            })
            .UseConsoleLifetime()
            .Build();

            //Start the first Form
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var startingForm = services.GetRequiredService<MainForm>();
                Application.Run(startingForm);
            }
        }
    }
}
