using SP.Domain.Base.IUnitOfWork;
using SP.Infrastructure.Contexts;

namespace SP.Infrastructure.Base.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataContext Context { get; }

        public UnitOfWork(DataContext dataContext)
        {
            Context = dataContext;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Rollback()
        {
            Context.Dispose();
        }
    }
}
