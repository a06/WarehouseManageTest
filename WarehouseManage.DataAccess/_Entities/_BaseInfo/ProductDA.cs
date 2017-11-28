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

    public interface IProductDA
    {
        //C
        Product Create();
        //R
        Product GetByID(int id);
        IEnumerable<Product> GetList(string where = "", string orderby = "");
        //U
        int Insert(Product toInsert, out int newID);
        int Update(Product original, Product toUpdate);
        //D
        int Delete(int id);
        int Delete(Product toDelete);
    }

    #endregion

    public class ProductDA : BaseDA<Product>, IProductDA
    {
        //--Constructor
        public ProductDA()
        {
            UPDATE_TABLE_NAME = "Products";
            PRIMARY_KEY = "ProductID";
            UPDATE_FIELDS = new List<string> { "ProductCode", "ProductName", "Unit", "IsDisable", "Description" };
            SELECT_TABLE_NAME = UPDATE_TABLE_NAME;
            SELECT_FIELDS = UPDATE_FIELDS;
        }

        protected override int getID(Product bill)
        {
            return bill.ProductID;
        }

        //C
        public override Product Create()
        {
            return new Product()
            {
                ProductID = 0,
                ProductCode = "",
                ProductName = "",
                Unit = "",
                IsDisable = false,
                Description = "",
            };
        }

        //R
        protected override Product getFromReader(IDataReader reader)
        {
            return new Product()
            {
                ProductID = Convert.ToInt32(reader["ProductID"]),
                ProductCode = Convert.ToString(reader["ProductCode"]),
                ProductName = Convert.ToString(reader["ProductName"]),
                Unit = Convert.ToString(reader["Unit"]),
                IsDisable = Convert.ToBoolean(reader["IsDisable"]),
                Description = Convert.ToString(reader["Description"]), //database allow null
            };
        }

        //U
        protected override IList<string> getUpdateFields(Product original, Product toUpdate)
        {
            var fields = new List<string>();

            if (!original.ProductCode.Equals(toUpdate.ProductCode)) { fields.Add("ProductCode"); }
            if (!original.ProductName.Equals(toUpdate.ProductName)) { fields.Add("ProductName"); }
            if (!original.Unit.Equals(toUpdate.Unit)) { fields.Add("Unit"); }
            if (!original.IsDisable.Equals(toUpdate.IsDisable)) { fields.Add("IsDisable"); }
            if (!original.Description.Equals(toUpdate.Description)) { fields.Add("Description"); }

            return fields;
        }
        protected override void fillParameters(SqlParameterCollection parameters, IList<string> fields, Product entity)
        {
            parameters.AddWithValue(toParam(PRIMARY_KEY), entity.ProductID);
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "ProductCode": parameters.AddWithValue(toParam(field), entity.ProductCode); break;
                    case "ProductName": parameters.AddWithValue(toParam(field), entity.ProductName); break;
                    case "Unit": parameters.AddWithValue(toParam(field), entity.Unit); break;
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

            sb.AppendLine("SELECT 1 FROM ProductItems WHERE ProductID=@ProductID")
                .AppendLine("UNION")
                .AppendLine("SELECT 1 FROM ProductReturnItems WHERE ProductID=@ProductID")
                .AppendLine("UNION")
                .AppendLine("SELECT 1 FROM ProductReturnItems WHERE ProductID=@ProductID")
                .AppendLine("UNION")
                .AppendLine("SELECT 1 FROM SaleItems WHERE ProductID=@ProductID")
                .AppendLine("UNION")
                .AppendLine("SELECT 1 FROM SaleReturnItems WHERE ProductID=@ProductID");

            var cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddWithValue("@ProductID", id);

            return SqlHelper.Exists(cmd);
        }
    }
}
