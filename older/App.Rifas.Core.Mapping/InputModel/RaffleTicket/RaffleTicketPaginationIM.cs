using App.Rifas.Core.Mapping.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.InputModel.RaffleTicket
{
    public class RaffleTicketPaginationIM: PagedOptions
    {
        public string NumTicket { get; set; }
        public int UserId { get; set; }
        public int RaffleId { get; set; }
    }
}
