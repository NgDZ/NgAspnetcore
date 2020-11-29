using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        public long EntityId { get; set; }
        public string TerritoryCode { get; set; }
        public string Territorydescription { get; set; }
        public long RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
