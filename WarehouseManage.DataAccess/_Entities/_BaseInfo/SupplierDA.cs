using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using WarehouseManage.Common.Entities;

namespace WarehouseManage.DataAccess
{
    #region Interface

    public interface ISupplierDA
    {
        //C
        Supplier Create();
        //R
        Supplier GetByID(int id);
        IEnumerable<Supplier> GetList(string where = "", string orderby = "");
        //U
        int Insert(Supplier toInsert, out int newID);
        int Update(Supplier original, Supplier toUpdate);
        //D
        int Delete(int id);
        int Delete(Supplier toDelete);
    }

    #endregion

    public class SupplierDA : BaseDA<Supplier>, ISupplierDA
    {
        //--Constructor
        public SupplierDA()
        {
            UPDATE_TABLE_NAME = "Suppliers";
            PRIMARY_KEY = "SupplierID";
            UPDATE_FIELDS = new List<string> { "SupplierCode", "SupplierName", "IsDisable", "Description" };
            SELECT_TABLE_NAME = UPDATE_TABLE_NAME;
            SELECT_FIELDS = UPDATE_FIELDS;
        }

        protected override int getID(Supplier bill)
        {
            return bill.SupplierID;
        }

        //C
        public override Supplier Create()
        {
            return new Supplier()
            {
                SupplierID = 0,
                SupplierCode = "",
                SupplierName = "",
                IsDisable = false,
                Description = "",
            };
        }

        //R
        protected override Supplier getFromReader(IDataReader reader)
        {
            return new Supplier()
            {
                SupplierID = Convert.ToInt32(reader["SupplierID"]),
                SupplierCode = Convert.ToString(reader["SupplierCode"]),
                SupplierName = Convert.ToString(reader["SupplierName"]),
                IsDisable = Convert.ToBoolean(reader["IsDisable"]),
                Description = Convert.ToString(reader["Description"]), //database allow null
            };
        }

        //U
        protected override IList<string> getUpdateFields(Supplier original, Supplier toUpdate)
        {
            var fields = new List<string>();

            if (!original.SupplierCode.Equals(toUpdate.SupplierCode)) { fields.Add("SupplierCode"); }
            if (!original.SupplierName.Equals(toUpdate.SupplierName)) { fields.Add("SupplierName"); }
            if (!original.IsDisable.Equals(toUpdate.IsDisable)) { fields.Add("IsDisable"); }
            if (!original.Description.Equals(toUpdate.Description)) { fields.Add("Description"); }

            return fields;
        }
        protected override void fillParameters(SqlParameterCollection parameters, IList<string> fields, Supplier entity)
        {
            parameters.AddWithValue(toParam(PRIMARY_KEY), entity.SupplierID);
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "SupplierCode": parameters.AddWithValue(toParam(field), entity.SupplierCode); break;
                    case "SupplierName": parameters.AddWithValue(toParam(field), entity.SupplierName); break;
                    case "IsDisable": parameters.AddWithValue(toParam(field), entity.IsDisable); break;
                    case "Description": parameters.AddWithValue(toParam(field), entity.Description); break;
                    default: break;
                }
            }
        }

        //Other
        public bool IsInuse(int id)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SELECT 1 FROM Purchases WHERE SupplierID=@SupplierID")
                .AppendLine("UNION")
                .AppendLine("SELECT 1 FROM PurchaseReturns WHERE SupplierID=@SupplierID");

            var cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddWithValue("@SupplierID", id);

            return SqlHelper.Exists(cmd);
        }
    }
}
