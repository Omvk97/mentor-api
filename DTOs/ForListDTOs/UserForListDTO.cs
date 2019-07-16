using System;

namespace mentor_api.DTOs.ForListDTOs
{
    public class UserForListDTO
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}