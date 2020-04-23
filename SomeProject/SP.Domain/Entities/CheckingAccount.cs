using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Domain.Entities
{
    public class CheckingAccount : Entity
    {
        public decimal Balance { get; set; }

        public Customer Customer { get; set; }
    }
}
