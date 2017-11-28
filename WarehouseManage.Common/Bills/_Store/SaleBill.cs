using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarehouseManage.Common.Entities;

namespace WarehouseManage.Common.Bills
{
    public class SaleBill
    {
        public SaleHead Head { get; set; }
        public IEnumerable<SaleItem> Items { get; set; }
    }

    public class SaleHead
    {
        public int SaleID { get; set; }
        public DateTime BillDate { get; set; }
        public string BillCode { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int SenderID1 { get; set; }
        public string SenderName1 { get; set; }
        public decimal SenderFee1 { get; set; }
        public int SenderID2 { get; set; }
        public string SenderName2 { get; set; }
        public decimal SenderFee2 { get; set; }
        public int SenderID3 { get; set; }
        public string SenderName3 { get; set; }
        public decimal SenderFee3 { get; set; }
        public string VoucherCode { get; set; }
        public string Description { get; set; }
    }

    public class SaleItem
    {
        public int SaleItemID { get; set; }
        public int SaleID { get; set; }
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
