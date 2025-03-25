using WalletFlow.Domain.DTOs.Requests.Users;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Services.Mappers
{
    public static class UserMapper
    {
        public static User MapperCreateRequestToUser(CreateUserRequestDTO request)
        {
            return new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };
        }

        public static User MapperLoginRequestToUser(LoginRequestDTO request)
        {
            return new User
            {
                Email = request.Email,
                Password = request.Password
            };
        }
    }
}
