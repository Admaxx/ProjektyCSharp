using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace worldWideDbModels;

public partial class CityDto
{
    [Range(0, int.MaxValue), Required]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long? Population { get; set; }

    public string Country { get; set; } = null!;

    public string Region { get; set; } = null!;
}
