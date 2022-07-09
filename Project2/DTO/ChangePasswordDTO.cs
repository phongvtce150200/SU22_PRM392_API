using System.ComponentModel.DataAnnotations;

namespace Project2.DTO
{
    public class ChangePasswordDTO
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword), ErrorMessage = "Confirm Password must be matching with Password")]
        public string ConfirmPasword { get; set; }
    }
}
