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
        public virtual UserEntity? Winner { get; set; }
        public virtual RaffleEntity Raffle { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("NAME")]
        public string Name { get; set; }
        [Column("DESCRIPTION")]
        public string? Description { get; set; }
        [Column("POSITION")]
        public string Position { get; set; }

        [ForeignKey(nameof(Winner))]
        [Column("WINNER_ID")]
        public int? WinnerId { get; set; }

        [ForeignKey(nameof(Raffle))]
        [Column("RAFFLE_ID")]
        public int RaffleId { get; set; }
    }
}