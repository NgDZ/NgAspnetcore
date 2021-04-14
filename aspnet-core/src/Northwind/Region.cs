using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        [Column("EntityId")]
        public long Id { get; set; }
        public string Regiondescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
