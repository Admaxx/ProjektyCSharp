using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace worldWideDbModels;

public partial class Region
{
    public string Country { get; set; } = null!;
    [RegularExpression(@"^[a-zA-Z]+$"), MinLength(4), Required]
    public string Name { get; set; } = null!;
}
