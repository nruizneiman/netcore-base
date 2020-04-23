using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SP.Domain.Base.IRepository
{
    public interface IQueryRepository<T> where T : Entity
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> whereCondition = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}
