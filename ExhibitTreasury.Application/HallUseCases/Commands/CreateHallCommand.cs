namespace ExhibitTreasury.Application.HallUseCases.Commands
{
    /// <summary>
    /// Команда для создания зала: передаются имя и описание
    /// </summary>
    public sealed record CreateHallCommand(string Name, string Description) 
        : IRequest<Hall>;
}
