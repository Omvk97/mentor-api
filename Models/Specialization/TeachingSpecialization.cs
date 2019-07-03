namespace mentor_api.Models
{
    public class TeachingSpecialization
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Specialization Specialization { get; set; }
    }
}