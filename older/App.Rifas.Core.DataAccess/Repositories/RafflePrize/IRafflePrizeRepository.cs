using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.RafflePrize;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.RafflePrize
{
    public interface IRafflePrizeRepository : IGenericRepository<RafflePrizeEntity>
    {
        RafflePrizeEntity createRPrize(RafflePrizeEntity prize);
        RafflePrizeEntity updateRPrize(RafflePrizeEntity prize);
        void deleteRPrize(RafflePrizeEntity prize);
        bool ExistsWithId(int Id);
        RafflePrizeEntity FindById(int Id);
    }
}
