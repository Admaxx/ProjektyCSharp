using Autofac;

namespace CEIDGASPNetCore.Services.CEIDG.Interfaces
{
    public interface IContainerResolve
    {
        IContainer ContainerResolve(ContainerBuilder builder);
    }
}
