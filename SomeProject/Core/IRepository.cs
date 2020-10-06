using Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task LogicDelete(int id);

        Task SaveChangesAsync();

        Task<T> GetByIdAsync(int id, string include = null);
        IQueryable<T> Get();
    }
}
