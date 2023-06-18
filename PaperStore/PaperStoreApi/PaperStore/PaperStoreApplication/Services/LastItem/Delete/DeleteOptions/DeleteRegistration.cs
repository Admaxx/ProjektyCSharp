﻿using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.OptionsForServices;

namespace PaperStoreApplication.Services.LastItem.Delete.DeleteOptions;

public class DeleteRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DeleteItem>().As<IDeleteItem>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
    }
}