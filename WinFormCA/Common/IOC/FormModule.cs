using Autofac;
using System.Reflection;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace WinFormCA.Common.IOC
{
    public class FormModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register All Forms
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AssignableTo<Form>().SingleInstance();

            //Register All RadForms
            builder.RegisterAssemblyTypes(assembly)
                .AssignableTo<RadForm>();

            base.Load(builder);
        }
    }
}
