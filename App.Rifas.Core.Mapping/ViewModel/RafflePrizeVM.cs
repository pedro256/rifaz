using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.ViewModel
{
    public class RafflePrizeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int? WinnerId { get; set; }
        public int RaffleId { get; set; }

        public WinnerPrizeVM Winner { get; set; }
    }

    public class WinnerPrizeVM
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
