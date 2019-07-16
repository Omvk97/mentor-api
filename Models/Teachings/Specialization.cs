using System.Collections.Generic;

namespace mentor_api.Models.Teachings
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeachingSpecialization> Teachings { get; set; }
    }
}