using System.ComponentModel.DataAnnotations;

namespace HRMangmentSystem.API.DTOS.AccountDTO
{
    public class LoginAccountDTO
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
