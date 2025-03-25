using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletFlow.Domain.DTOs.Requests;
using WalletFlow.Domain.DTOs.Requests.Wallet;
using WalletFlow.Domain.Entities;
using WalletFlow.Services.Interfaces.Services;
using WalletFlow.Services.Mappers;

namespace WalletFlow.API.Controllers
{
    [Route("Wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _services;

        public WalletController(IWalletService services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("{accountNumber}")]
        [Authorize]
        public ActionResult GetWallet(string accountNumber)
        {
            try
            {
                Wallet wallet = _services.GetByAccountNumber(accountNumber);
                return Ok(WalletMapper.MapperWalletToGetResponse(wallet));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody] CreateWalletRequestDTO request)
        {
            try
            {
                Wallet entity = WalletMapper.MapperCreateWalletRequestDTOToWallet(request);
                _services.Create(entity);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddBalance")]
        [Authorize]
        public ActionResult AddBalance([FromBody] AddBalanceRequestDTO request)
        {
            try
            {
                Wallet wallet = _services.AddBalance(request);

                return Ok(WalletMapper.MapperWalletToGetResponse(wallet));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("RemoveBalance")]
        [Authorize]
        public ActionResult RemoveBalance([FromBody] AddBalanceRequestDTO request)
        {
            try
            {
                Wallet wallet = _services.RemoveBalance(request);

                return Ok(WalletMapper.MapperWalletToGetResponse(wallet));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Transfer")]
        [Authorize]
        public ActionResult Transfer([FromBody] TransferRequestDTO request)
        {
            try
            {
                _services.Transfer(request);
                return Ok("Transferencia realizada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
