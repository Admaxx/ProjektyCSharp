using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaperStore.WareHouseData
{
    public class LoginModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "To pole jest obowiązkowe!")]
        [EmailAddress(ErrorMessage = "To niewygląda jak Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "To pole jest obowiązkowe!")]
        [MinLength(8, ErrorMessage = "Hasło musi mieć przynajmniej 8 znaków!")]
        [MaxLength(20, ErrorMessage = "Hasło musi mieć najwyżej 20 znaków!")]
        public string Password { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
