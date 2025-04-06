using System.Linq.Expressions;
    
namespace ExhibitTreasury.Persistence.Fakes
{
    // Фейковый репозиторий для экспонатов (Exhibit)
    public class FakeExhibitRepository : IRepository<Exhibit>
    {
        private readonly List<Exhibit> _exhibits;
        public FakeExhibitRepository()
        {
            // Инициализация тестовыми данными
            _exhibits =
            [
                new Exhibit
                {
                    Id = 1,
                    Name = "Statue of Zeus",
                    AppraisedValue = 1000000m,
                    YearCreated = -500,
                    Material = "Marble",
                    Artist = "Unknown",
                    HallId = 1
                },
                new Exhibit
                {
                    Id = 2,
                    Name = "Mona Lisa",
                    AppraisedValue = 850000000m,
                    YearCreated = 1503,
                    Material = "Oil on poplar",
                    Artist = "Leonardo da Vinci",
                    HallId = 2
                }
            ];
        }

        public Task AddAsync(Exhibit entity, CancellationToken cancellationToken = default)
        {
            if (_exhibits.Any())
                entity.Id = _exhibits.Max(e => e.Id) + 1;
            else
                entity.Id = 1;
            _exhibits.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Exhibit entity, CancellationToken cancellationToken = default)
        {
            _exhibits.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Exhibit?> FirstOrDefaultAsync(Expression<Func<Exhibit, bool>> filter, CancellationToken cancellationToken = default)
        {
            var compiledFilter = filter.Compile();
            Exhibit? exhibit = _exhibits.FirstOrDefault(compiledFilter);
            return Task.FromResult(exhibit);
        }

        public Task<Exhibit?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Exhibit, object>>[] includesProperties)
        {
            Exhibit? exhibit = _exhibits.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(exhibit);
        }

        public Task<IReadOnlyList<Exhibit>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<Exhibit>)_exhibits);
        }

        public Task<IReadOnlyList<Exhibit>> ListAsync(Expression<Func<Exhibit, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Exhibit, object>>[] includesProperties)
        {
            var compiledFilter = filter.Compile();
            var list = _exhibits.Where(compiledFilter).ToList();
            return Task.FromResult((IReadOnlyList<Exhibit>)list);
        }

        public Task UpdateAsync(Exhibit entity, CancellationToken cancellationToken = default)
        {
            var exhibit = _exhibits.FirstOrDefault(e => e.Id == entity.Id);
            if (exhibit != null)
            {
                exhibit.Name = entity.Name;
                exhibit.AppraisedValue = entity.AppraisedValue;
                exhibit.YearCreated = entity.YearCreated;
                exhibit.Material = entity.Material;
                exhibit.Artist = entity.Artist;
                exhibit.HallId = entity.HallId;
            }
            return Task.CompletedTask;
        }
    }
}
