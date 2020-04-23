using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Domain.Entities
{
    public class Employee : Person
    {
        public long FileNumber { get; set; }
    }
}
