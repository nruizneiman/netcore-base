using System;
using System.Threading.Tasks;

namespace SP.Domain.Base.IRepository
{
    public interface ICommandRepository<T> where T : Entity
    {
        Task Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
