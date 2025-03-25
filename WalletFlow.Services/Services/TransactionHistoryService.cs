using WalletFlow.Domain.DTOs.Responses;
using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Interfaces.Repository;
using WalletFlow.Services.Interfaces.Services;
using WalletFlow.Services.Mappers;

namespace WalletFlow.Services.Services
{
    public class TransactionHistoryService : ITransactionHistory
    {
        private readonly ITransactionHistoryRepository _repository;
        private readonly IWalletRepository _repositoryWallet;

        public TransactionHistoryService(ITransactionHistoryRepository repository, IWalletRepository repositoryWallet)
        {
            _repository = repository;
            _repositoryWallet = repositoryWallet;
        }

        public void Create(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public List<GetWalletByAccountNumberResponseDTO> GetAll(string accountNumber)
        {
            Wallet wallet = _repositoryWallet.GetByAccountNumber(accountNumber).Result;

            if (wallet == null)
                throw new Exception("Wallet not found");

            List<TransactionHistory> transactionsList = _repository.GetAllTransactions(wallet.Id).Result;

            return TransactionHistoryMapper.MapperResponseGet(transactionsList, accountNumber, wallet);          
        }

        public List<GetWalletByAccountNumberResponseDTO> GetTransactionsByPeriod(string accountNumber, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (string.IsNullOrEmpty(accountNumber))
                throw new ArgumentException("O número da conta é obrigatório.");

            Wallet wallet = _repositoryWallet.GetByAccountNumber(accountNumber).Result;

            if (wallet == null)
                throw new Exception("Wallet not found");

            List<TransactionHistory> transactionsList = _repository.GetTransactionsByPeriod(accountNumber, startDate, endDate).Result;

            return TransactionHistoryMapper.MapperResponseGet(transactionsList, accountNumber, wallet);
        }
    }
}
