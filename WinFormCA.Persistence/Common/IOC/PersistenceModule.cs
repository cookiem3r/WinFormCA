

using Autofac;
using WinFormCA.Persistence.Common.IOC.Modules;

namespace WinFormCA.Persistence.IOC
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterModule(new DbContextModule());

            base.Load(builder);
        }
    }
}
