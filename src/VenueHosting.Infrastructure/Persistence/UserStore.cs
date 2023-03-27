using System.Collections.Concurrent;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Entities;

namespace VenueHosting.Infrastructure.Persistence;

public class UserStore : IUserStore
{
    private static readonly ConcurrentBag<User> Users = new();

    public User? GetByEmail(string email)
    {
        return Users.SingleOrDefault(x => x.Email == email);
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}