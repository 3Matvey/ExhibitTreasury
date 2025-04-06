namespace ExhibitTreasury.Persistence.Fakes
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private IRepository<Hall>? _hallRepository;
        private IRepository<Exhibit>? _exhibitRepository;

        public IRepository<Hall> HallRepository => _hallRepository ??= new FakeHallRepository();

        public IRepository<Exhibit> ExhibitRepository => _exhibitRepository ??= new FakeExhibitRepository();

        public Task SaveAllAsync()
        {
            return Task.CompletedTask;
        }

        public Task CreateDataBaseAsync() => Task.CompletedTask;

        public Task DeleteDataBaseAsync() => Task.CompletedTask;

        public void Dispose()
        {
            // Фейковые репозитории не используют внешние ресурсы, поэтому ничего освобождать не нужно.
        }
    }
}
