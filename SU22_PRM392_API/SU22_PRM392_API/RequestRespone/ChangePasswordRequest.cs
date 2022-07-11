using System.ComponentModel.DataAnnotations;

namespace SU22_PRM392_API.RequestRespone
{
    public class ChangePasswordRequest
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfrimPassword { get; set; }
    }
}
