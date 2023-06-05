using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperStoreModel.Models
{
    public class UserCredentialsModel
    {
        [EmailAddress(ErrorMessage = "To nie wygląda jak email...")]
        [Required(ErrorMessage = "Email jest wymagany!")]
        public string Email { get; set; } = null!;


        [MinLength(8, ErrorMessage = "Minimalna długość hasła to 8 znaków!")]
        [Required(ErrorMessage = "Hasło jest wymagane!")]
        public string Password { get; set; } = null!;
    }
}
