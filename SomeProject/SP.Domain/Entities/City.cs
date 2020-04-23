using System.Collections.Generic;

namespace SP.Domain.Entities
{
    public class City
    {
        public string Name { get; set; }
        public IEnumerable<Person> Persons { get; set; }
    }
}
