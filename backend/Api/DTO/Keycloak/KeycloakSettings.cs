namespace Api.DTO.Keycloak;

public class KeycloakSettings
{
    public string UrlBase { get; set; } = default!;
    public string Client_Id { get; set; } = default!;
    public string Client_Secret { get; set; } = default!;
    public string Realm {get;set;} = default!;
}
