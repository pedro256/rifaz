using Api.DTO.InputModel;

namespace Api.Services.User;

public interface IUserService
{
    public Guid Cadastrar(UserCreateRequest ToCreate);
}