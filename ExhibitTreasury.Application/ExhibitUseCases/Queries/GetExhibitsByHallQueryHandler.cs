namespace ExhibitTreasury.Application.ExhibitUseCases.Queries
{
    public sealed class GetExhibitsByHallQueryHandler(IUnitOfWork unitOfWork) 
        : IRequestHandler<GetExhibitsByHallQuery, IEnumerable<Exhibit>>
    {
        /// <summary>
        /// Фильтруем экспонаты по HallId
        /// </summary>
        public async Task<IEnumerable<Exhibit>> Handle(GetExhibitsByHallQuery request, CancellationToken cancellationToken)
            => await unitOfWork.ExhibitRepository.ListAsync(e => e.HallId == request.HallId, cancellationToken);
    }
}
