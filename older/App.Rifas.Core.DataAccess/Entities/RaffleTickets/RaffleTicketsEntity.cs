using App.Rifas.Core.DataAccess.Entities.Base;
using App.Rifas.Core.DataAccess.Entities.Raffle;
using App.Rifas.Core.DataAccess.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Entities.RaffleTickets
{
    [Table("RAFFLE_TICKETS")]
    public class RaffleTicketsEntity : BaseEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NUM_TICKET")]
        public string NumTicket { get; set; }

        [ForeignKey(nameof(UserEntity))]
        [Column("USER_ID")]
        public int UserId { get; set; }

        [ForeignKey(nameof(RaffleEntity))]
        [Column("RAFFLE_ID")]
        public int RaffleId{ get; set; }   
    }
}
