namespace SP.Domain
{
    public class Entity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
