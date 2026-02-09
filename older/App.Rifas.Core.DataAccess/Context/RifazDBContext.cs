using App.Rifas.Core.DataAccess.Entities.Base;
using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Raffle;
using App.Rifas.Core.DataAccess.Entities.RafflePrize;
using App.Rifas.Core.DataAccess.Entities.RaffleTickets;
using App.Rifas.Core.DataAccess.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Context
{
    public class RifazDBContext : DbContext
    {
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<CategoriesRaflleEntity> CategoriesRaflleEntity { get; set; }
        public DbSet<RaffleEntity> RaffleEntity { get; set; }
        public DbSet<RafflePrizeEntity> RafflePrizeEntity { get; set; }
        public DbSet<RaffleTicketsEntity> RaffleTicketsEntity { get; set; }



        public RifazDBContext(DbContextOptions<RifazDBContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }


        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
