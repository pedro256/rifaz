using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.ViewModel
{
    public class RaffleVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Protocol { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public int CategoryId { get; set; }
    }
}
