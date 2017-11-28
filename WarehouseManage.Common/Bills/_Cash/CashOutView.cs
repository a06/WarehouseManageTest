using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class CashOutView
    {
        public int CashOutID { get; set; }
        public DateTime BillDate { get; set; }
        public string BillCode { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public decimal Amount { get; set; }
        public string VoucherCode { get; set; }
        public string Description { get; set; }
    }
}
