using EFCoreGlobalFilter.BaseModel;
using System;
using System.Collections.Generic;

namespace EFCoreGlobalFilter.Model
{
    public partial class Customer: BaseEntity
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
