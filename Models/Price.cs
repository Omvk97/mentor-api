namespace mentor_api.Models
{
    public class Price
    {
        public int Id { get; set; }
        public double Price30Min { get; set; }
        public double Price45Min { get; set; }
        public double Price60Min { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
    }
}