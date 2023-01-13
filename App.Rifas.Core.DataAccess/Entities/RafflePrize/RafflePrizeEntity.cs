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

namespace App.Rifas.Core.DataAccess.Entities.RafflePrize
{
    [Table("RAFFLE_PRIZERS")]
    public class RafflePrizeEntity : BaseEntity
    {

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("POSITION")]
        public string Position { get; set; }

        [ForeignKey(nameof(UserEntity))]
        [Column("WINNER_ID")]
        public int WinnerId { get; set; }

        [ForeignKey(nameof(RaffleEntity))]
        [Column("RAFFLE_ID")]
        public int RaffleId { get; set; }
    }
}