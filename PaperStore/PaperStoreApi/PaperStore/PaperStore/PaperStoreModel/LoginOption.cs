using System;
using System.Collections.Generic;

namespace PaperStore.PaperStoreModel;

public partial class LoginOption
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? LastLogin { get; set; }
}
