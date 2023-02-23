using App.Rifas.Core.DataAccess.Context;
using App.Rifas.Core.DataAccess.Entities.RafflePrize;
using App.Rifas.Core.DataAccess.Entities.RaffleTickets;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.RaffleTicket
{
    public class RaffleTicketRepository : GenericRepository<RaffleTicketsEntity>, IRaffleTicketRepository
    {
        public RaffleTicketRepository(RifazDBContext context) : base(context)
        {
        }

        public RaffleTicketsEntity createTicket(RaffleTicketsEntity ticket)
        {
            Context.RaffleTicketsEntity.Add(ticket);
            Context.SaveChanges();
            return ticket;
        }

        public void deleteTicket(RaffleTicketsEntity ticket)
        {
            Context.RaffleTicketsEntity.Attach(ticket);
            Context.RaffleTicketsEntity.Remove(ticket);
            Context.SaveChanges();
        }

        public bool ExistsWithId(int Id)
        {
            int counter = Context.RaffleTicketsEntity.Count(x => x.Id == Id);
            return (counter > 0);
        }

        public RaffleTicketsEntity FindById(int Id)
        {
            RaffleTicketsEntity retorno = Context.RaffleTicketsEntity.Find(Id);
            return retorno;
        }

        public bool FindByTicketNumber(int raffleId, string Number)
        {
            var query = Context.RaffleTicketsEntity.Where(x => x.RaffleId == raffleId);
            query = query.Where(x => x.NumTicket == Number);
            return query.Any();
        }

        public RaffleTicketsEntity updateTicket(RaffleTicketsEntity ticket)
        {
            Context.RaffleTicketsEntity.Update(ticket);
            Context.SaveChanges();
            return ticket;
        }
    }
}
