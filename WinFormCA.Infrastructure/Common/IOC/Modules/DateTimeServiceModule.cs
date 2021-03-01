using Autofac;
using WinFormCA.Infrastructure.Services;
using WinFromCA.Application.Interface;

namespace WinFormCA.Infrastructure.Common.IOC.Modules
{
    public class DateTimeServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeService>().As<IDateTimeService>();

            base.Load(builder);
        }
    }
}
