using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mentor_api.Models.Teachings;

namespace mentor_api.Models
{
    public class Mentor
    {
        [Key]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Description { get; set; }
        public string TeachingInformation { get; set; }
        public Price Price { get; set; }
        public Picture ProfilePicture { get; set; }
        public ICollection<TeachableCities> TeachableCities { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string PhoneNumber { get; set; }
    }
}