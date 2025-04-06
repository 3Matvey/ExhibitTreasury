namespace ExhibitTreasury.Application.HallUseCases.Commands
{
    public sealed class CreateHallCommandHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<CreateHallCommand, Hall>
    {
        public async Task<Hall> Handle(CreateHallCommand request, CancellationToken cancellationToken)
        {
            // Создаем новый зал
            var hall = new Hall
            {
                Name = request.Name,
                Description = request.Description,
                Exhibits = []
            };

            // Добавляем зал через репозиторий и сохраняем изменения
            await unitOfWork.HallRepository.AddAsync(hall, cancellationToken);
            await unitOfWork.SaveAllAsync();

            return hall;
        }
    }
}
