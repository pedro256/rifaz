using Api.Data;
using Api.Entities;
using Api.Repositories.Generic;
using Api.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace Api;

public class DependenceInjections
{
    public static void Config(WebApplicationBuilder builder)
    {
        #region CONTEXTS
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        );
        #endregion
        
        
        #region ENTITIES
        builder.Services.AddScoped<IGenericRepository<UserEntity>, GenericRepository<UserEntity>>();
        #endregion

        #region REPOSITORIES
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        #endregion

        #region SERVICES
        #endregion

    }
}