using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Domain.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public byte[] Flag { get; set; }
        public string CurrencyCode { get; set; }

        // Navigation properties
    }
}
