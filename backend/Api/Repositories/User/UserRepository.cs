using Api.Data;
using Api.Entities;
using Api.Repositories.Generic;

namespace Api.Repositories.User;

public class UserRepository :GenericRepository<UserEntity>,IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public UserEntity Create(UserEntity user)
    {
        Context.Users.Add(user);
        Context.SaveChanges();
        return user;
    }

    public void Delete(UserEntity user)
    {
        Context.Users.Attach(user);
        Context.Users.Remove(user);
        Context.SaveChanges();
    }

    public UserEntity GetByEmail(string email)
    {
       return Context.Users.Where(u => u.Email==email).First();
    }

    public bool ExistsEmail(string email)
    {
        return Context.Users.Where(u => u.Email==email).Count()>0;
    }
}