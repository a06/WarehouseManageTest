﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class Product : BaseEntity
    {
        public int ProductID { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Unit { get; set; }

        public int CategoryID { get; set; }
    }
}
