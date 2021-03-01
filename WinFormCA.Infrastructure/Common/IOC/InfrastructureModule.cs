
using Autofac;
using WinFormCA.Infrastructure.Common.IOC.Modules;

namespace WinFormCA.Infrastructure.Common.IOC
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DateTimeServiceModule());

            base.Load(builder);
        }
    }
}
