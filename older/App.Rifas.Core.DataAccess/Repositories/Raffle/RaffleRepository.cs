using App.Rifas.Core.DataAccess.Context;
using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Raffle;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using App.Rifas.Core.DataAccess.Repositories.RaffleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.Raffle
{
    public class RaffleRepository : GenericRepository<RaffleEntity>, IRaffleRepository
    {
        public RaffleRepository(RifazDBContext db_dbContext) : base(db_dbContext)
        {
        }

        public RaffleEntity CreateRaffle(RaffleEntity raffleEntity)
        {
            Context.RaffleEntity.Add(raffleEntity);
            Context.SaveChanges();
            return raffleEntity;
        }

        public bool DeleteRaffle(RaffleEntity raffleEntity)
        {
            Context.RaffleEntity.Attach(raffleEntity);
            Context.RaffleEntity.Remove(raffleEntity);
            Context.SaveChanges();
            return true;
        }

        public RaffleEntity findById(int Id)
        {
            var response = Context.RaffleEntity.Find(Id);
            return response;
        }

        public RaffleEntity UpdateRaffle(RaffleEntity raffleEntity)
        {
            Context.RaffleEntity.Update(raffleEntity);
            Context.SaveChanges();
            return raffleEntity;
        }
    }
}
