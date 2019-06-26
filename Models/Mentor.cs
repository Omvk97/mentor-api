namespace mentor_api.Models
{
    public class Mentor : User
    {
        public string Description { get; set; }
        public string TeachingInformation { get; set; }
        public Price Price { get; set; }
    }
}