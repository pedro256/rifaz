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
using App.Rifas.Core.DataAccess.Repositories.RaffleCategory;
using App.Rifas.Core.Bll.RaffleCategory;
using App.Rifas.Core.DataAccess.Repositories.Raffle;
using App.Rifas.Core.Bll.Raffle;
using App.Rifas.Core.DataAccess.Repositories.RafflePrize;
using App.Rifas.Core.Bll.RafflePrize;
using App.Rifas.Core.DataAccess.Repositories.RaffleTicket;
using App.Rifas.Core.Bll.RaffleTicket;
using App.Rifas.Core.Api.Token;

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
            services.AddScoped<IRaffleCategoryRepository,RaffleCategoryRepository>();
            services.AddScoped<IRaffleRepository, RaffleRepository>();
            services.AddScoped<IRafflePrizeRepository, RafflePrizeRepository>();
            services.AddScoped<IRaffleTicketRepository,RaffleTicketRepository>();
            #endregion

            #region SERVICES
            services.AddScoped<IUserBll, UserBll>();
            services.AddScoped<IRaffleCategoryBll, RaflleCategoryBll>();
            services.AddScoped<IRaffleBll, RaffleBll>();
            services.AddScoped<IRafflePrizeBll, RafflePrizeBll>();
            services.AddScoped<IRaffleTicketBll, RaffleTicketsBll>();

            #endregion

            #region AUTHENTICATION
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            #endregion
        }
    }
}
