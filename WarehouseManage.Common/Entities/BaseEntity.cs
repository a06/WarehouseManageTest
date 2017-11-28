using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common.Entities
{
    //public enum EntityIsDisable
    //{
    //    Enable = 1,
    //    Disable = -1,
    //    All = 0,
    //}

    public abstract class BaseEntity
    {
        public bool IsDisable { get; set; }
        public string Description { get; set; }
    }
}
