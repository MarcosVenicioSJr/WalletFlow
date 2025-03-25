using System.ComponentModel.DataAnnotations;

namespace WalletFlow.Domain.DTOs.Requests.Users
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
