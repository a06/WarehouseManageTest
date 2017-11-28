using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class SaleSender : BaseEntity
    {
        public int SenderID { get; set; }

        public string SenderCode { get; set; }

        public string SenderName { get; set; }
    }
}
