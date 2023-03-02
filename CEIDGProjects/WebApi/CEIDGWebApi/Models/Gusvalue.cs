using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CEIDGWebApi.Models;

public partial class Gusvalue
{
    [Key]
    public long Id { get; set; }

    public string Xmlvalues { get; set; } = null!;

    public DateTime ImportDate { get; set; }

    public byte RaportType { get; set; }
}
