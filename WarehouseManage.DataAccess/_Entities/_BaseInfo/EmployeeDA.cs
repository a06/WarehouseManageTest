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

    public interface IEmployeeDA
    {
        //C
        Employee Create();
        //R
        Employee GetByID(int id);
        IEnumerable<Employee> GetList(string where = "", string orderby = "");
        //U
        int Insert(Employee toInsert, out int newID);
        int Update(Employee original, Employee toUpdate);
        //D
        int Delete(int id);
        int Delete(Employee toDelete);
    }

    #endregion

    public class EmployeeDA : BaseDA<Employee>, IEmployeeDA
    {
        //--Constructor
        public EmployeeDA()
        {
            UPDATE_TABLE_NAME = "Employees";
            PRIMARY_KEY = "EmployeeID";
            UPDATE_FIELDS = new List<string> { "EmployeeCode", "EmployeeName", "IsDisable", "Description" };
            SELECT_TABLE_NAME = UPDATE_TABLE_NAME;
            SELECT_FIELDS = UPDATE_FIELDS;
        }

        protected override int getID(Employee bill)
        {
            return bill.EmployeeID;
        }

        //C
        public override Employee Create()
        {
            return new Employee()
            {
                EmployeeID = 0,
                EmployeeCode = "",
                EmployeeName = "",
                IsDisable = false,
                Description = "",
            };
        }

        //R
        protected override Employee getFromReader(IDataReader reader)
        {
            return new Employee()
            {
                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                EmployeeCode = Convert.ToString(reader["EmployeeCode"]),
                EmployeeName = Convert.ToString(reader["EmployeeName"]),
                IsDisable = Convert.ToBoolean(reader["IsDisable"]),
                Description = Convert.ToString(reader["Description"]), //database allow null
            };
        }

        //U
        protected override IList<string> getUpdateFields(Employee original, Employee toUpdate)
        {
            var fields = new List<string>();

            if (!original.EmployeeCode.Equals(toUpdate.EmployeeCode)) { fields.Add("EmployeeCode"); }
            if (!original.EmployeeName.Equals(toUpdate.EmployeeName)) { fields.Add("EmployeeName"); }
            if (!original.IsDisable.Equals(toUpdate.IsDisable)) { fields.Add("IsDisable"); }
            if (!original.Description.Equals(toUpdate.Description)) { fields.Add("Description"); }

            return fields;
        }
        protected override void fillParameters(SqlParameterCollection parameters, IList<string> fields, Employee entity)
        {
            parameters.AddWithValue(toParam(PRIMARY_KEY), entity.EmployeeID);
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "EmployeeCode": parameters.AddWithValue(toParam(field), entity.EmployeeCode); break;
                    case "EmployeeName": parameters.AddWithValue(toParam(field), entity.EmployeeName); break;
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

            sb.AppendLine("SELECT 1 FROM Sales WHERE SaleID=@SaleID")
                .AppendLine("UNION")
                .AppendLine("SELECT 1 FROM SaleReturns WHERE SaleID=@SaleID");

            var cmd = new SqlCommand(sb.ToString());
            cmd.Parameters.AddWithValue("@SaleID", id);

            return SqlHelper.Exists(cmd);
        }
    }
}
