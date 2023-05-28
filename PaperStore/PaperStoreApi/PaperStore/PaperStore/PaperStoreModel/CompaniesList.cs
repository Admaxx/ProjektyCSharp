using System;
using System.Collections.Generic;

namespace PaperStore.PaperStoreModel;

public partial class CompaniesList
{
    public long Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public bool? IsArchive { get; set; }

    public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();
}
