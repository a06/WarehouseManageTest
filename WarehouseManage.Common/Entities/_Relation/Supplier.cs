using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class Supplier : BaseEntity
    {
        public int SupplierID { get; set; }

        //[StringLengthValidator(1, 200)]
        public string SupplierCode { get; set; }

        //[StringLengthValidator(1, 200)]
        public string SupplierName { get; set; }
    }
}
