using System.ComponentModel.DataAnnotations;

namespace mentor_api.Models
{
    public class Price
    {
        public int Id { get; set; }
        [Range(1, 9999)]
        public int Price30Min { get; set; }
        [Range(1, 9999)]
        public int Price45Min { get; set; }
        [Range(1, 9999)]
        public int Price60Min { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
    }
}