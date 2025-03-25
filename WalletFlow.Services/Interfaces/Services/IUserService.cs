using WalletFlow.Domain.Entities;
using WalletFlow.Services.Interfaces.IGenerics;

namespace WalletFlow.Services.Interfaces.Services
{
    public interface IUserService : IServices<User>
    {
        string Login(User user);

        bool ValidateUserIsValid(User user);

        User GetByEmail(string email);
    }
}
