using System.ComponentModel.DataAnnotations;

namespace mentor_api.DTOs
{
    public class UserForRegisterDTO
    {
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [StringLength(100, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 100 characters")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
    }
}