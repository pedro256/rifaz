namespace Api.Services.Keycloak;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Api.DTO.Keycloak;
using Microsoft.Extensions.Options;

public class KeycloakService :IKeycloakService
{
    private readonly HttpClient _httpClient;
    private readonly KeycloakSettings _settings;

    public KeycloakService(HttpClient httpClient, IOptions<KeycloakSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
    }

    private async Task<string> GetAdminTokenAsync()
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "client_id", _settings.Client_Id },
            { "client_secret", _settings.Client_Secret },
            { "grant_type", "client_credentials" }
        });

        var response = await _httpClient.PostAsync(
            $"{_settings.UrlBase}/realms/{_settings.Realm}/protocol/openid-connect/token",
            content);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var token = JsonSerializer.Deserialize<TokenResponse>(json,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return token!.Access_Token;
    }
    public async Task<HttpClient> GetHttpClientAsync()
    {
        var token = await GetAdminTokenAsync();


        // using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        // ILogger logger = factory.CreateLogger("Program");
        // logger.LogInformation("Token JWT :{tk}.", token);


        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
        return _httpClient;

    }

    public async Task<string> CreateUserAsync(string username, string email, string firstName, string lastName)
    {
        var _httpClient = await GetHttpClientAsync();
        var payload = new
        {
            username,
            email,
            firstName,
            lastName,
            enabled = true
        };

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(
            $"{_settings.UrlBase}/admin/realms/{_settings.Realm}/users",
            content);


        response.EnsureSuccessStatusCode();

        // O ID vem no header Location
        var location = response.Headers.Location?.ToString();
        return location?.Split("/").Last()!;
    }

    public async Task SetUserPasswordAsync( string userId, string password)
    {
        var httpClient = await GetHttpClientAsync();

        var payload = new
        {
            type = "password",
            value = password,
            temporary = false
        };

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json");

        var response = await httpClient.PutAsync(
            $"{_settings.UrlBase}/admin/realms/{_settings.Realm}/users/{userId}/reset-password",
            content);

        response.EnsureSuccessStatusCode();
    }

    

    public async Task UpdateUserAsync(string realm, string userId, string email, string firstName, string lastName)
    {
        var _httpClient = await GetHttpClientAsync();
        var payload = new
        {
            email,
            firstName,
            lastName
        };

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PutAsync(
            $"{_settings.UrlBase}/admin/realms/{realm}/users/{userId}",
            content);

        response.EnsureSuccessStatusCode();
    }

    public async Task<TokenResponse> LoginAsync( string username, string password)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "client_id", _settings.Client_Id },
            { "client_secret", _settings.Client_Secret },
            { "grant_type", "password" },
            { "username", username },
            { "password", password }
        });

        var response = await _httpClient.PostAsync(
            $"{_settings.UrlBase}/realms/{_settings.Realm}/protocol/openid-connect/token",
            content);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<TokenResponse>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}