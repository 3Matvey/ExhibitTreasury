namespace ExhibitTreasury.Application.HallUseCases.Queries
{
    // Запрос на получение списка всех залов
    public sealed record GetAllHallsQuery() 
        : IRequest<IEnumerable<Hall>>;
}
