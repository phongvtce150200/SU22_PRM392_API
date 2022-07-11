using System.ComponentModel.DataAnnotations;

namespace SU22_PRM392_API.RequestRespone
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null;
        public string Address { get; set; } = null;
    }
}
