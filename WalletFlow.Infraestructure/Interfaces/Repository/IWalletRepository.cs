using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Interfaces.Repositorys;

namespace WalletFlow.Infraestructure.Interfaces.Repository
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        Task<Wallet> GetByAccountNumber(string accountNumber);
    }
}
