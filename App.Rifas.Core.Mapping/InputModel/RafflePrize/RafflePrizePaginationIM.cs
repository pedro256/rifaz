using App.Rifas.Core.Mapping.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.InputModel.RafflePrize
{
    public class RafflePrizePaginationIM : PagedOptions
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Position { get; set; }
        public int? WinnerId { get; set; }
        public int? RaffleId { get; set; }
    }
}
