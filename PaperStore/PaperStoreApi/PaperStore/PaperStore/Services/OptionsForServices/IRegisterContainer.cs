using Autofac;

namespace PaperStore.Services.OptionsForServices
{
    public interface IRegisterContainer
    {
        IContainer RegistrationContainer(ContainerBuilder builder);
    }
}