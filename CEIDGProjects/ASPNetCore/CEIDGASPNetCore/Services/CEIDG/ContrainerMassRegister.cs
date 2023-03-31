using Autofac;
using CEIDGASPNetCore.Services.CEIDG.Abstract;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using CEIDGASPNetCore.Services.CEIDG.Interfaces.Abstract;
using CEIDGREGON;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class ContrainerMassRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetInsertValues>().As<IValuesInsert>().WithParameter("gus", new ShowRaportValues(new GetRequests(), new GetFirstNonEmptyValue()));
            builder.RegisterType<FormatOptions>().As<IConvertToJson>();
            builder.RegisterType<ConvertDocOnFormat>();
        }
    }
}
