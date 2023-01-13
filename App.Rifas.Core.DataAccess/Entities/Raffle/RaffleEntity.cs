using App.Rifas.Core.DataAccess.Entities.Base;
using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Entities.Raffle
{
    [Table("RAFFLE")]
    public class RaffleEntity : BaseEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TITLE")]
        public string Title { get; set; }
        [Column("PROTOCOL")]
        public string Protocol { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [ForeignKey(nameof(UserEntity))]
        [Column("OWNER_ID")]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(CategoriesRaflleEntity))]
        [Column("CATEGORY_ID")]
        public int CategoryId { get; set; }
    }
}
