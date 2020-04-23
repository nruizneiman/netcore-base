namespace SP.Domain.Entities
{
    public abstract class Person : Entity
    {
        public string Name { get; set; }
        public City City { get; set; }
    }
}
