namespace ExhibitTreasury.Application.ExhibitUseCases.Commands
{
    /// <summary>
    /// Команда для добавления экспоната в зал
    /// </summary>
    public sealed record AddExhibitCommand(
         string Name,
         decimal AppraisedValue,
         int YearCreated,
         string Material,
         string Artist,
         int HallId
         ) : IRequest<Exhibit>;
}
