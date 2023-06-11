using System.ComponentModel.DataAnnotations;

namespace PaperStoreModel.Models;

public class ModifyItemModel
{
    [Required]
    public int Qty { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string AdditionalDetail { get; set; }
}