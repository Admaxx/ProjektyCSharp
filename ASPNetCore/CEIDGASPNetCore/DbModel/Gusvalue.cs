using System;
using System.Collections.Generic;

namespace CEIDGASPNetCore.DbModel;

public partial class Gusvalue
{
    public long Id { get; set; }

    public string Xmlvalues { get; set; } = null!;

    public DateTime? ImportDate { get; set; }

    public byte RaportType { get; set; }
}
