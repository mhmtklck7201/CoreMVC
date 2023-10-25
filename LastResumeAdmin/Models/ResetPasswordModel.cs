using System.ComponentModel.DataAnnotations;

namespace LastResumeAdmin.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password alanı zorunludur  ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
