using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace worldWideDbModels;

public partial class City
{
    public long Id { get; set; }

    [RegularExpression(@"^[a-zA-Z]+$"), MinLength(4), Required]
    public string Name { get; set; } = null!;
    [Range(0, int.MaxValue), Required]
    public long Population { get; set; }
    [RegularExpression(@"^[a-zA-Z]+$"), MinLength(4), Required]
    public string Country { get; set; } = null!;
}
