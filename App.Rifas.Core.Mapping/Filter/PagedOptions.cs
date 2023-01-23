using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rifas.Core.Mapping.Filters
{
    public class PagedOptions
    {
        public int? Page { get; set; } = 1;
        public bool Reverse { get; set; }
        public int? Size { get; set; } = 10;
        public string Sort { get; set; }
        /// <summary>
        /// Limite de registros na busca
        /// </summary>
        public int? RegLimited { get; set; }
        public IEnumerable<SortOptions>? SortManny { get; set; }
    }
}
