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

    public interface ICustomerDA
    {
        //C
        Customer Create();
        //R
        Customer GetByID(int id);
        IEnumerable<Customer> GetList(string where = "", string orderby = "");
        //U
        int Insert(Customer toInsert, out int newID);
        int Update(Customer original, Customer toUpdate);
        //D
        int Delete(int id);
        int Delete(Customer toDelete);
    }

    #endregion

    public class CustomerDA : BaseDA<Customer>, ICustomerDA
    {
        //--Constructor
        public CustomerDA()
        {
            UPDATE_TABLE_NAME = "Customers";
            PRIMARY_KEY = "CustomerID";
            UPDATE_FIELDS = new List<string> { "CustomerCode", "CustomerName", "AreaName", "IsDisable", "Description" };
            SELECT_TABLE_NAME = UPDATE_TABLE_NAME;
            SELECT_FIELDS = UPDATE_FIELDS;
        }

        protected override int getID(Customer bill)
        {
            return bill.CustomerID;
        }

        //C
        public override Customer Create()
        {
            return new Customer()
            {
                CustomerID = 0,
                CustomerCode = "",
                CustomerName = "",
                AreaName = "",
                IsDisable = false,
                Description = "",
            };
        }

        //R
        protected override Customer getFromReader(IDataReader reader)
        {
            return new Customer()
            {
                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                CustomerCode = Convert.ToString(reader["CustomerCode"]),
                CustomerName = Convert.ToString(reader["CustomerName"]),
                AreaName = Convert.ToString(reader["AreaName"]),
                IsDisable = Convert.ToBoolean(reader["IsDisable"]),
                Description = Convert.ToString(reader["Description"]), //database allow null
            };
        }

        //U
        protected override IList<string> getUpdateFields(Customer original, Customer toUpdate)
        {
            var fields = new List<string>();

            if (!original.CustomerCode.Equals(toUpdate.CustomerCode)) { fields.Add("CustomerCode"); }
            if (!original.CustomerName.Equals(toUpdate.CustomerName)) { fields.Add("CustomerName"); }
            if (!original.AreaName.Equals(toUpdate.AreaName)) { fields.Add("AreaName"); }
            if (!original.IsDisable.Equals(toUpdate.IsDisable)) { fields.Add("IsDisable"); }
            if (!original.Description.Equals(toUpdate.Description)) { fields.Add("Description"); }

            return fields;
        }
        protected override void fillParameters(SqlParameterCollection parameters, IList<string> fields, Customer entity)
        {
            parameters.AddWithValue(toParam(PRIMARY_KEY), entity.CustomerID);
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "CustomerCode": parameters.AddWithValue(toParam(field), entity.CustomerCode); break;
                    case "CustomerName": parameters.AddWithValue(toParam(field), entity.CustomerName); break;
                    case "AreaName": parameters.AddWithValue(toParam(field), entity.AreaName); break;
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

            sb.AppendLine("SELECT * FROM Sales WHERE CustomerID=@CustomerID")
                .AppendLine("UNION")
                .AppendLine("SELECT * FROM SaleReturns WHERE CustomerID=@CustomerID");

            var cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddWithValue("@CustomerID", id);

            return SqlHelper.Exists(cmd);
        }

        public IList<string> GetAreaNameList()
        {
            var sql = "SELECT DISTINCT(AreaName) AS AreaName FROM Customers ORDER BY AreaName";

            var cmd = new SqlCommand(sql);
            var reader = SqlHelper.ExecuteReader(cmd);

            var result = new List<string>();
            try
            {
                while (reader.Read())
                {
                    result.Add(Convert.ToString(reader["AreaName"]));
                }
            }
            finally
            {
                reader.Close();
            }

            return result;
        }
    }
}
