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

    public interface IStoreReportDA
    {
        //C
        //R
        StoreReport GetByID(int id);
        IEnumerable<StoreReport> GetList(string filters = "");
        IEnumerable<StoreReport> GetViews(string filters = "");
        //U
        //D
    }

    #endregion

    public class StoreReportDA : BaseReportDA<StoreReport>, IStoreReportDA
    {
        //--Constructor
        public StoreReportDA()
        {
            SELECT_SQL = "spStoreReport";
        }

        //C
        //R
        public override StoreReport GetByID(int id)
        {
            var sql = SELECT_SQL
                + "\r\n" + "WHERE h.PurchaseID = @PurchaseID";

            var cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@PurchaseID", id);

            return getSingle(cmd);
        }

        //public StoreReport GetHeadView(int id)
        //{
        //    var sql = SELECT_SQL
        //        + "\r\n" + "WHERE h.PurchaseID = @PurchaseID";

        //    var cmd = new SqlCommand(sql);
        //    cmd.Parameters.AddWithValue("@PurchaseID", id);

        //    var reader = SqlHelper.ExecuteReader(cmd);
        //    StoreReport single = null;
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

        public IEnumerable<StoreReport> GetViews(string filters = "")
        {
            var sql = SELECT_SQL;

            ////if (!string.IsNullOrEmpty(filters))
            ////    sql += "\r\n" + "WHERE " + filters;

            ////sql += "\r\n"
            ////    + "ORDER BY BillDate DESC, BillCode, SupplierName";

            var cmd = new SqlCommand(sql);

            var reader = SqlHelper.ExecuteReader(cmd);
            var list = new List<StoreReport>();
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
        protected override StoreReport getEntity(IDataReader reader)
        {
            return new StoreReport()
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
