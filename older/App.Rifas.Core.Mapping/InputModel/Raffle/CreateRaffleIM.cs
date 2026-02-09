
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.InputModel.Raffle
{
    public class CreateRaffleIM
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
