namespace WalletFlow.Domain.DTOs.Responses
{
    public class GetWalletByAccountNumberResponseDTO
    {
        public string OwnerAccount { get; set; }
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
    }
}
