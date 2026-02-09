using App.Rifas.Core.Mapping.InputModel.Auth;

namespace App.Rifas.Core.Api.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(AuthIM auth);
    }
}
