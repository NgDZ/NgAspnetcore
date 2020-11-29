using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long EntityId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
