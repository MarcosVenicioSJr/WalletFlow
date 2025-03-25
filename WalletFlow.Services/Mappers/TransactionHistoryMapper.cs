using WalletFlow.Domain.DTOs.Responses;
using WalletFlow.Domain.Entities;

namespace WalletFlow.Services.Mappers
{
    public static class TransactionHistoryMapper
    {
        public static TransactionHistory CreateDepositTransactionHistoryMapper(Wallet wallet, decimal value, string type)
        {
            return new TransactionHistory
            {
                TransactionDate = DateTime.UtcNow,
                Type = type,
                Amount = value,
                WalletId = wallet.Id
            };
        }

        public static List<GetWalletByAccountNumberResponseDTO> MapperResponseGet(List<TransactionHistory> transactionList, string accountNumber, Wallet wallet)
        {
            List<GetWalletByAccountNumberResponseDTO> response = new List<GetWalletByAccountNumberResponseDTO>();
        
            foreach (var transaction in transactionList)
            {
                GetWalletByAccountNumberResponseDTO getWalletByAccountNumberResponseDTO = new GetWalletByAccountNumberResponseDTO()
                {
                    OwnerAccount = wallet.OwnerAccount,
                    AccountNumber = accountNumber,
                    Balance = transaction.Amount,
                    Type = transaction.Type,
                    TransactionDate = transaction.TransactionDate
                };

                response.Add(getWalletByAccountNumberResponseDTO);
            }

            return response;
        }
    }
}
