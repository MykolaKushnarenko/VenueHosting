using Component.Domain.Persistence.AtomicScope;
using MediatR;
using VenueHosting.Module.Place.Application.Common.Persistence;

namespace VenueHosting.Module.Place.Application.Features.Place.GetAllPlaces;

internal sealed class PlaceQueryHandler : IRequestHandler<PlaceQuery, IReadOnlyList<Domain.Place.Place>>
{
    private readonly IPlaceStore _placeStore;

    public PlaceQueryHandler(IPlaceStore placeStore)
    {
        _placeStore = placeStore;
    }

    public async Task<IReadOnlyList<Domain.Place.Place>> Handle(PlaceQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Domain.Place.Place> places = await _placeStore.FetchAllAsync();

        return places;
    }
}