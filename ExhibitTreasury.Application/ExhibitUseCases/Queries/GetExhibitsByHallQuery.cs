namespace ExhibitTreasury.Application.ExhibitUseCases.Queries
{
    /// <summary>
    /// Запрос на получение экспонатов, принадлежащих залу с указанным идентификатором
    /// </summary>
    public sealed record GetExhibitsByHallQuery(int HallId) : IRequest<IEnumerable<Exhibit>>;
}
