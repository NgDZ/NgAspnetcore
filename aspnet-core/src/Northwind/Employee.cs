using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        [Column("EntityId")]
        public long Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public byte[] BirthDate { get; set; }
        public byte[] HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Extension { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Notes { get; set; }
        public long? MgrId { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
