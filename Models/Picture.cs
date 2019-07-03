using System.ComponentModel.DataAnnotations.Schema;

namespace mentor_api.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
    }
}