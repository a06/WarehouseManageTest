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

    public interface IPurchaseBillBL
    {
        //C
        PurchaseBill Create();
        //R
        PurchaseBill GetByID(int id);
        IEnumerable<PurchaseBill> GetList(string where = "", string orderby = "");
        IEnumerable<PurchaseItem> GetItemList(int id);
        //U
        ResultMessage Insert(PurchaseBill toInsert, out int newID);
        ResultMessage Update(PurchaseBill original, PurchaseBill toUpdate);
        //D
        ResultMessage Delete(PurchaseBill toDelete);
        //Other
        ResultMessage CheckValid(PurchaseBill toCheck);
    }

    #endregion

    public class PurchaseBillBL : BaseBL, IPurchaseBillBL
    {
        private readonly PurchaseBillDA _da;

        //--Constructor
        public PurchaseBillBL()
        {
            _da = new PurchaseBillDA();
        }

        //C
        public PurchaseBill Create()
        {
            return _da.Create();
        }

        //R
        public PurchaseBill GetByID(int id)
        {
            return _da.GetByID(id);
        }

        public IEnumerable<PurchaseBill> GetList(string where = "", string orderby = "")
        {
            return _da.GetList(where, orderby);
        }

        public IEnumerable<PurchaseItem> GetItemList(int id)
        {
            return _da.GetItemList(id);
        }

        //U
        public ResultMessage Insert(PurchaseBill toInsert, out int newID)
        {
            newID = 0;
            var rm = _checkBalanceDate(toInsert.BillDate);
            if (rm.Result)
            {
                rm.Result = _da.Insert(toInsert, out newID) > 0;
            }
            return rm;
        }

        public ResultMessage Update(PurchaseBill original, PurchaseBill toUpdate)
        {
            var rm = _checkBalanceDate(original.BillDate);
            if (rm.Result)
            {
                rm = _checkBalanceDate(toUpdate.BillDate);
                if (rm.Result)
                {
                    rm.Result = _da.Update(original, toUpdate) > 0;
                }
            }
            return rm;
        }

        //D
        public ResultMessage Delete(PurchaseBill toDelete)
        {
            var rm = _checkBalanceDate(toDelete.BillDate);
            if (rm.Result)
            {
                rm.Result = _da.Delete(toDelete) > 0;
            }
            return rm; 
        }

        //Other
        public ResultMessage CheckValid(PurchaseBill toCheck)
        {
            return new ResultMessage(true, "");
        }

        //Helper
        private ResultMessage _checkBalanceDate(DateTime date)
        {
            var rm = new ResultMessage(false, string.Empty);
            var balanceDate = _da.GetBalanceDate();
            if (date.Date > balanceDate.Date)
            {
                rm.Result = true;
            }
            else
            {
                rm.Message = "最后一次'库存结算'日期至" + balanceDate.Date.ToShortDateString()
                    + "\r\n" + "不能更改期间的数据。";
            }

            return rm;
        }
    }
}
