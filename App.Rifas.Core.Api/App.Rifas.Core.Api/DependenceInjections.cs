using App.Rifas.Core.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

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
            #endregion

            #region REPOSITORIES
            #endregion

            #region SERVICES
            #endregion


        }
    }
}
