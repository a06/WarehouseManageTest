using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class SalaryView
    {
        public int SalaryID { get; set; }
        public DateTime BillDate { get; set; }
        public string BillCode { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public decimal Amount { get; set; }
        public string VoucherCode { get; set; }
        public string Description { get; set; }
    }
}
