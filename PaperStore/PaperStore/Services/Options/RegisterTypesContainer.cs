using Autofac;

namespace PaperStore.Services.Options
{
    public class RegisterTypesContainer
    {
        public IContainer ResolveContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<MassRegistration>();

            return builder.Build();
        }



    }
}
