using Microsoft.EntityFrameworkCore;
using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Context;
using WalletFlow.Infraestructure.Interfaces.Repository;

namespace WalletFlow.Infraestructure.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _context;

        public WalletRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Wallet entity)
        {
            try
            {
                await _context.Wallets.AddAsync(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Wallet> GetByAccountNumber(string accountNumber)
        {
            return await _context.Wallets.FirstOrDefaultAsync(wallet => wallet.AccountNumber == accountNumber);
        }

        public Task<Wallet> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Wallet entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
