using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaperStore.WareHouseData;

public partial class CurrentStock
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Nazwa produktu nie może być pusta!")]
    public long ProductName { get; set; }

    public long? AddtionalInfoId { get; set; }

    public DateTime? InputData { get; set; }

    public DateTime? UpdateData { get; set; }

    public bool? Archive { get; set; }

    [Required(ErrorMessage = "Ilość nie może być pusta!")]
    [Range(1, int.MaxValue, ErrorMessage = "Wartość musi być większa od 0!")]
    public int Qty { get; set; }
}
