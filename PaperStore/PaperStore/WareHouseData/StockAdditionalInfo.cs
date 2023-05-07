using System;
using System.Collections.Generic;

namespace PaperStore.WareHouseData;

public partial class StockAdditionalInfo
{
    public long Id { get; set; }

    public string AdditionalInfo { get; set; } = null!;
}
