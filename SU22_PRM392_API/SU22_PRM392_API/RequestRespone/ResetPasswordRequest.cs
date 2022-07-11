using System.ComponentModel.DataAnnotations;

namespace SU22_PRM392_API.RequestRespone
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
