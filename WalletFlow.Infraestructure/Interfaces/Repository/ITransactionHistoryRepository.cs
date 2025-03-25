using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Interfaces.Repositorys;

namespace WalletFlow.Infraestructure.Interfaces.Repository
{
    public interface ITransactionHistoryRepository : IRepository<TransactionHistory>
    {
        Task<List<TransactionHistory>> GetAllTransactions(int walletId);

        Task<List<TransactionHistory>> GetTransactionsByPeriod(string accountNumber, DateTime? startDate = null, DateTime? endDate = null);
    }
}
