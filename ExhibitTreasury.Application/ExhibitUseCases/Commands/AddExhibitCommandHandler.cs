namespace ExhibitTreasury.Application.ExhibitUseCases.Commands
{
    public sealed class AddExhibitCommandHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<AddExhibitCommand, Exhibit>
    {
        public async Task<Exhibit> Handle(AddExhibitCommand request, CancellationToken cancellationToken)
        {
            var exhibit = new Exhibit
            {
                Name = request.Name,
                AppraisedValue = request.AppraisedValue,
                YearCreated = request.YearCreated,
                Material = request.Material,
                Artist = request.Artist,
                HallId = request.HallId
            };
            await unitOfWork.ExhibitRepository.AddAsync(exhibit, cancellationToken);

            await unitOfWork.SaveAllAsync();

            return exhibit;
        }
    }
}
