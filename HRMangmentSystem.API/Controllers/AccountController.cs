using AutoMapper;
using HRMangmentSystem.API.DTOS;
using HRMangmentSystem.API.ResponseBase;
using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Web.Http.ModelBinding;

namespace HRMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly ResponseHandler _responseHandler;
        #endregion
        #region Ctor
        public AccountController(
            IAccountRepository accountRepository,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManger,
            ResponseHandler responseHandler
        )
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManger = userManger;
            _responseHandler = responseHandler;
        }

        #endregion

        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdminAsync(AccountPostDTO user)
        {
            if (await _userManger.FindByEmailAsync(user.Email) != null)
            {
                Response<string> response = _responseHandler.BadRequest<string>("Email Already Exists");
                return BadRequest(response);
            }
            if (await _userManger.FindByNameAsync(user.Username) is not null)
            {
                Response<string> response = _responseHandler.BadRequest<string>("Username Already Exists");
                return BadRequest(response);
            }
            var mappedUser = _mapper.Map<AccountPostDTO, ApplicationUser>(user);
            await _accountRepository.CreateAdminAsync(mappedUser, user.Password, false);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginAccountDTO loginData)
        {
            ApplicationUser user;
            if (ModelState.IsValid)
            {
                user = await _userManger.FindByEmailAsync(loginData.UsernameOrEmail) ??
                        await _userManger.FindByNameAsync(loginData.UsernameOrEmail);
                if (user is null)
                {
                    Response<string> response = _responseHandler.NotFound<string>("User Not Found");
                    return NotFound(response);
                }
                else
                {
                    bool rightPw = await _userManger.CheckPasswordAsync(user, loginData.Password);
                    if (!rightPw)
                    {
                        Response<string> response = _responseHandler.BadRequest<string>("Wrong Password");
                        return BadRequest(response);
                    }
                    else
                    {
                        var token = await _accountRepository.CreateLoginTokenAsync(user);
                        Response<string> response = _responseHandler.Success<string>(token);
                        return Ok(response);
                    }

                }

            }
            return BadRequest();
        }
    }
}
