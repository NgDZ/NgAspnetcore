using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind
{
    public partial class EmployeeTerritory
    {
        [Column("EntityId")]
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string TerritoryCode { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory TerritoryCodeNavigation { get; set; }
    }
}
