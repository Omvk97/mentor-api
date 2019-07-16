namespace mentor_api.Models.Teachings
{
    public class TeachingSpecialization
    {
        public Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }
        public Teaching Teaching { get; set; }
        public int TeachingId { get; set; }
    }
}