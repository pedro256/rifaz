using App.Rifas.Core.DataAccess.Entities.Base;
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
    public class UserEntity : BaseEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Column("BIRTH_DATE")]
        public DateTime BirthDate { get; set; }
    }
}
