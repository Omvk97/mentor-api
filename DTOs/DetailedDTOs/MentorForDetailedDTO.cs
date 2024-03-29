using System.Collections.Generic;
using mentor_api.DTOs.ForListDTOs;

namespace mentor_api.DTOs.DetailedDTOs
{
    public class MentorForDetailedDTO
    {
        public int UserId { get; set; }
        public UserForDetailedDTO User { get; set; }
        public string Description { get; set; }
        public string TeachingInformation { get; set; }
        public PriceForDetailedDTO Price { get; set; }
        public string ProfilePictureUrl { get; set; }
        public ICollection<TeachableCitiesDTO> TeachableCities { get; set; }
        public ICollection<TeachingDTO> Teachings { get; set; }
        public string PhoneNumber { get; set; }
    }
}