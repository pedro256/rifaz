﻿using App.Rifas.Core.Mapping.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Mapping.ViewModel
{
    public class RaffleCategoryPaginationQueryVM: PagedOptions
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
