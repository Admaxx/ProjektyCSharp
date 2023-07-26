using System;
using System.Collections.Generic;

namespace worldWideDbModels;

public partial class CityDto
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Population { get; set; }

    public string Country { get; set; } = null!;

    public string Region { get; set; } = null!;

    public virtual Region CountryNavigation { get; set; } = null!;
}
