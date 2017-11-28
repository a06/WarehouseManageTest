using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class User : BaseEntity
    {
        public int UserID { get; set; }

        //[StringLengthValidator(1, 200)]
        public string UserCode { get; set; }

        //[StringLengthValidator(1, 200)]
        public string UserName { get; set; }

        //[StringLengthValidator(1, 200)]
        public string Passwd { get; set; }

        //public int EmployeeID { get; set; }

    }
}
