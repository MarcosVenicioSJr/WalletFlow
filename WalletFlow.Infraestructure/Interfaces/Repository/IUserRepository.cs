using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Interfaces.Repositorys;

namespace WalletFlow.Infraestructure.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
