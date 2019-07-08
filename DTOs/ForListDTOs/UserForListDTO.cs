using System;

namespace mentor_api.DTOs.ForListDTOs
{
    public class UserForListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}