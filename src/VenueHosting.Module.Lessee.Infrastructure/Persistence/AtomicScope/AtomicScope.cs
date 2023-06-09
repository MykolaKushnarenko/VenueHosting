using MediatR;
using VenueHosting.Module.Lessee.Application;

namespace VenueHosting.Module.Lessee.Infrastructure.Persistence.AtomicScope;

internal sealed class AtomicScope : IAtomicScope
{
    private readonly LesseeApplicationDbContext _dbContext;
    private readonly IPublisher _publisher;

    public AtomicScope(LesseeApplicationDbContext dbContext, IPublisher publisher)
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