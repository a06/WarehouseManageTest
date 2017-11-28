using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.Common;
using WarehouseManage.Common.Entities;
using WarehouseManage.BusinessLogic;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class UserEditForm : EditForm
    {
        protected User Original { get; private set; }

        protected User Current
        {
            get { return _current; }
            set
            {
                if (value != null)
                {
                    _current = value;
                    bindingSource1.SuspendBinding();
                    bindingSource1.DataSource = value;
                    bindingSource1.ResumeBinding();
                }
            }
        }
        private User _current;

        protected User CopyEntity(User toCopy)
        {
            return new User()
            {
                UserID = toCopy.UserID,
                UserCode = toCopy.UserCode,
                UserName = toCopy.UserName,
                Passwd = toCopy.Passwd,
                IsDisable = toCopy.IsDisable,
                Description = toCopy.Description,
            };
        }

        //--Constructor
        public UserEditForm()
        {
            InitializeComponent();

            this.Title = "用户";
            txtUserCode.LabelText = "编号";
            txtUserName.LabelText = "名称";
            txtPasswd.LabelText = "密码";
            txtDescription.LabelText = "备注";
            chkIsDisable.Text = "停用";
        }

        protected override void InitLoad()
        {
            txtUserCode.DataBindings.Add(new Binding("Text", bindingSource1, "UserCode", false));
            txtUserName.DataBindings.Add(new Binding("Text", bindingSource1, "UserName", false));
            txtPasswd.DataBindings.Add(new Binding("Text", bindingSource1, "Passwd", false));
            txtDescription.DataBindings.Add(new Binding("Text", bindingSource1, "Description", false));
            chkIsDisable.DataBindings.Add(new Binding("CheckState", bindingSource1, "IsDisable", true));

            txtUserCode.TextChanged += this.DataChanged;
            txtUserName.TextChanged += this.DataChanged;
            txtPasswd.TextChanged += this.DataChanged;
            txtDescription.TextChanged += this.DataChanged;
            chkIsDisable.CheckStateChanged += this.DataChanged;
        }

        protected override ResultMessage GetByID(int id)
        {
            var bl = new UserBL();
            this.Current = bl.GetByID(id);
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Create()
        {
            var bl = new UserBL();
            this.Current = bl.Create();
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Delete()
        {
            var bl = new UserBL();
            return bl.Delete(this.Current);
        }

        protected override ResultMessage Save_Create()
        {
            var bl = new UserBL();
            int newID = 0;

            var rm = bl.Insert(this.Current, out newID);
            if (rm.Result)
            {
                this.Current.UserID = newID;
                this.Original = CopyEntity(this.Current);
            }

            return rm;
        }

        protected override ResultMessage Save_Update()
        {
            var bl = new UserBL();

            var rm = bl.Update(this.Original, this.Current);
            if (rm.Result)
            {
                this.Original = CopyEntity(this.Current);
            }

            return rm;
        }

        protected override ResultMessage Undo()
        {
            this.Current = CopyEntity(this.Original);

            var result = this.Current != null;
            var message = result ? "" : "";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage CheckValid()
        {
            ////var validateResults = Validation.Validate<User>(this.Entity);
            ////if (!validateResults.IsValid)
            ////{
            ////    foreach (var result in validateResults)
            ////    {
            ////        //if (result.Key == txbUserCode.DataBindings....BindingContext.ToString())
            ////        {
            ////            //errorProvider1.SetError(txbUserCode, result.Message);
            ////        }
            ////    }
            ////}

            var bl = new UserBL();
            return bl.CheckValid(this.Current);
        }
    }
}
