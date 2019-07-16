using System.Collections.Generic;

namespace mentor_api.Models.Teachings
{
    public class Teaching
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<TeachingSpecialization> TeachingSpecializations { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
    }
}