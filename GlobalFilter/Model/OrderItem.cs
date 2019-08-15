using EFCoreGlobalFilter.BaseModel;
using System;
using System.Collections.Generic;

namespace EFCoreGlobalFilter.Model
{
    public partial class OrderItem: BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
