﻿using Autofac;
using CEIDGASPNetCore.Controllers;
using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Services.CEIDG.Abstract;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using CEIDGASPNetCore.Services.CEIDG.Interfaces.Abstract;
using CEIDGREGON;
using Microsoft.AspNetCore.Mvc;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class ContrainerMassRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<GetInsertValues>().As<IValuesInsert>().WithParameter("gus", new ShowRaportValues(new GetRequests(), new GetFirstNonEmptyValue()));

            builder.RegisterType<ConvertDocOnFormat>().As<FormatOptions>();
            builder.RegisterType<ProgramGeneralData>();

            builder.RegisterType<CeidgregonContext>();
            builder.RegisterType<CEIDGController>();
        }
    }
}
