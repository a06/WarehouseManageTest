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

    public interface IStoreReportBL
    {
        //C
        //R
        StoreReport GetByID(int id);
        IEnumerable<StoreReport> GetList(string filters = "");
        IEnumerable<StoreReport> GetViews(string filters = "");
        //U
        //D
        //Other
    }

    #endregion

    public class StoreReportBL : /*BaseBL,*/ IStoreReportBL
    {
        private readonly StoreReportDA _da;

        //--Constructor
        public StoreReportBL()
        {
            _da = new StoreReportDA();
        }

        //C
        //R
        public StoreReport GetByID(int id)
        {
            return new StoreReport()
            {
                //HeadView = _da.GetHeadView(id),
                //ItemViews = _da.GetItemViews(id),
            };
        }

        public IEnumerable<StoreReport> GetList(string filters = "")
        {
            return _da.GetList(filters);
        }

        public virtual IEnumerable<StoreReport> GetViews(string filters = "")
        {
            return _da.GetViews(filters);
        }

        //U
        //D
        //Other

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
