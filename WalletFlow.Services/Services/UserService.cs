using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Interfaces.Repository;
using WalletFlow.Infraestructure.Security;
using WalletFlow.Services.Interfaces.Services;
using WalletFlow.Services.Security;

namespace WalletFlow.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Create(User entity)
        {
            entity.Password = Cryptography.CryptographyPassword(entity.Password);
            _repository.Add(entity);
        }

        public User GetByEmail(string email)
        {
            return _repository.GetByEmail(email).Result
                    ?? throw new Exception("User not found");
        }

        public string Login(User user)
        {
            User userExists = GetByEmail(user.Email);

            user.Password = Cryptography.CryptographyPassword(user.Password);

            if (userExists.Password != user.Password)
                throw new Exception("Password Invalid");

            return Token.GenerateToken(userExists);
        }

        public bool ValidateUserIsValid(User user)
        {
            User userExists = GetByEmail(user.Email);

            user.Password = Cryptography.CryptographyPassword(user.Password);

            if (userExists.Password != user.Password)
                throw new Exception("Password Invalid");

            return true;
        }
    }
}
