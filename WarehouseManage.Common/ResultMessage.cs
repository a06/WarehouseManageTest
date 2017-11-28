using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseManage.Common
{
    public class ResultMessage
    {
        public bool Result { get; set; }
        public string Message { get; set; }

        public ResultMessage(bool result, string message)
        {
            this.Result = result;
            this.Message = message;
        }
    }
}
