using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.InputModel.Raffle
{
    public class UpdateRaffleIM
    {
        string? Title { get; set; }
        string? Description { get; set; }
        int? CategoryId { get; set; }
    }
}
