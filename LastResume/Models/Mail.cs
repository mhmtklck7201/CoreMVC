using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LastResume.Models
{
    public class Mail
    {

 


      
        [Required(ErrorMessage = "Your Email is mandatory.")]
        [MaxLength(45, ErrorMessage = "maximum 45 characters allowed")]
        [MinLength(10, ErrorMessage = "minimum 10 characters allowed")]
        public string MailFrom { get; set; }

        
        [Required(ErrorMessage = "Subject is mandatory.")]
        [MaxLength(100, ErrorMessage = "maximum 100 characters allowed")]
        [MinLength(3, ErrorMessage = "minimum 3 characters allowed")]
        public string MailSubject { get; set; }

       
        [Required(ErrorMessage = "User Name is mandatory.")]
        [MaxLength(50, ErrorMessage = "maximum 50 characters allowed")]
        [MinLength(3, ErrorMessage = "minimum 3 characters allowed")]


        public string MailUserName { get; set; }

        
        
        [Required(ErrorMessage = "Message is mandatory.")]
        [MaxLength(300, ErrorMessage = "maximum 300 characters allowed")]
        [MinLength(3, ErrorMessage = "minimum 3 characters allowed")]

        public string MailMessage { get; set; }
    }
}
