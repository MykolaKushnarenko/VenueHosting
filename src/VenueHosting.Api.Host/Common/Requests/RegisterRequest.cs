namespace VenueHosting.Api.Host.Common.Requests;

public record RegisterRequest(
    string FirstName, 
    string LastName, 
    string Email, 
    string Password);
