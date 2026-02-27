using System.Threading.Tasks;
using Api.DTO.InputModel;
using Api.Entities;
using Api.Exceptions;
using Api.Repositories.User;
using Api.Services.Keycloak;
using Microsoft.Extensions.Logging;



namespace Api.Services.User;

public class UserService :IUserService
{
    IUserRepository userRepository;
    IKeycloakService keycloakService;
    public UserService(IUserRepository userRepository,IKeycloakService keycloakService)
    {
        this.userRepository = userRepository;
        this.keycloakService = keycloakService;
    }

    public async Task<Guid> Cadastrar(UserCreateRequest ToCreate)
    {
        if (this.userRepository.ExistsEmail(ToCreate.Email))
        {
            throw new NotFoundException("Email já existe");
        }
        UserEntity user = new UserEntity();
        user.Name = ToCreate.FullName;
        user.Email = ToCreate.Email;
        user.CreatedAt = DateTime.UtcNow;
        var IdKeycloak = await this.keycloakService.CreateUserAsync(user.Email,user.Email,user.Name,"");
        await this.keycloakService.SetUserPasswordAsync(IdKeycloak,ToCreate.Password);
        user.KcId = Guid.Parse(IdKeycloak);
        user = this.userRepository.Create(user);
      
        

        return user.Id;
    }
}