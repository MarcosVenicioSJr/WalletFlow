using WalletFlow.Domain.DTOs.Requests;
using WalletFlow.Domain.DTOs.Requests.Wallet;
using WalletFlow.Domain.Entities;
using WalletFlow.Services.Interfaces.IGenerics;

namespace WalletFlow.Services.Interfaces.Services
{
    public interface IWalletService : IServices<Wallet>
    {
        Wallet GetByAccountNumber(string accountNumber);

        Wallet AddBalance(AddBalanceRequestDTO request);

        Wallet RemoveBalance(AddBalanceRequestDTO request);

        void Transfer(TransferRequestDTO request);
    }
}
