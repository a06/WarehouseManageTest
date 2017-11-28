using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarehouseManage.Common.Entities;

namespace WarehouseManage.Common.Bills
{
    public class PurchaseBill
    {
        public int PurchaseID { get; set; }
        public DateTime BillDate { get; set; }
        public string BillCode { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string VoucherCode { get; set; }
        public string Description { get; set; }

        public IEnumerable<PurchaseItem> Items { get; set; }
    }

    public class PurchaseItem
    {
        public int PurchaseItemID { get; set; }
        public int PurchaseID { get; set; }
        public int SortID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
