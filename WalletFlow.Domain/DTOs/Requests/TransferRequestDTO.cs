namespace WalletFlow.Domain.DTOs.Requests
{
    public class TransferRequestDTO
    {
        public string ToAccountNumber { get; set; }
        public string ToAccountOwner { get; set; }
        public string FromAccountNumber { get; set; }
        public string FromAccountOwner { get; set; }
        public decimal Balance { get; set; }
    }
}
