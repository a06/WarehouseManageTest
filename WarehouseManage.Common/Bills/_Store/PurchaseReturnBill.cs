using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarehouseManage.Common.Entities;

namespace WarehouseManage.Common.Bills
{
    public class PurchaseReturnBill
    {
        public PurchaseReturnHead Head { get; set; }
        public IEnumerable<PurchaseReturnItem> Items { get; set; }
    }

    public class PurchaseReturnHead
    {
        public int PurchaseReturnID { get; set; }
        public DateTime BillDate { get; set; }
        public string BillCode { get; set; }
        public int PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string VoucherCode { get; set; }
        public string Description { get; set; }
    }

    public class PurchaseReturnItem
    {
        public int PurchaseReturnItemID { get; set; }
        public int PurchaseReturnID { get; set; }
        public int SortID { get; set; }
        public int PurchaseItemID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
