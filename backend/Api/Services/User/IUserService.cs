using Api.DTO.InputModel;

namespace Api.Services.User;

public interface IUserService
{
    public Task<Guid> Cadastrar(UserCreateRequest ToCreate);
}