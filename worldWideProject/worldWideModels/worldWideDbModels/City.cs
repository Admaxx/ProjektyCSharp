using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace worldWideDbModels;

public partial class City
{
    public long Id { get; set; }

    [RegularExpression(@"^[a-zA-Z]+$"), MinLength(4), Required]//[Required, MinLength(4)]
    public string Name { get; set; } = null!;

    public long Population { get; set; }

    public string Country { get; set; } = null!;
}
