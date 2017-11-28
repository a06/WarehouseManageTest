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
    public partial class CustomerEditForm : EditForm
    {
        protected Customer Original { get; private set; }

        protected Customer Current
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
        private Customer _current;

        protected Customer CopyEntity(Customer toCopy)
        {
            return new Customer()
            {
                CustomerID = toCopy.CustomerID,
                AreaName = toCopy.AreaName,
                CustomerCode = toCopy.CustomerCode,
                CustomerName = toCopy.CustomerName,
                IsDisable = toCopy.IsDisable,
                Description = toCopy.Description,
            };
        }

        //--Constructor
        public CustomerEditForm()
        {
            InitializeComponent();

            this.Title = "客户";

            cmbAreaName.LabelText = "区域";
            _getAreaNameItems();
            txtCustomerCode.LabelText = "编号";
            txtCustomerName.LabelText = "客户名称";
            txtDescription.LabelText = "备注";
            chkIsDisable.Text = "停用";

            cmbAreaName.DataBindings.Add(new Binding("Text", bindingSource1, "AreaName", false));
            txtCustomerCode.DataBindings.Add(new Binding("Text", bindingSource1, "CustomerCode", false));
            txtCustomerName.DataBindings.Add(new Binding("Text", bindingSource1, "CustomerName", false));
            txtDescription.DataBindings.Add(new Binding("Text", bindingSource1, "Description", false));
            chkIsDisable.DataBindings.Add(new Binding("CheckState", bindingSource1, "IsDisable", true));
        }

        private void _getAreaNameItems()
        {
            var bl = new CustomerBL();
            var list = bl.GetAreaNameList();
            foreach (var item in list)
            {
                cmbAreaName.Items.Add(item);
            }
        }

        protected override void InitLoad()
        {
            cmbAreaName.TextChanged += this.DataChanged;
            txtCustomerCode.TextChanged += this.DataChanged;
            txtCustomerName.TextChanged += this.DataChanged;
            txtDescription.TextChanged += this.DataChanged;
            chkIsDisable.CheckStateChanged += this.DataChanged;
        }

        protected override ResultMessage GetByID(int id)
        {
            var bl = new CustomerBL();
            this.Current = bl.GetByID(id);
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Create()
        {
            var bl = new CustomerBL();
            this.Current = bl.Create();
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Delete()
        {
            var bl = new CustomerBL();
            var rm = bl.Delete(this.Current);
            if (rm.Result == false)
            {
                Utility.ShowError(string.Format("{0}'{1}'{2}", this.Title, this.Current.CustomerName, rm.Message), this);
            }
            return rm;
        }

        protected override ResultMessage Save_Create()
        {
            var bl = new CustomerBL();
            int newID = 0;

            var rm = bl.Insert(this.Current, out newID);
            if (rm.Result)
            {
                this.Current.CustomerID = newID;
                this.Original = CopyEntity(this.Current);
            }

            return rm;
        }

        protected override ResultMessage Save_Update()
        {
            var bl = new CustomerBL();

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
            var result = txtCustomerName.Text == string.Empty;
            var message = result ? "" : string.Format("{0}未填写，不能保存", txtCustomerName.LabelText);
            if (result)
            {
                txtCustomerName.Focus();
                Utility.ShowError(message, this);
                return new ResultMessage(result, message);
            }

            var bl = new CustomerBL();
            return bl.CheckValid(this.Current);
        }

    }
}
