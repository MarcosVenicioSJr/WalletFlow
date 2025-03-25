using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletFlow.Domain.DTOs.Requests.Users;
using WalletFlow.Domain.Entities;
using WalletFlow.Services.Interfaces.Services;
using WalletFlow.Services.Mappers;

namespace WalletFlow.API.Controllers
{
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateUser([FromBody] CreateUserRequestDTO request)
        {
            try
            {
                User entity = UserMapper.MapperCreateRequestToUser(request);
                _service.Create(entity);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] LoginRequestDTO request)
        {
            try
            {
                User entity = UserMapper.MapperLoginRequestToUser(request);
                string token = _service.Login(entity);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
