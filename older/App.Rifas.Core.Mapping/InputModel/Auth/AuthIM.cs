using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.InputModel.Auth
{
    public class AuthIM
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [MinLength(5)]
        public string Password { get; set; }

        public string? Name { get; set; }
    }
}
