using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Entities.RAFFLETicket
{
    [Table("RAFFLE_TICKET")]
    public class RAFFLETicketEntity
    {
        [Key]
        [Column("ID")]
        private int Id { get; set; }
        [Column("TITLE")]
        private string Title { get; set; }
        [Column("PROTOCOL")]
        private string Protocol { get; set; }
        [Column("DESCRIPTION")]
        private string Description { get; set; }

        [ForeignKey(nameof(UserEntity))]
        [Column("OWNER_ID")]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(CategoriesRaflleTicketEntity))]
        [Column("CATEGORY_ID")]
        private int CategoryId { get; set; }
    }
}
