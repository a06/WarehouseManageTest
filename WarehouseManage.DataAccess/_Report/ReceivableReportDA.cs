using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using WarehouseManage.Common;
using WarehouseManage.Common.Bills;
using WarehouseManage.Common.Entities;

namespace WarehouseManage.DataAccess
{
    #region Interface

    public interface IReceivableReportDA
    {
        //C
        //R
        ReceivableReport GetByID(int id);
        IEnumerable<ReceivableReport> GetList(string filters = "");
        IEnumerable<ReceivableReport> GetViews(string filters = "");
        //U
        //D
    }

    #endregion

    public class ReceivableReportDA : BaseReportDA<ReceivableReport>, IReceivableReportDA
    {
        //--Constructor
        public ReceivableReportDA()
        {
            SELECT_SQL = "spReceivableReport";
        }

        //C
        //R
        public override ReceivableReport GetByID(int id)
        {
            var sql = SELECT_SQL
                + "\r\n" + "WHERE h.PurchaseID = @PurchaseID";

            var cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@PurchaseID", id);

            return getSingle(cmd);
        }

        //public ReceivableReport GetHeadView(int id)
        //{
        //    var sql = SELECT_SQL
        //        + "\r\n" + "WHERE h.PurchaseID = @PurchaseID";

        //    var cmd = new SqlCommand(sql);
        //    cmd.Parameters.AddWithValue("@PurchaseID", id);

        //    var reader = SqlHelper.ExecuteReader(cmd);
        //    ReceivableReport single = null;
        //    try
        //    {
        //        if (reader.Read())
        //        {
        //            single = getEntity(reader);
        //        }
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //    return single;
        //}

        public IEnumerable<ReceivableReport> GetViews(string filters = "")
        {
            var sql = SELECT_SQL;

            ////if (!string.IsNullOrEmpty(filters))
            ////    sql += "\r\n" + "WHERE " + filters;

            ////sql += "\r\n"
            ////    + "ORDER BY BillDate DESC, BillCode, SupplierName";

            var cmd = new SqlCommand(sql);

            var reader = SqlHelper.ExecuteReader(cmd);
            var list = new List<ReceivableReport>();
            try
            {
                while (reader.Read())
                {
                    list.Add(getEntity(reader));
                }
            }
            finally
            {
                reader.Close();
            }
            return list;
        }

        //U
        //D
        //Other
        public DateTime GetBalanceDate()
        {
            var sql = "SELECT dbo.GetBalanceDate('STOREBALANCE')";
            var cmd = new SqlCommand(sql);
            return Convert.ToDateTime(SqlHelper.ExecuteScalar(cmd));
        }

        //--Override
        protected override ReceivableReport getEntity(IDataReader reader)
        {
            return new ReceivableReport()
            {
                ProductID = Convert.ToInt32(reader["ProductID"]),
                ProductName = Convert.ToString(reader["ProductName"]),
                Unit = Convert.ToString(reader["Unit"]),
                BeginSum = Convert.ToDecimal(reader["BeginSum"]),
                PurchaseSum = Convert.ToDecimal(reader["PurchaseSum"]),
                PurchaseReturnSum = Convert.ToDecimal(reader["PurchaseReturnSum"]),
                SaleSum = Convert.ToDecimal(reader["SaleSum"]),
                SaleReturnSum = Convert.ToDecimal(reader["SaleReturnSum"]),
                EndSum = Convert.ToDecimal(reader["EndSum"]),
            };
        }

    }
}
