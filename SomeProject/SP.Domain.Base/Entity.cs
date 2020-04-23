using System;

namespace SP.Domain.Base
{
    public class Entity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
