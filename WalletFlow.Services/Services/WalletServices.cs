using WalletFlow.Domain.DTOs.Requests;
using WalletFlow.Domain.DTOs.Requests.Wallet;
using WalletFlow.Domain.Entities;
using WalletFlow.Infraestructure.Interfaces.Repository;
using WalletFlow.Services.Interfaces.Services;
using WalletFlow.Services.Mappers;

namespace WalletFlow.Services.Services
{
    public class WalletServices : IWalletService
    {
        private readonly IWalletRepository _repository;
        private readonly IUserService _userService;
        private readonly ITransactionHistoryRepository _transactionsRepository;

        public WalletServices(IWalletRepository repository, IUserService userService, ITransactionHistoryRepository transactionsRepository)
        {
            _repository = repository;
            _userService = userService;
            _transactionsRepository = transactionsRepository;

        }

        public Wallet AddBalance(AddBalanceRequestDTO request)
        {
            Wallet wallet = GetByAccountNumber(request.AccountNumber);

            wallet.Balance += request.Balance;

            _repository.Update(wallet);

            TransactionHistory historyc = TransactionHistoryMapper.CreateDepositTransactionHistoryMapper(wallet, request.Balance, "Debit");

            _transactionsRepository.Add(historyc);

            _repository.Save();

            return wallet;
        }

        public void Create(Wallet entity)
        {
            Wallet wallet = _repository.GetByAccountNumber(entity.AccountNumber).Result;

            if (wallet != null)
                throw new Exception("Wallet already exists");

            _userService.ValidateUserIsValid(entity.User);
            User user = _userService.GetByEmail(entity.User.Email);

            entity.UserId = user.Id;
            entity.User = null;

            _repository.Add(entity);
        }

        public Wallet GetByAccountNumber(string accountNumber)
        {
            Wallet wallet = _repository.GetByAccountNumber(accountNumber).Result
                ?? throw new Exception("Wallet not found");

            return wallet;
        }

        public Wallet RemoveBalance(AddBalanceRequestDTO request)
        {
            Wallet wallet = GetByAccountNumber(request.AccountNumber);

            wallet.Balance -= request.Balance;

            if (wallet.Balance < 0)
                throw new Exception("The wallet balance cannot be negative.");

            _repository.Update(wallet);

            TransactionHistory historyc = TransactionHistoryMapper.CreateDepositTransactionHistoryMapper(wallet, request.Balance, "Credit");

            _transactionsRepository.Add(historyc);

            _repository.Save();

            return wallet;
        }

        public void Transfer(TransferRequestDTO request)
        {
            Wallet walletFrom = GetByAccountNumber(request.FromAccountNumber);

            Wallet walletTo = GetByAccountNumber(request.ToAccountNumber);

            if (request.Balance < 0)
                throw new Exception("Balance is invalid");

            if (walletFrom.Balance < request.Balance)
                throw new Exception("Insufficient balance for the transfer.");

            walletFrom.Balance -= request.Balance;

            walletTo.Balance += request.Balance;

            _repository.Update(walletFrom);
            _repository.Update(walletTo);

            TransactionHistory historycCredit = TransactionHistoryMapper.CreateDepositTransactionHistoryMapper(walletFrom, request.Balance, "Credit");
            TransactionHistory historycDebit = TransactionHistoryMapper.CreateDepositTransactionHistoryMapper(walletTo, request.Balance, "Debit");

            _transactionsRepository.Add(historycCredit);
            _transactionsRepository.Add(historycDebit);

            _repository.Save();
        }
    }
}
