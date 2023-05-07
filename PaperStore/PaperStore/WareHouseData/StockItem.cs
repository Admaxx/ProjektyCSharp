using System;
using System.Collections.Generic;

namespace PaperStore.WareHouseData;

public partial class StockItem
{
    public long Id { get; set; }

    public string ItemName { get; set; } = null!;
}
