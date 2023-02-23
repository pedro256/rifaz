using App.Rifas.Core.DataAccess.Context;
using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.RafflePrize;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using App.Rifas.Core.Mapping.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.RafflePrize
{
    public class RafflePrizeRepository : GenericRepository<RafflePrizeEntity>, IRafflePrizeRepository
    {
        public RafflePrizeRepository(RifazDBContext context) : base(context)
        {
            
        }

        public RafflePrizeEntity createRPrize(RafflePrizeEntity prize)
        {
            Context.RafflePrizeEntity.Add(prize);
            Context.SaveChanges();
            return prize;
        }

        public void deleteRPrize(RafflePrizeEntity prize)
        {
            Context.RafflePrizeEntity.Attach(prize);
            Context.RafflePrizeEntity.Remove(prize);
            Context.SaveChanges();
        }

        public bool ExistsWithId(int Id)
        {
            int counter = Context.RafflePrizeEntity.Count(x => x.Id == Id);
            return (counter > 0);
        }
        public RafflePrizeEntity FindById(int Id)
        {
            RafflePrizeEntity retorno = Context.RafflePrizeEntity.Find(Id);
            return retorno;
        }

        public RafflePrizeEntity updateRPrize(RafflePrizeEntity prize)
        {
            Context.RafflePrizeEntity.Update(prize);
            Context.SaveChanges();
            return prize;
        }
    }
}
