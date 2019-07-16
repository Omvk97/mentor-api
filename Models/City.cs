using System.Collections.Generic;

namespace mentor_api.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public ICollection<TeachableCities> TeachableCities { get; set; }
    }
}