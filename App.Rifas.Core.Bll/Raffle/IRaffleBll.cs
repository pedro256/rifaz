using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel.Raffle;
using App.Rifas.Core.Mapping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.Raffle
{
    public interface IRaffleBll
    {

        RaffleVM create(CreateRaffleIM raffle);
        RaffleVM update(UpdateRaffleIM category);
        RaffleVM get(int id);
        bool delete(int id);
        PagedItems<RaffleVM> ListarPaginado(RafflePaginationIM query);

    }
}
