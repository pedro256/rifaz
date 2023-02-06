using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.Model
{
    public interface RaffleModel
    {
        string Title { get; set; }
        string Description { get; set; }
        int OwnerId { get; set; }
        int CategoryId { get; set; }
    }
}
