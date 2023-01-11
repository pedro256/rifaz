using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Entities.Users
{
    [Table("USER")]
    public class UserEntity
    {
        [Key]
        private int Id { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        private DateTime BirthDate { get; set; }
    }
}
