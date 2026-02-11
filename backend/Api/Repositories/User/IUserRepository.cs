using Api.Entities;
using Api.Repositories.Generic;

namespace Api.Repositories.User;

public interface IUserRepository :IGenericRepository<UserEntity>
{
    UserEntity Create(UserEntity user);
    void Delete(UserEntity user);
    
}