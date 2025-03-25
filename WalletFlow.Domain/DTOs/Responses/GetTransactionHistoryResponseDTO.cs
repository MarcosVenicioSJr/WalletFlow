using WalletFlow.Domain.Entities;

namespace WalletFlow.Domain.DTOs.Responses
{
    public class GetTransactionHistoryResponseDTO
    {
        public string OwnerAccount { get; set; }
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
