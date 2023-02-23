using App.Rifas.Core.DataAccess.Entities.Raffle;
using App.Rifas.Core.DataAccess.Entities.Users;
using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel.Raffle;
using App.Rifas.Core.Mapping.InputModel.RafflePrize;
using App.Rifas.Core.Mapping.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.RafflePrize
{
    public interface IRafflePrizeBll
    {
        RafflePrizeVM CreateRafflePrize(CreateRafflePrizeIM createRafflePrizeIM);
        RafflePrizeVM UpdateRafflePrize(UpdateRafflePrizeIM updateRafflePrizeIM);
        RafflePrizeVM get(int id);
        bool delete(int id);

        PagedItems<RafflePrizeVM> ListarPaginado(RafflePrizePaginationIM query);


    }
}
