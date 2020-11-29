using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind
{
    public partial class EmployeeTerritory
    {
        public long EntityId { get; set; }
        public long EmployeeId { get; set; }
        public string TerritoryCode { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory TerritoryCodeNavigation { get; set; }
    }
}
