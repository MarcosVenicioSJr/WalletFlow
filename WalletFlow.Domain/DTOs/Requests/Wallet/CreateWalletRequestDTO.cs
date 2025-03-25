using System.ComponentModel.DataAnnotations;
using WalletFlow.Domain.DTOs.Requests.Users;

namespace WalletFlow.Domain.DTOs.Requests.Wallet
{
    public class CreateWalletRequestDTO
    {
        [Required(ErrorMessage = "OwnerAccount is required")]
        public string OwnerAccount { get; set; }

        public decimal? Balance { get; set; }

        [Required(ErrorMessage = "AccountNumber is required")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "User is required")]
        public CreateUserRequestDTO User { get; set; }
    }
}
