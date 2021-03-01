using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Windows.Forms;
using Telerik.WinControls.UI;
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
                services.AddScoped<Form1>()
                .AddApplicationInjections()
                .AddInfrastructureInjections()
                .AddPersistenceInjections();
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
             

                //Register All Forms
                var assembly = Assembly.GetExecutingAssembly();
                builder.RegisterAssemblyTypes(assembly)
                    .AssignableTo<Form>();

                //Register All RadForms
                builder.RegisterAssemblyTypes(assembly)
                    .AssignableTo<RadForm>();

                // registering services in the Autofac ContainerBuilder
                builder.RegisterModule(new InfrastructureModule());
                builder.RegisterModule(new PersistenceModule());
                builder.RegisterModule(new ApplicationModule());

            })
            .UseConsoleLifetime()
            .Build();

            //Start the first Form
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var form1 = services.GetRequiredService<Form1>();
                Application.Run(form1);
            }


        }
    }
}
