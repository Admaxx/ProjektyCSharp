﻿using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Delete
{
    public interface IRemoveItem
    {
        Task<string> Item(long Id);
    }
}