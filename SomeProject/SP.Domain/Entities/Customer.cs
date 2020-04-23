using System.Collections.Generic;

namespace SP.Domain.Entities
{
    public class Customer : Person
    {
        public CheckingAccount CheckingAccount { get; set; }
    }
}
