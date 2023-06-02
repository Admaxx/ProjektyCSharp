using System.ComponentModel.DataAnnotations;

namespace PaperStore.Services.OptionsForServices;

public class ModifyItemModel
{
    [Required]
    public int Qty { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public string CompanyName { get; set; }
    public string? AdditionalDetail { get; set; } = null;
}