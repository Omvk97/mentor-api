using System.Collections.Generic;

namespace mentor_api.Models
{
    public class Mentor : User
    {
        public string Description { get; set; }
        public string TeachingInformation { get; set; }
        public Price Price { get; set; }
        public Picture ProfilePicture { get; set; }
        public Picture CoverPicture { get; set; }
        public ICollection<MentorCity> MentorCities { get; set; }
        public ICollection<TeachingSpecialization> TeachingSpecializations { get; set; }
        public ICollection<Phone> PhoneNumbers { get; set; }
    }
}