using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    public class Employee : BaseEntity
    {
        public int EmployeeID { get; set; }

        //[StringLengthValidator(1, 200)]
        public string EmployeeCode { get; set; }

        //[StringLengthValidator(1, 200)]
        public string EmployeeName { get; set; }

        public int DepartmentID { get; set; }
    }
}
