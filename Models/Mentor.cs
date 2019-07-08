using System.Collections.Generic;

namespace mentor_api.Models
{
    public class Mentor
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string TeachingInformation { get; set; }
        public Price Price { get; set; }
        public Picture ProfilePicture { get; set; }
        public ICollection<TeachableCities> TeachableCities { get; set; }
        public ICollection<TeachingSpecialization> TeachingSpecializations { get; set; }
        public ICollection<Phone> PhoneNumbers { get; set; }
    }
}