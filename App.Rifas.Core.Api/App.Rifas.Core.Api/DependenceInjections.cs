using App.Rifas.Core.DataAccess.Context;
using App.Rifas.Core.DataAccess.Entities.Users;
using App.Rifas.Core.DataAccess.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using App.Rifas.Core.DataAccess.Entities.Raffle;
using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.RafflePrize;
using App.Rifas.Core.DataAccess.Entities.RaffleTickets;
using App.Rifas.Core.Bll.User;

namespace App.Rifas.Core.Api
{
    public class DependenceInjections
    {
        public static void Config(IServiceCollection services,IConfiguration configuration)
        {

            #region CONTEXTS

            services
                .AddDbContext<RifazDBContext>(op =>
                {
                    op.UseNpgsql(
                        configuration.GetConnectionString("MyCourseDB"),
                        x => x.MigrationsAssembly(typeof(RifazDBContext).Assembly.FullName)
                        );

                });


            #endregion

            #region TABLES/ENTITIES

            services.AddScoped<IGenericRepository<UserEntity>, GenericRepository<UserEntity>>();
            services.AddScoped<IGenericRepository<RaffleEntity>, GenericRepository<RaffleEntity>>();
            services.AddScoped<IGenericRepository<CategoriesRaflleEntity>, GenericRepository<CategoriesRaflleEntity>>();
            services.AddScoped<IGenericRepository<RafflePrizeEntity>, GenericRepository<RafflePrizeEntity>>();
            services.AddScoped<IGenericRepository<RaffleTicketsEntity>, GenericRepository<RaffleTicketsEntity>>();


            #endregion

            #region REPOSITORIES

            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region SERVICES
            services.AddScoped<IUserBll, UserBll>();
            #endregion


        }
    }
}
