﻿using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.ActualInventory.Options;

public class GetAdditionalInfo : IGetAdditionalInfo
{
    PaperWarehouseContext _context;
    public GetAdditionalInfo(PaperWarehouseContext conn)
        =>
        _context = conn ?? throw new ArgumentNullException(nameof(conn));


    public async Task<long?> ByName(string AdditionalInfoName)
    {
        try
        {
            return await _context.StockAdditionalInfos
            .AsNoTracking()
            .Where(item => item.AdditionalInfo.ToLower() == AdditionalInfoName.ToLower())
            .Select(item => item.Id)
            .FirstAsync();
        }
        catch (Exception) { }
        return null;
    }
}