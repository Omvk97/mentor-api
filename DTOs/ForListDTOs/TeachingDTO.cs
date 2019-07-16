using System.Collections.Generic;

namespace mentor_api.DTOs.ForListDTOs
{
    public class TeachingDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<SpecializationDTO> Specializations { get; set; }
    }
}