using ExhibitTreasury.Persistence.Data;

namespace ExhibitTreasury.Persistence.Repositories
{
    public class EfUnitOfWork(AppDbContext context) 
        : IUnitOfWork
    {
        private IRepository<Hall>? _hallRepository;
        private IRepository<Exhibit>? _exhibitRepository;
        private bool _disposed;

        public IRepository<Hall> HallRepository =>
            _hallRepository ??= new EfRepository<Hall>(context);

        public IRepository<Exhibit> ExhibitRepository =>
            _exhibitRepository ??= new EfRepository<Exhibit>(context);

        public async Task SaveAllAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task CreateDataBaseAsync()
        {
            await context.Database.EnsureCreatedAsync();
        }

        public async Task DeleteDataBaseAsync()
        {
            await context.Database.EnsureDeletedAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~EfUnitOfWork() 
            => Dispose(false);
    }
}
