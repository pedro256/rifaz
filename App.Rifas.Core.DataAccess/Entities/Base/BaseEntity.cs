using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Entities.Base
{
    public class BaseEntity
    {
        [Column("CREATED_AT")]
        public DateTime CreatedDate { get; set; }
        [Column("UPDATED_AT")]
        public DateTime UpdatedDate { get; set; }
    }
}