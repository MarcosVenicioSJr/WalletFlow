using System.ComponentModel.DataAnnotations;

namespace WalletFlow.Domain.DTOs.Requests.Wallet
{
    public class AddBalanceRequestDTO
    {
        [Required(ErrorMessage = "AccountNumber is required")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Balance is required")]
        public decimal Balance { get; set; }
    }
}
