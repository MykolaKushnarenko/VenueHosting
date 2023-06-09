using VenueHosting.Module.Attendee.Domain.Attendee.ValueObjects;
using VenueHosting.Module.Attendee.Domain.AttendeeReview.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Attendee.Domain.Attendee;

public class Attendee : AggregateRote<AttendeeId, Guid>
{
    private List<AttendeeReviewId> _attendeeReviewIds = new();
    private List<BillId> _billIds = new();
    private List<ReservationId> _reservationIds = new();
    private List<VenueId> _venueIds = new();

    private Attendee()
    {
    }

    private Attendee(AttendeeId id, UserId userId) : base(id)
    {
        UserId = userId;
    }

    public UserId UserId { get; private set; }

    public IReadOnlyList<AttendeeReviewId> AttendeeReviewIds => _attendeeReviewIds.AsReadOnly();

    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.AsReadOnly();

    public IReadOnlyList<VenueId> VenueIds => _venueIds.AsReadOnly();

    public static Attendee Create(UserId userId)
    {
        return new Attendee(AttendeeId.CreateUnique(), userId);
    }
}