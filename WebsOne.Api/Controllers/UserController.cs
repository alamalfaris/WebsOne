using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DataTransferObjects;
using Models.Entities;
using Shared.Constants;
using WebsOne.Api.Contracts;
using WebsOne.Api.Helpers;

namespace WebsOne.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(UserDto request)
        {
            var newUser = _mapper.Map<User>(request);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            await _repository.Create(newUser);

            var response = ResponseHelpers<string>.CreateResponseSuccess("", MessageConstants.CreateSuccess);
            
            return Ok(response);
        }
    }
}
