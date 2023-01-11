using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket
{
    public class CategoriesRaflleTicketEntity
    {
        [Key]
        public int Id { get; set; }   
        public string Name { get; set; } 
        public string Description { get; set; }
    }
}
