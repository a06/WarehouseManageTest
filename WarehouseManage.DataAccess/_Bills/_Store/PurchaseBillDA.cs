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

    public interface IPurchaseBillDA
    {
        //C
        PurchaseBill Create();
        //R
        PurchaseBill GetByID(int id);
        IEnumerable<PurchaseBill> GetList(string where = "", string orderby = "");
        IEnumerable<PurchaseItem> GetItemList(int id);
        //U
        int Insert(PurchaseBill toInsert, out int newID);
        int Update(PurchaseBill original, PurchaseBill toUpdate);
        //D
        int Delete(int id);
        int Delete(PurchaseBill toDelete);
        //int Delete(string where);
    }

    #endregion

    public class PurchaseBillDA : BaseBillDA<PurchaseBill, PurchaseItem>, IPurchaseBillDA
    {
        //--Constructor
        public PurchaseBillDA()
        {
            SELECT_TABLE_NAME = "vPurchases";
            SELECT_FIELDS = new List<string> { "BillDate", "BillCode", "SupplierID", "SupplierName", "Description" };
            UPDATE_TABLE_NAME = "Purchases";
            UPDATE_FIELDS = new List<string> { "BillDate", "BillCode", "SupplierID", "Description" };
            PRIMARY_KEY = "PurchaseID";

            ITEM_SELECT_TABLE_NAME = "vPurchaseItems";
            ITEM_SELECT_FIELDS = new List<string> { "PurchaseID", "SortID", "ProductID", "ProductName", "Unit", "UnitPrice", "Quantity", "Amount", "Description" };
            ITEM_UPDATE_TABLE_NAME = "PurchaseItems";
            ITEM_UPDATE_FIELDS = new List<string> { "PurchaseID", "SortID", "ProductID", "UnitPrice", "Quantity", "Description" };
            ITEM_PRIMARY_KEY = "PurchaseItemID";
        }


        protected override int getID(PurchaseBill bill)
        {
            return bill.PurchaseID;
        }
        protected override int getItemID(PurchaseItem item)
        {
            return item.PurchaseItemID;
        }
        protected override IEnumerable<PurchaseItem> getItems(PurchaseBill bill)
        {
            return bill.Items;
        }

        //C
        public override PurchaseBill Create()
        {
            return new PurchaseBill()
            {
                PurchaseID = 0,
                BillDate = DateTime.Now,
                BillCode = "",
                SupplierID = 0,
                SupplierName = "",
                Description = "",

                Items = new List<PurchaseItem>(),
            };
        }

        //R
        protected override PurchaseBill getFromReader(IDataReader reader, bool isWithItems = true)
        {
            return new PurchaseBill()
            {
                PurchaseID = Convert.ToInt32(reader["PurchaseID"]),
                BillDate = Convert.ToDateTime(reader["BillDate"]),
                BillCode = Convert.ToString(reader["BillCode"]),
                SupplierID = Convert.ToInt32(reader["SupplierID"]),
                SupplierName = Convert.ToString(reader["SupplierName"]),
                Description = Convert.ToString(reader["Description"]), //database allow null

                Items = isWithItems ? GetItemList(Convert.ToInt32(reader["PurchaseID"])) : null,
            };
        }
        protected override PurchaseItem getItemFromReader(IDataReader reader)
        {
            return new PurchaseItem
            {
                PurchaseItemID = Convert.ToInt32(reader["PurchaseItemID"]),
                PurchaseID = Convert.ToInt32(reader["PurchaseID"]),
                SortID = Convert.ToInt32(reader["SortID"]),
                ProductID = Convert.ToInt32(reader["ProductID"]),
                ProductName = Convert.ToString(reader["ProductName"]),
                Unit = Convert.ToString(reader["Unit"]),
                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                Quantity = Convert.ToDecimal(reader["Quantity"]),
                Amount = Convert.ToDecimal(reader["Amount"]),
                Description = Convert.ToString(reader["Description"]), //database allow null
            };
        }

        //U
        protected override IList<string> getUpdateFields(PurchaseBill original, PurchaseBill toUpdate)
        {
            var fields = new List<string>();

            if (!original.BillDate.Equals(toUpdate.BillDate)) { fields.Add("BillDate"); }
            if (!original.BillCode.Equals(toUpdate.BillCode)) { fields.Add("BillCode"); }
            if (!original.SupplierID.Equals(toUpdate.SupplierID)) { fields.Add("SupplierID"); }
            if (!original.Description.Equals(toUpdate.Description)) { fields.Add("Description"); }

            return fields;
        }
        protected override IList<string> getItemUpdateFields(PurchaseItem original, PurchaseItem toUpdate)
        {
            var fields = new List<string>();

            if (!original.PurchaseID.Equals(toUpdate.PurchaseID)) { fields.Add("PurchaseID"); }
            if (!original.SortID.Equals(toUpdate.SortID)) { fields.Add("SortID"); }
            if (!original.ProductID.Equals(toUpdate.ProductID)) { fields.Add("ProductID"); }
            if (!original.UnitPrice.Equals(toUpdate.UnitPrice)) { fields.Add("UnitPrice"); }
            if (!original.Quantity.Equals(toUpdate.Quantity)) { fields.Add("Quantity"); }
            if (!original.Description.Equals(toUpdate.Description)) { fields.Add("Description"); }

            return fields;
        }
        protected override void fillParameters(SqlParameterCollection parameters, IList<string> fields, PurchaseBill bill)
        {
            parameters.AddWithValue(toParam(PRIMARY_KEY), bill.PurchaseID);
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "BillDate": parameters.AddWithValue(toParam(field), bill.BillDate); break;
                    case "BillCode": parameters.AddWithValue(toParam(field), bill.BillCode); break;
                    case "SupplierID": parameters.AddWithValue(toParam(field), bill.SupplierID); break;
                    case "Description": parameters.AddWithValue(toParam(field), bill.Description); break;
                    default: break;
                }
            }
        }
        protected override string getItemInsertValues(IList<string> fields, PurchaseItem item)
        {
            var sb = new StringBuilder();

            foreach (var field in fields)
            {
                addComma(sb);
                switch (field)
                {
                    case "PurchaseID": sb.Append("@").Append(PRIMARY_KEY); break;
                    case "SortID": sb.Append(item.SortID); break;
                    case "ProductID": sb.Append(item.ProductID); break;
                    case "UnitPrice": sb.Append(item.UnitPrice); break;
                    case "Quantity": sb.Append(item.Quantity); break;
                    case "Description": sb.Append("'").Append(item.Description).Append("'"); break;
                    default: break;
                }
            }

            return sb.ToString();
        }
        protected override string getItemUpdateValues(IList<string> fields, PurchaseItem item)
        {
            var sb = new StringBuilder();

            foreach (var field in fields)
            {
                addComma(sb);
                sb.Append(field).Append("=");
                switch (field)
                {
                    case "PurchaseID": sb.Append(item.PurchaseID); break;
                    case "SortID": sb.Append(item.SortID); break;
                    case "ProductID": sb.Append(item.ProductID); break;
                    case "UnitPrice": sb.Append(item.UnitPrice); break;
                    case "Quantity": sb.Append(item.Quantity); break;
                    case "Description": sb.Append("'").Append(item.Description).Append("'"); break;
                    default: break;
                }
            }

            return sb.ToString();
        }

        //--Override

        //Other
        public DateTime GetBalanceDate()
        {
            var sql = "SELECT dbo.GetBalanceDate('STOREBALANCE')";
            var cmd = new SqlCommand(sql);
            return Convert.ToDateTime(SqlHelper.ExecuteScalar(cmd));
        }

    }
}
