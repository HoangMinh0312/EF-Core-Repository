using EFCoreGlobalFilter.BaseModel;
using System;
using System.Collections.Generic;

namespace EFCoreGlobalFilter.Model
{
    public partial class Order: BaseEntity
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
