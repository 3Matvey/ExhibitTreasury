using System.Linq.Expressions;
using ExhibitTreasury.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ExhibitTreasury.Persistence.Repositories
{
    public class EfRepository<T>(AppDbContext context) 
        : IRepository<T> 
            where T : Entity
    {
        protected readonly AppDbContext _context = context;
        protected readonly DbSet<T> _entities = context.Set<T>();

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includesProperties)
        {
            IQueryable<T> query = _entities;
            foreach (var include in includesProperties)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includesProperties)
        {
            IQueryable<T> query = _entities;
            foreach (var include in includesProperties)
            {
                query = query.Include(include);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _entities.AddAsync(entity, cancellationToken);
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _entities.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
        }
    }
}
