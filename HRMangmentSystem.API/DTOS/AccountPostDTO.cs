using System.ComponentModel.DataAnnotations;

namespace HRMangmentSystem.API.DTOS
{
    public class AccountPostDTO
    {
        [MaxLength(45, ErrorMessage = "Full name must not exceed 45 characters.")]
        public string FullName { get; set; }
        [MaxLength(20, ErrorMessage = "Username must not exceed 20 characters.")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [RegularExpression("^[a-zA-Z0-9@#$%^&*!]{8,20}$")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
