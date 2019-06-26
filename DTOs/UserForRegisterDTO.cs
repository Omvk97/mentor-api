using System.ComponentModel.DataAnnotations;

namespace mentor_api.DTOs
{
    public class UserForRegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}