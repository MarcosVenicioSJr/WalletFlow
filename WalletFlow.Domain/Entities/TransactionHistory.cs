namespace WalletFlow.Domain.Entities
{
    public class TransactionHistory
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }
        public Wallet Wallet { get; set; }
    }
}
