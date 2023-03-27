using ErrorOr;

namespace VenueHosting.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict("User.DuplicateEmail", "Email already exists.");
    }
}