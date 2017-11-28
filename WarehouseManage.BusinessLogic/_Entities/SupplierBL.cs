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

    public interface ISupplierBL
    {
        //C
        Supplier Create();
        //R
        Supplier GetByID(int id);
        IEnumerable<Supplier> GetList(string where = "", string orderby = "");
        //U
        ResultMessage Insert(Supplier toInsert, out int newID);
        ResultMessage Update(Supplier original, Supplier toUpdate);
        //D
        ResultMessage Delete(int id);
        ResultMessage Delete(Supplier toDelete);
        //Other
        ResultMessage CheckValid(Supplier toCheck);
    }

    #endregion

    public class SupplierBL : BaseBL, ISupplierBL
    {
        private readonly SupplierDA _da;

        //--Constructor
        public SupplierBL()
        {
            _da = new SupplierDA();
        }

        //C
        public Supplier Create()
        {
            return _da.Create();
        }

        //R
        public Supplier GetByID(int id)
        {
            return _da.GetByID(id);
        }

        public IEnumerable<Supplier> GetList(string where = "", string orderby = "")
        {
            return _da.GetList(where, orderby);
        }

        //U
        public ResultMessage Insert(Supplier toInsert, out int newID)
        {
            var result = _da.Insert(toInsert, out newID) > 0;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        public ResultMessage Update(Supplier original, Supplier toUpdate)
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

        public ResultMessage Delete(Supplier toDelete)
        {
            if (_da.IsInuse(toDelete.SupplierID))
            {
                return new ResultMessage(false, "\r\n已经在单据中使用，不能删除。\r\n可以设为'停用'");
            }
            else if (_da.Delete(toDelete.SupplierID) <= 0)
            {
                return new ResultMessage(false, "记录不存在");
            }

            return new ResultMessage(true, string.Empty);
        }

        //Other
        public virtual ResultMessage CheckValid(Supplier toCheck)
        {
            var result = false;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }
    }
}
