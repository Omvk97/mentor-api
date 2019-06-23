namespace mentor_backend.Models
{
    public class Mentor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TeachingInformation { get; set; }
        public Price Price { get; set; }
    }
}