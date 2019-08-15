using EFCoreGlobalFilter.BaseModel;
using System;
using System.Collections.Generic;

namespace EFCoreGlobalFilter.Model
{
    public partial class Product : BaseEntity, ExcludeDeleted
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
