using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Attendee.Application;
using VenueHosting.Module.Attendee.Infrastructure.AtomicScope;
using VenueHosting.Module.Attendee.Infrastructure.Persistence;

namespace VenueHosting.Module.Attendee.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddAttendeeInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {
        // serviceCollection.AddScoped<IPlaceStore, PlaceStore>();
        // serviceCollection.AddScoped<IVenueStore, VenueStore>();

        //serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        serviceCollection.AddScoped<IAtomicScope, AtomicScope.AtomicScope>();

        serviceCollection.AddPersistence();

        return serviceCollection;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<AttendeeApplicationDbContext>(options =>
            options.UseSqlServer(
                "Data Source=(local);Initial Catalog=Local-Account-Main;User Id=SA;Password=Qwerty123$%;TrustServerCertificate=true;",
                builder => builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Attendee")));

        return serviceCollection;
    }
}