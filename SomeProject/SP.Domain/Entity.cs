using System;

namespace SP.Domain
{
    public class Entity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
