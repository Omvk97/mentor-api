using System.ComponentModel.DataAnnotations;

namespace mentor_api.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [MaxLength(8)]
        public string PhoneNumber { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
    }
}