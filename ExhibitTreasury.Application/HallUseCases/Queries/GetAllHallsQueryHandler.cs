namespace ExhibitTreasury.Application.HallUseCases.Queries
{
    public sealed class GetAllHallsQueryHandler(IUnitOfWork unitOfWork) 
        : IRequestHandler<GetAllHallsQuery, IEnumerable<Hall>>
    {
        //  все залы музея из репозитория
        public async Task<IEnumerable<Hall>> Handle(GetAllHallsQuery request, CancellationToken cancellationToken)
            => await unitOfWork.HallRepository.ListAllAsync(cancellationToken);
    }
}
