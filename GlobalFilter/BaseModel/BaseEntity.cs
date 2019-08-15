using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreGlobalFilter.BaseModel
{
    public interface ExcludeDeleted
    {

    }

    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
