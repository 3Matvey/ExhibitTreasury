namespace ExhibitTreasury.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Entities.Hall> HallRepository { get; }
        IRepository<Entities.Exhibit> ExhibitRepository { get; }
        Task SaveAllAsync();
        Task CreateDataBaseAsync();
        Task DeleteDataBaseAsync();
    }
}
