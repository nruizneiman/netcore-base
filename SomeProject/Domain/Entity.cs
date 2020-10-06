using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public abstract class Entity
    {
        protected Entity()
        {
            IsEnabled = true;
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime CreationDate { get; private set; }
        public DateTime? LastUpdate { get; set; }
        public bool IsEnabled { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
