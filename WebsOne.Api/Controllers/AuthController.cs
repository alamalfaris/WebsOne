using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;
using Shared.Responses;
using WebsOne.Api.Contracts;
using WebsOne.Api.Helpers;

namespace WebsOne.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public AuthController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginResponse = await _repository.Auth.LoginLogic(request);
            var response = ResponseHelpers<LoginResponse>.CreateResponseSuccess(loginResponse, "");
            return Ok(response);
        }
    }
}
