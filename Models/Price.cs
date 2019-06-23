using System.ComponentModel.DataAnnotations.Schema;

namespace mentor_backend.Models
{
    public class Price
    {
        [ForeignKey("Mentor")]
        public int Id { get; set; }
        public double Price30Min { get; set; }
        public double Price45Min { get; set; }
        public double Price60Min { get; set; }
        public Mentor Mentor { get; set; }
    }
}