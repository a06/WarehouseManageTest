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

    public interface IProductBL
    {
        //C
        Product Create();
        //R
        Product GetByID(int id);
        IEnumerable<Product> GetList(string where = "", string orderby = "");
        //U
        ResultMessage Insert(Product toInsert, out int newID);
        ResultMessage Update(Product original, Product toUpdate);
        //D
        ResultMessage Delete(int id);
        ResultMessage Delete(Product toDelete);
        //Other
        ResultMessage CheckValid(Product toCheck);
    }

    #endregion

    public class ProductBL : BaseBL, IProductBL
    {
        private readonly ProductDA _da;

        //--Constructor
        public ProductBL()
        {
            _da = new ProductDA();
        }

        //C
        public Product Create()
        {
            return _da.Create();
        }

        //R
        public Product GetByID(int id)
        {
            return _da.GetByID(id);
        }

        public IEnumerable<Product> GetList(string where = "", string orderby = "")
        {
            return _da.GetList(where, orderby);
        }

        //U
        public ResultMessage Insert(Product toInsert, out int newID)
        {
            var result = _da.Insert(toInsert, out newID) > 0;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        public ResultMessage Update(Product original, Product toUpdate)
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

        public ResultMessage Delete(Product toDelete)
        {
            if (_da.IsInuse(toDelete.ProductID))
            {
                return new ResultMessage(false, "\r\n已经在单据中使用，不能删除。\r\n可以设为'停用'");
            }
            else if (_da.Delete(toDelete.ProductID) <= 0)
            {
                return new ResultMessage(false, "记录不存在");
            }

            return new ResultMessage(true, string.Empty);
        }

        //Other
        public virtual ResultMessage CheckValid(Product toCheck)
        {
            var result = true;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }
    }
}
