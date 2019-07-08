namespace mentor_api.Models
{
    public class TeachableCities
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}