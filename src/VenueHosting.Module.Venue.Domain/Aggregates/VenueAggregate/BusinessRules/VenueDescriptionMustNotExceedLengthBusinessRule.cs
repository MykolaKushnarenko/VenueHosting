using Component.Domain.BLSpecifications;
using VenueHosting.Module.Venue.Domain.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.BusinessRules;

internal sealed class VenueDescriptionMustNotExceedLengthBusinessRule : IBusinessRule
{
    private readonly string _description;

    private const int ExpectedLength = 100;

    public VenueDescriptionMustNotExceedLengthBusinessRule(string description)
    {
        _description = description;
    }

    public void CheckIfSatisfied()
    {
        if (_description.Length > ExpectedLength)
        {
            throw new VenueDescriptionExceedLengthException();
        }
    }
}