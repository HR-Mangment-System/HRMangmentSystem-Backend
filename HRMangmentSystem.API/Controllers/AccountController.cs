using AutoMapper;
using HRMangmentSystem.API.DTOS;
using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdminAsync(AccountPostDTO user)
        {

            var mappedUser = _mapper.Map<AccountPostDTO, ApplicationUser>(user);
            await _accountRepository.CreateAdminAsync(mappedUser, true);
            return Ok();
        }
    }
}
