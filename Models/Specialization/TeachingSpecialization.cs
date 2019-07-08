namespace mentor_api.Models
{
    public class TeachingSpecialization
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Specialization Specialization { get; set; }
        public int SpecializationId { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
    }
}