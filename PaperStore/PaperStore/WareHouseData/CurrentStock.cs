using System;
using System.Collections.Generic;

namespace PaperStore.WareHouseData;

public partial class CurrentStock
{
    public long Id { get; set; }

    public long ProductName { get; set; }

    public long? AddtionalInfoId { get; set; }

    public DateTime? InputData { get; set; }

    public DateTime? UpdateData { get; set; }

    public bool? Archive { get; set; }

    public int Qty { get; set; }

    public StockAdditionalInfo? additionalInfos { get; set; }
    public StockItem? items { get; set; }
}
