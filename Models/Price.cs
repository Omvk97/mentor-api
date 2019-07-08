namespace mentor_api.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int Price30Min { get; set; }
        public int Price45Min { get; set; }
        public int Price60Min { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
    }
}