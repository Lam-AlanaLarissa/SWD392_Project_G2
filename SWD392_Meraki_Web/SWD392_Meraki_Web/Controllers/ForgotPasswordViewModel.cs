using System.ComponentModel.DataAnnotations;

namespace SWD392_Meraki_Web.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
