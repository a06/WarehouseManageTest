using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarehouseManage.Common.Entities;

namespace WarehouseManage.Common.Bills
{
    public class SaleReturnBill
    {
        public SaleReturnHead Head { get; set; }
        public IEnumerable<SaleReturnItem> Items { get; set; }
    }

    public class SaleReturnHead
    {
        public int SaleReturnID { get; set; }
        public DateTime BillDate { get; set; }
        public string BillCode { get; set; }
        public int SaleID { get; set; }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Sender { get; set; }
        public decimal SenderFee { get; set; }
        public string Receiver { get; set; }
        public decimal ReceiverFee { get; set; }
        public string Collecter { get; set; }
        public decimal CollecterFee { get; set; }

        public string VoucherCode { get; set; }
        public string Description { get; set; }
    }

    public class SaleReturnItem
    {
        public int SaleReturnItemID { get; set; }
        public int SaleReturnID { get; set; }
        public int SortID { get; set; }
        public int SaleItemID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
