using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class SaleCollecter : BaseEntity
    {
        public int CollecterID { get; set; }

        public string CollecterCode { get; set; }

        public string CollecterName { get; set; }
    }
}
