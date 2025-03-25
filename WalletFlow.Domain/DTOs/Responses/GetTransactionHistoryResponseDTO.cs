using WalletFlow.Domain.Entities;

namespace WalletFlow.Domain.DTOs.Responses
{
    public class GetTransactionHistoryResponseDTO
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }
        public Wallet Wallet { get; set; }
    }
}
