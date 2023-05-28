using Autofac;

namespace PaperStore.Services.OptionsForServices
{
    public interface IRegistrationContainer
    {
        IContainer RegistrationContainer(ContainerBuilder builder);
    }
}