using System.Collections.Generic;

namespace Domain.Entities
{
    public class Country : Entity
    {
        public Country()
        {

        }

        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        // Navigation properties
        public IEnumerable<State> States { get; set; }
    }
}
