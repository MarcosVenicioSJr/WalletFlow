using Microsoft.EntityFrameworkCore;
using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Context;
using WalletFlow.Infraestructure.Interfaces.Repository;

namespace WalletFlow.Infraestructure.Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly AppDbContext _context;

        public TransactionHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TransactionHistory entity)
        {
            await _context.Transactions.AddAsync(entity);

        }

        public Task<TransactionHistory> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransactionHistory>> GetAllTransactions(int walletId)
        {
            return await _context.Transactions
                .Where(t => t.WalletId == walletId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<List<TransactionHistory>> GetTransactionsByPeriod(
            string accountNumber, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Transactions
                .Where(t => t.Wallet.AccountNumber == accountNumber);

            if (startDate.HasValue)
                query = query.Where(t => t.TransactionDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(t => t.TransactionDate <= endDate.Value);

            return await query.OrderByDescending(t => t.TransactionDate).ToListAsync();
        }
    }
}
