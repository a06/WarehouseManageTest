using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class SaleReceiver : BaseEntity
    {
        public int ReceiverID { get; set; }

        public string ReceiverCode { get; set; }

        public string ReceiverName { get; set; }
    }
}
