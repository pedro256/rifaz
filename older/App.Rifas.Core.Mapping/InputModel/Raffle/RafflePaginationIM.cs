using App.Rifas.Core.Mapping.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.InputModel.Raffle
{
    public class RafflePaginationIM : PagedOptions
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? OwnerId { get; set; }
        public int? CategoryId { get; set; }
    }
}
