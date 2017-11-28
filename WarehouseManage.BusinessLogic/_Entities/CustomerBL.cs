using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarehouseManage.Common;
using WarehouseManage.Common.Entities;
using WarehouseManage.Common.Bills;
using WarehouseManage.DataAccess;

namespace WarehouseManage.BusinessLogic
{
    #region Interface

    public interface ICustomerBL
    {
        //C
        Customer Create();
        //R
        Customer GetByID(int id);
        IEnumerable<Customer> GetList(string where = "", string orderby = "");
        //U
        ResultMessage Insert(Customer toInsert, out int newID);
        ResultMessage Update(Customer original, Customer toUpdate);
        //D
        ResultMessage Delete(int id);
        ResultMessage Delete(Customer toDelete);
        //Other
        ResultMessage CheckValid(Customer toCheck);
    }

    #endregion

    public class CustomerBL : BaseBL, ICustomerBL
    {
        private readonly CustomerDA _da;

        //--Constructor
        public CustomerBL()
        {
            _da = new CustomerDA();
        }

        //C
        public Customer Create()
        {
            return _da.Create();
        }

        //R
        public Customer GetByID(int id)
        {
            return _da.GetByID(id);
        }

        public IEnumerable<Customer> GetList(string where = "", string orderby = "")
        {
            return _da.GetList(where, orderby);
        }

        //U
        public ResultMessage Insert(Customer toInsert, out int newID)
        {
            var result = _da.Insert(toInsert, out newID) > 0;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        public ResultMessage Update(Customer original, Customer toUpdate)
        {
            var result = _da.Update(original, toUpdate) > 0;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        //D
        public ResultMessage Delete(int id)
        {
            if (_da.IsInuse(id))
            {
                return new ResultMessage(false, "\r\n已经在单据中使用，不能删除。\r\n可以设为'停用'");
            }
            else if (_da.Delete(id) <= 0)
            {
                return new ResultMessage(false, "记录不存在");
            }

            return new ResultMessage(true, string.Empty);
        }

        public ResultMessage Delete(Customer toDelete)
        {
            if (_da.IsInuse(toDelete.CustomerID))
            {
                return new ResultMessage(false, "\r\n已经在单据中使用，不能删除。\r\n可以设为'停用'");
            }
            else if (_da.Delete(toDelete.CustomerID) <= 0)
            {
                return new ResultMessage(false, "记录不存在");
            }

            return new ResultMessage(true, string.Empty);
        }

        //Other
        public virtual ResultMessage CheckValid(Customer toCheck)
        {
            var result = false;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        public IList<string> GetAreaNameList()
        {
            return _da.GetAreaNameList();
        }
    }
}
