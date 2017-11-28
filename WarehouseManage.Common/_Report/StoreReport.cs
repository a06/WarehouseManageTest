using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common
{
    public class StoreReport
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public decimal BeginSum { get; set; }
        public decimal PurchaseSum { get; set; }
        public decimal PurchaseReturnSum { get; set; }
        public decimal SaleSum { get; set; }
        public decimal SaleReturnSum { get; set; }
        public decimal EndSum { get; set; }
    }
}
