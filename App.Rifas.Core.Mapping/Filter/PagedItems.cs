using System;
using System.Collections.Generic;
using System.Text;

namespace App.Rifas.Core.Mapping.Filters
{
    public class PagedItems<T>
    {
        public PagedItems()
        {
            Items = new List<T>();
            Total = 0;
        }
        public IList<T> Items { get; set; }
        public long? Total { get; set; }
    }
}
