using System.Collections.Generic;

namespace SP.Domain.Entities
{
    public class State
    {
        public string Name { get; set; }

        // Navigation property
        public IEnumerable<City> Cities { get; set; }
    }
}
