using System.Linq.Expressions;

namespace ExhibitTreasury.Persistence.Fakes
{
    // Фейковый репозиторий для залов музея (Hall)
    public class FakeHallRepository : IRepository<Hall>
    {
        private readonly List<Hall> _halls;

        public FakeHallRepository()
        {
            // Инициализация тестовыми данными
            _halls =
            [
                new Hall { Id = 1, Name = "Ancient Art", Description = "Exhibits from ancient civilizations", Exhibits = [] },
                new Hall { Id = 2, Name = "Modern Art", Description = "Exhibits from modern era", Exhibits = [] }
            ];
        }

        public Task AddAsync(Hall entity, CancellationToken cancellationToken = default)
        {
            if (_halls.Count != 0)
                entity.Id = _halls.Max(h => h.Id) + 1;
            else
                entity.Id = 1;
            _halls.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Hall entity, CancellationToken cancellationToken = default)
        {
            _halls.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Hall?> FirstOrDefaultAsync(Expression<Func<Hall, bool>> filter, CancellationToken cancellationToken = default)
        {
            var compiledFilter = filter.Compile();
            Hall? hall = _halls.FirstOrDefault(compiledFilter);
            return Task.FromResult(hall);
        }

        public Task<Hall?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Hall, object>>[] includesProperties)
        {
            Hall? hall = _halls.FirstOrDefault(h => h.Id == id);
            return Task.FromResult(hall);
        }

        public Task<IReadOnlyList<Hall>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<Hall>)_halls);
        }

        public Task<IReadOnlyList<Hall>> ListAsync(Expression<Func<Hall, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Hall, object>>[] includesProperties)
        {
            var compiledFilter = filter.Compile();
            var list = _halls.Where(compiledFilter).ToList();
            return Task.FromResult((IReadOnlyList<Hall>)list);
        }

        public Task UpdateAsync(Hall entity, CancellationToken cancellationToken = default)
        {
            var hall = _halls.FirstOrDefault(h => h.Id == entity.Id);
            if (hall != null)
            {
                hall.Name = entity.Name;
                hall.Description = entity.Description;
                hall.Exhibits = entity.Exhibits;
            }
            return Task.CompletedTask;
        }
    }
}
