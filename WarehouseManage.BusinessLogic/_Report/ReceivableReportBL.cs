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

    public interface IReceivableReportBL
    {
        //C
        //R
        ReceivableReport GetByID(int id);
        IEnumerable<ReceivableReport> GetList(string filters = "");
        IEnumerable<ReceivableReport> GetViews(string filters = "");
        //U
        //D
        //Other
    }

    #endregion

    public class ReceivableReportBL : /*BaseBL,*/ IReceivableReportBL
    {
        private readonly ReceivableReportDA _da;

        //--Constructor
        public ReceivableReportBL()
        {
            _da = new ReceivableReportDA();
        }

        //C
        //R
        public ReceivableReport GetByID(int id)
        {
            return new ReceivableReport()
            {
                //HeadView = _da.GetHeadView(id),
                //ItemViews = _da.GetItemViews(id),
            };
        }

        public IEnumerable<ReceivableReport> GetList(string filters = "")
        {
            return _da.GetList(filters);
        }

        public virtual IEnumerable<ReceivableReport> GetViews(string filters = "")
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
