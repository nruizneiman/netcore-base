using System.Collections.Generic;

namespace SP.Domain.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public byte[] Flag { get; set; }
        public string CurrencyCode { get; set; }

        // Navigation properties
        public IEnumerable<State> States { get; set; }
    }
}
