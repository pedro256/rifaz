using Api.DTO.InputModel;
using Api.Entities;
using Api.Exceptions;
using Api.Repositories.User;

namespace Api.Services.User;

public class UserService :IUserService
{
    IUserRepository userRepository;
    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public Guid Cadastrar(UserCreateRequest ToCreate)
    {
        if (this.userRepository.ExistsEmail(ToCreate.Email))
        {
            throw new NotFoundException("Email já existe");
        }
        UserEntity user = new UserEntity();
        user.Name = ToCreate.FullName;
        user.Email = ToCreate.Email;
        user.CreatedAt = DateTime.UtcNow;
        user.KcId = Guid.NewGuid();
        user = this.userRepository.Create(user);
        return user.Id;
    }
}