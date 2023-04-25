using Autofac;
using CEIDGREGON;
using CEIDGWebApi.Controllers;
using CEIDGWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class ContrainerMassRegister : Module
    {//ProgramGeneralData
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CEIDGController>();

            builder.RegisterType<ConvertDocOnFormat>().As<FormatOptions>();
            builder.RegisterType<CeidgregonContext>();

            builder.RegisterType<ProgramGeneralData>();
            builder.RegisterType<ShowRaportValues>();
        }
    }
}
