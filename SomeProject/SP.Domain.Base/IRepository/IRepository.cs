namespace SP.Domain.Base.IRepository
{
    public interface IRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : Entity
    {
    }
}
