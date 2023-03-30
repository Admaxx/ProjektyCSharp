using Autofac;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class ContrainerResolve
    {

        public IContainer ContainerResolve(ContainerBuilder builder)
        {
            builder.RegisterModule<ContrainerMassRegister>();

            return builder.Build();
        }




    }
}
