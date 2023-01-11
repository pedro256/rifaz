using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Entities.RaffleTicket
{
    [Table("RAFFLE_TICKET")]
    public class RaffleTicketEntity
    {
        [Key]
        private int Id { get; set; }
        private string Title { get; set; }
        private string Protocol { get; set; }
        private string Description { get; set; }

        [ForeignKey(nameof(UserEntity))]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(CategoriesRaflleTicketEntity))]
        private int CategoryId { get; set; }
    }
}
