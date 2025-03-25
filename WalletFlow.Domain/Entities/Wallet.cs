namespace WalletFlow.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string OwnerAccount { get; set; }
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public List<TransactionHistory> Transactions { get; set; } = new();
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
