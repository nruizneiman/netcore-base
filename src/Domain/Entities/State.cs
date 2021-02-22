namespace Domain.Entities
{
    public class State : Entity
    {
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}
