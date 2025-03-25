using WalletFlow.Domain.DTOs.Responses;
using WalletFlow.Domain.Entities;
using WalletFlow.Services.Interfaces.IGenerics;

namespace WalletFlow.Services.Interfaces.Services
{
    public interface ITransactionHistory : IServices<TransactionHistory>
    {
        List<GetWalletByAccountNumberResponseDTO> GetAll(string accoutNumber);

        List<GetWalletByAccountNumberResponseDTO> GetTransactionsByPeriod(string accountNumber, DateTime? startDate = null, DateTime? endDate = null);
    }
}
