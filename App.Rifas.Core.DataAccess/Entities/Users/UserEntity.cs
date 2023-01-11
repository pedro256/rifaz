using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Entities.Users
{
    [Table("USERS")]
    public class UserEntity
    {
        [Key]
        [Column("ID")]
        private int Id { get; set; }
        [Column("NAME")]
        private string Name { get; set; }
        [Column("EMAIL")]
        private string Email { get; set; }
        [Column("PASSWORD")]
        private string Password { get; set; }
        [Column("BIRTH_DATE")]
        private DateTime BirthDate { get; set; }
    }
}
