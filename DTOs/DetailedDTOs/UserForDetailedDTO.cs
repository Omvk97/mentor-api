using System;

namespace mentor_api.DTOs.DetailedDTOs
{
    public class UserForDetailedDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}