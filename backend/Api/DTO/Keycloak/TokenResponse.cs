namespace Api.DTO.Keycloak;

public class TokenResponse
{
    public string Access_Token { get; set; } = default!;
    public string Refresh_Token { get; set; } = default!;
    public string Token_Type { get; set; } = default!;
    public int Expires_In { get; set; }
}