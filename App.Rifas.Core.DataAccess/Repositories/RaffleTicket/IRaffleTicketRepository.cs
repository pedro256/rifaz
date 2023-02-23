using App.Rifas.Core.DataAccess.Entities.RafflePrize;
using App.Rifas.Core.DataAccess.Entities.RaffleTickets;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.RaffleTicket
{
    public interface IRaffleTicketRepository : IGenericRepository<RaffleTicketsEntity>
    {
        RaffleTicketsEntity createTicket(RaffleTicketsEntity ticket);
        RaffleTicketsEntity updateTicket(RaffleTicketsEntity ticket);
        void deleteTicket(RaffleTicketsEntity ticket);
        bool ExistsWithId(int Id);

        bool FindByTicketNumber(int raffleId, string Number);
        RaffleTicketsEntity FindById(int Id);
    }
}
