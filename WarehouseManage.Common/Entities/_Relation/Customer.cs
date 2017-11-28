using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class Customer : BaseEntity
    {
        public int CustomerID { get; set; }

        public string CustomerCode { get; set; }

        public string CustomerName { get; set; }

        public string AreaName { get; set; }
    }
}
