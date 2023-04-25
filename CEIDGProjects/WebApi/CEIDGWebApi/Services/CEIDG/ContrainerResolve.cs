using Autofac;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class ContrainerResolve : IContainerResolve
    {
        public IContainer ContainerResolve(ContainerBuilder builder)
        {
            builder.RegisterModule<ContrainerMassRegister>();

            return builder.Build();
        }
    }
}
