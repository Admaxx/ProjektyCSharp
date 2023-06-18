﻿using Autofac;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Read
{
    public class GetLast(Container _container) : IGetLast
    {
        IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));
        public CurrentStock LastItem()
        {
            return _conn.Resolve<IReadAllItems>().GetAllItems(false).ToBlockingEnumerable().AsQueryable().LastOrDefault(); //Will refactorize it soon
        }
    }
}