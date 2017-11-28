using System;
//using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
using System.Text;

using WarehouseManage.Common.Entities;

namespace WarehouseManage.DataAccess
{
    #region Interface

    public interface IUserDA
    {
        //C
        User Create();
        //R
        User GetByID(int id);
        IEnumerable<User> GetList(string where = "", string orderby = "");
        //U
        int Insert(User toInsert, out int newID);
        int Update(User original, User toUpdate);
        //D
        int Delete(int id);
        int Delete(User toDelete);
        //Other
        User GetByCode(string code);
    }
    
    #endregion

    public class UserDA : BaseDA<User>, IUserDA
    {
        //--Constructor
        public UserDA()
        {
            UPDATE_TABLE_NAME = "Users";
            PRIMARY_KEY = "UserID";
            UPDATE_FIELDS = new List<string> { "UserCode", "UserName", "Passwd", "IsDisable", "Description" };
            SELECT_TABLE_NAME = UPDATE_TABLE_NAME;
            SELECT_FIELDS = UPDATE_FIELDS;
        }

        protected override int getID(User bill)
        {
            return bill.UserID;
        }

        //C
        public override User Create()
        {
            return new User()
            {
                UserID = 0,
                UserCode = "",
                UserName = "",
                Passwd = "",
                IsDisable = false,
                Description = "",
            };
        }

        //R
        protected override User getFromReader(IDataReader reader)
        {
            return new User()
            {
                UserID = Convert.ToInt32(reader["UserID"]),
                UserCode = Convert.ToString(reader["UserCode"]),
                UserName = Convert.ToString(reader["UserName"]),
                Passwd = Convert.ToString(reader["Passwd"]),
                IsDisable = Convert.ToBoolean(reader["IsDisable"]),
                Description = Convert.ToString(reader["Description"]), //database allow null
            };
        }

        //U
        protected override IList<string> getUpdateFields(User original, User toUpdate)
        {
            var fields = new List<string>();

            if (!original.UserCode.Equals(toUpdate.UserCode)) { fields.Add("UserCode"); }
            if (!original.UserName.Equals(toUpdate.UserName)) { fields.Add("UserName"); }
            if (!original.Passwd.Equals(toUpdate.Passwd)) { fields.Add("Passwd"); }
            if (!original.IsDisable.Equals(toUpdate.IsDisable)) { fields.Add("IsDisable"); }
            if (!original.Description.Equals(toUpdate.Description)) { fields.Add("Description"); }

            return fields;
        }
        protected override void fillParameters(SqlParameterCollection parameters, IList<string> fields, User model)
        {
            parameters.AddWithValue(toParam(PRIMARY_KEY), model.UserID);
            foreach (var field in fields)
            {
                switch (field)
                {
                    case "UserCode": parameters.AddWithValue(toParam(field), model.UserCode); break;
                    case "UserName": parameters.AddWithValue(toParam(field), model.UserName); break;
                    case "Passwd": parameters.AddWithValue(toParam(field), model.Passwd); break;
                    case "IsDisable": parameters.AddWithValue(toParam(field), model.IsDisable); break;
                    case "Description": parameters.AddWithValue(toParam(field), model.Description); break;
                    default: break;
                }
            }
        }

        //Other
        public User GetByCode(string code)
        {
            var sql = getSelectSql("UserCode=@UserCode");
            var cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@UserCode", code);

            return getFromCmd(cmd);
        }

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
