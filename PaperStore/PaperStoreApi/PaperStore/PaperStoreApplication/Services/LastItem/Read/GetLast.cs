﻿using Autofac;
using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Read
{
    public class GetLast(Container _container) : IGetLast
    {
        IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));
        public CurrentStock LastItem()
            =>
            _conn.Resolve<IReadAllItems>()
            .GetAllItems(false).AsNoTracking()
            .AsQueryable()
            .OrderBy(item => item.InputData)
            .LastOrDefault(); //Will refactorize it soon
        
    }
}
