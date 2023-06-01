﻿using System;
using System.Collections.Generic;

namespace PaperStore.PaperStoreModel;

public partial class StockAdditionalInfo
{
    public long Id { get; set; }

    public string AdditionalInfo { get; set; } = null!;

    public virtual ICollection<CurrentStock> CurrentStocks { get; set; } = new List<CurrentStock>();
}