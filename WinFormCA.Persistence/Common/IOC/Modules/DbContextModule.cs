using Autofac;


namespace WinFormCA.Persistence.Common.IOC.Modules
{
    public class DbContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<PersonDbContext>()
            //    .As<IPersonDbContext>();

            base.Load(builder);
        }
    }
}
