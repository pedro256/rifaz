using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel.RafflePrize;
using App.Rifas.Core.Mapping.InputModel.RaffleTicket;
using App.Rifas.Core.Mapping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.RaffleTicket
{
    public interface IRaffleTicketBll
    {
        RaffleTicketVM CreateRaffleTicket(CreateRaffleTicketIM createRafflePrizeIM);
        RaffleTicketVM UpdateRaffleTicket(UpdateRaffleTicketIM updateRafflePrizeIM);
        RaffleTicketVM get(int id);
        bool delete(int id);

        PagedItems<RaffleTicketVM> ListarPaginado(RaffleTicketPaginationIM query);
    }
}
