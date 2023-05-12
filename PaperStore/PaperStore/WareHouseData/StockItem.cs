using System;
using System.Collections.Generic;

namespace PaperStore.WareHouseData;

public partial class StockItem
{
    public long Id { get; set; }

    public string ItemName { get; set; } = null!;

    public long? CompanyId { get; set; }

    public virtual CompaniesList Company { get; set; } = null!;

    public virtual ICollection<CurrentStock> CurrentStocks { get; set; } = new List<CurrentStock>();
}
