using System.Collections.Generic;
using mentor_api.DTOs.DetailedDTOs;

namespace mentor_api.DTOs.ForListDTOs
{
    public class MentorForListDTO
    {
        public int UserId { get; set; }
        public UserForListDTO User { get; set; }
        public PriceForListDTO Price { get; set; }
        public string ProfilePictureUrl { get; set; }
        public ICollection<TeachableCitiesDTO> TeachableCities { get; set; }
        public ICollection<TeachingDTO> Teachings { get; set; }
    }
}