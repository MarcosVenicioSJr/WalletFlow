using WalletFlow.Domain.DTOs.Requests.Wallet;
using WalletFlow.Domain.DTOs.Responses;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Services.Mappers
{
    public static class WalletMapper
    {
        public static GetWalletByAccountNumberResponseDTO MapperWalletToGetResponse(Wallet entity)
        {
            return new GetWalletByAccountNumberResponseDTO
            {
                AccountNumber = entity.AccountNumber,
                Balance = entity.Balance,
                OwnerAccount = entity.OwnerAccount
            };
        }

        public static Wallet MapperCreateWalletRequestDTOToWallet(CreateWalletRequestDTO request)
        {
            return new Wallet
            {
                AccountNumber = request.AccountNumber,
                Balance = request.Balance != null ? request.Balance.Value : 0M,
                OwnerAccount = request.OwnerAccount,
                User = new User
                {
                    Name = request.User.Name,
                    Email = request.User.Email,
                    Password = request.User.Password
                }
            };
        }
    }
}
