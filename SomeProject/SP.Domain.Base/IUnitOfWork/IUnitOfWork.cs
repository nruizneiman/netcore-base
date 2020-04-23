using SP.Infrastructure.Contexts;

namespace SP.Domain.Base.IUnitOfWork
{
    public interface IUnitOfWork
    {
        DataContext Context { get; }
        void Commit();
        void Rollback();
    }
}
