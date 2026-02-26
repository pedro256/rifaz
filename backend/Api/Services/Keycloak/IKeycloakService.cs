using Api.DTO.Keycloak;

namespace Api.Services.Keycloak;


public interface IKeycloakService
{
    public Task<string> CreateUserAsync(string username, string email, string firstName, string lastName);
    //  Task<string> CreateUserAsync(string realm, string username, string email, string firstName, string lastName);
    // Task SetUserPasswordAsync(string realm, string userId, string password);
    // Task<TokenResponse> LoginAsync(string realm, string username, string password);
    // Task UpdateUserAsync(string realm, string userId, string email, string firstName, string lastName);
}