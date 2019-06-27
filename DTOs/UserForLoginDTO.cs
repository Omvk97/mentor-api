using System.ComponentModel.DataAnnotations;

namespace mentor_api.DTOs
{
    public class UserForLoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}