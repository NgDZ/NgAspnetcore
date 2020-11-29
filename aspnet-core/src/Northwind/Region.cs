using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public long EntityId { get; set; }
        public string Regiondescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
