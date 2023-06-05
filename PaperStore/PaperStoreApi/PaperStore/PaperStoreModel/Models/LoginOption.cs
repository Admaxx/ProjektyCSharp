using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaperStoreModel.Models;

public partial class LoginOption
{
    public long? Id { get; set; }

    [Required(ErrorMessage = "Email jest wymagany!")]
    [EmailAddress(ErrorMessage = "To nie wygląda jak email...")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Hasło jest wymagane!")]
    [MinLength(8, ErrorMessage = "Minimalna długość hasła to 8 znaków!")]
    public string Password { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? LastLogin { get; set; }
}
