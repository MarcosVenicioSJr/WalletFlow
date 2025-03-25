using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletFlow.Domain.DTOs.Responses;
using WalletFlow.Domain.Entities;
using WalletFlow.Services.Interfaces.Services;
using WalletFlow.Services.Mappers;

namespace WalletFlow.API.Controllers
{
    public class TransactionHistoryController : Controller
    {
        private readonly ITransactionHistory _services;

        public TransactionHistoryController(ITransactionHistory services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("{accountNumber}")]
        [Authorize]
        public ActionResult GetAll(string accountNumber)
        {
            List<GetTransactionHistoryResponseDTO> transactionList = _services.GetAll(accountNumber);

            return Ok(transactionList);
        }

        [HttpGet("by-period")]
        [Authorize]
        public async Task<IActionResult> GetTransactionsByPeriod(
            [FromQuery] string accountNumber,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            if (string.IsNullOrEmpty(accountNumber))
                return BadRequest("O número da conta é obrigatório.");

            DateTime? startDateUtc = startDate != null ? DateTime.SpecifyKind(startDate.Value, DateTimeKind.Utc) : (DateTime?)null;
            DateTime? endDateUtc = endDate != null ? startDate = DateTime.SpecifyKind(endDate.Value, DateTimeKind.Utc) : (DateTime?)null;

            var transactions = _services.GetTransactionsByPeriod(accountNumber, startDateUtc, endDateUtc);

            if (!transactions.Any())
                return NotFound("Nenhuma transação encontrada para os critérios informados.");

            return Ok(transactions);
        }
    }
}
