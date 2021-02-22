using Core;
using Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public Task Delete(T entity)
        {
            _context.Remove(entity);

            return Task.CompletedTask;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id, string include = null)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (include != null)
            {
                var includeProperties = include.Split(',');

                foreach (var path in includeProperties)
                {
                    _context.Entry(entity).Reference(path.Trim()).Load();
                }
            }

            return entity;
        }

        public async Task LogicDelete(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsEnabled = !entity.IsEnabled;
            await Update(entity);
        }

        public Task Update(T entity)
        {
            _context.Update(entity);
            entity.LastUpdate = DateTime.Now;

            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
