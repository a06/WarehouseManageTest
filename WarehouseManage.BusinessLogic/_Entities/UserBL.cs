using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarehouseManage.Common;
using WarehouseManage.Common.Entities;
using WarehouseManage.DataAccess;

namespace WarehouseManage.BusinessLogic
{
    #region Interface

    public interface IUserBL
    {
        //C
        User Create();
        //R
        User GetByID(int id);
        IEnumerable<User> GetList(string where = "", string orderby = "");
        //U
        ResultMessage Insert(User toInsert, out int newID);
        ResultMessage Update(User original, User toUpdate);
        //D
        ResultMessage Delete(int id);
        ResultMessage Delete(User toDelete);
        //Other
        ResultMessage Login(string userCode, string passwd);
        ResultMessage Logout(string userCode);
        ResultMessage ChangePasswd(User original, User toChangePasswd, string oldPasswd, string newPasswd);
    }
    
    #endregion

    public class UserBL : BaseBL, IUserBL
    {
        private readonly UserDA _da;

        //--Constructor
        public UserBL()
        {
            _da = new UserDA();
        }

        //C
        public User Create()
        {
            return _da.Create();
        }

        //R
        public User GetByID(int id)
        {
            return _da.GetByID(id);
        }

        public IEnumerable<User> GetList(string where = "", string orderby = "")
        {
            return _da.GetList(where, orderby);
        }

        //U
        public ResultMessage Insert(User toInsert, out int newID)
        {
            //newID = 0;
            var result = _da.Insert(toInsert, out newID) > 0;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        public ResultMessage Update(User original, User toUpdate)
        {
            var result = _da.Update(original, toUpdate) > 0;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        //D
        public ResultMessage Delete(int id)
        {
            var result = true;
            var message = "";

            result = _da.IsInuse(id);
            if (result == false)
            {
                message = result ? "" : "\r\n已经在单据中使用，不能删除。\r\n可以设为'停用'";
                return new ResultMessage(result, message);
            }

            result = _da.Delete(id) <= 0;
            if (result == false)
            {
                message = result ? "" : "记录不存在";
                return new ResultMessage(result, message);
            }

            return new ResultMessage(result, message);
        }

        public ResultMessage Delete(User toDelete)
        {
            var result = true;
            var message = "";

            result = _da.Delete(toDelete.UserID) > 0;
            if (result == false)
            {
                message = result ? "" : "err";
                return new ResultMessage(result, message);
            }

            return new ResultMessage(result, message);
        }

        //Other
        public ResultMessage CheckValid(User toCheck)
        {
            var result = false;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        public ResultMessage Login(string userCode, string passwd)
        {
            var user = _da.GetByCode(userCode);

            var result = (user != null
                && user.IsDisable == false
                && user.Passwd.ToUpper() == passwd.ToUpper()
                );

            var message = result ? "" : "错误的用户名或密码";

            return new ResultMessage(result, message);
        }

        public ResultMessage Logout(string userCode)
        {
            var result = false;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        public ResultMessage ChangePasswd(User original, User toChangePasswd, string oldPasswd, string newPasswd)
        {
            var result = true;
            var message = "";

            result = toChangePasswd.Passwd == original.Passwd;
            if (result == false)
            {
                var rm = this.Update(original, toChangePasswd);
                if (rm.Result)
                {
                    toChangePasswd.Passwd = newPasswd;
                }

                return rm;
            }

            return new ResultMessage(result, message);
        }
    }
}
