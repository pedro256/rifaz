using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.ViewModel
{
    public class RaffleTicketVM
    {
        public int Id { get; set; }
        public string NumTicket { get; set; }
        public int UserId { get; set; }
        public int RaffleId { get; set; }
    }
}
