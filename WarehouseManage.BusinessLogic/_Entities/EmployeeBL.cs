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

    public interface IEmployeeBL
    {
        //C
        Employee Create();
        //R
        Employee GetByID(int id);
        IEnumerable<Employee> GetList(string where = "", string orderby = "");
        //U
        ResultMessage Insert(Employee toInsert, out int newID);
        ResultMessage Update(Employee original, Employee toUpdate);
        //D
        ResultMessage Delete(int id);
        ResultMessage Delete(Employee toDelete);
        //Other
        ResultMessage CheckValid(Employee toCheck);
    }

    #endregion

    public class EmployeeBL : BaseBL, IEmployeeBL
    {
        private readonly EmployeeDA _da;

        //--Constructor
        public EmployeeBL()
        {
            _da = new EmployeeDA();
        }

        //C
        public Employee Create()
        {
            return _da.Create();
        }

        //R
        public Employee GetByID(int id)
        {
            return _da.GetByID(id);
        }

        public IEnumerable<Employee> GetList(string where = "", string orderby = "")
        {
            return _da.GetList(where, orderby);
        }

        //U
        public ResultMessage Insert(Employee toInsert, out int newID)
        {
            var result = _da.Insert(toInsert, out newID) > 0;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        public ResultMessage Update(Employee original, Employee toUpdate)
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

        public ResultMessage Delete(Employee toDelete)
        {
            if (_da.IsInuse(toDelete.EmployeeID))
            {
                return new ResultMessage(false, "\r\n已经在单据中使用，不能删除。\r\n可以设为'停用'");
            }
            else if (_da.Delete(toDelete.EmployeeID) <= 0)
            {
                return new ResultMessage(false, "记录不存在");
            }

            return new ResultMessage(true, string.Empty);
        }

        //Other
        public virtual ResultMessage CheckValid(Employee toCheck)
        {
            var result = false;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }
    }
}
