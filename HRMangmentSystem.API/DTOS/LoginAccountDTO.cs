using System.ComponentModel.DataAnnotations;

namespace HRMangmentSystem.API.DTOS
{
    public class LoginAccountDTO
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
