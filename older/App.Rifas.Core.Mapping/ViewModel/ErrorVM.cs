using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.ViewModel
{
    public class ErrorVM
    {
        public string Message { get; set; }
        public string? Details { get; set; }
    }
}
