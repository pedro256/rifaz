using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Raffle;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.Raffle
{
    public interface IRaffleRepository : IGenericRepository<RaffleEntity>
    {
        RaffleEntity CreateRaffle(RaffleEntity raffleEntity);
        RaffleEntity UpdateRaffle(RaffleEntity raffleEntity);
        bool DeleteRaffle(RaffleEntity raffleEntity);

        RaffleEntity findById(int Id);
    }
}
