using EFCoreGlobalFilter.BaseModel;
using System;
using System.Collections.Generic;

namespace EFCoreGlobalFilter.Model
{
    public partial class Supplier: BaseEntity
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
        }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
