using MediatR;
using VenueHosting.Infrastructure.Persistence;
using VenueHosting.Module.User.Application;

namespace VenueHosting.Module.User.Infrastructure.Persistence.AtomicScope;

internal sealed class AtomicScope : IAtomicScope
{
    private readonly UserApplicationDbContext _dbContext;
    private readonly IPublisher _publisher;

    public AtomicScope(UserApplicationDbContext dbContext, IPublisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    public async Task CommitAsync(CancellationToken token)
    {
        //Dispatch all domain events before commiting a transaction.
        //await _publisher.DispatchEventsAsync(_dbContext);

        await _dbContext.SaveChangesAsync(token);
    }
}