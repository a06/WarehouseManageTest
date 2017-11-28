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
    public partial class EmployeeEditForm : EditForm
    {
        protected Employee Original { get; private set; }

        protected Employee Current
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
        private Employee _current;

        protected Employee CopyEntity(Employee toCopy)
        {
            return new Employee()
            {
                EmployeeID = toCopy.EmployeeID,
                EmployeeCode = toCopy.EmployeeCode,
                EmployeeName = toCopy.EmployeeName,
                IsDisable = toCopy.IsDisable,
                Description = toCopy.Description,
            };
        }

        //--Constructor
        public EmployeeEditForm()
        {
            InitializeComponent();

            this.Title = "员工";

            txtEmployeeCode.LabelText = "编号";
            txtEmployeeName.LabelText = "员工名称";
            txtDescription.LabelText = "备注";
            chkIsDisable.Text = "停用";

            txtEmployeeCode.DataBindings.Add(new Binding("Text", bindingSource1, "EmployeeCode", false));
            txtEmployeeName.DataBindings.Add(new Binding("Text", bindingSource1, "EmployeeName", false));
            txtDescription.DataBindings.Add(new Binding("Text", bindingSource1, "Description", false));
            chkIsDisable.DataBindings.Add(new Binding("CheckState", bindingSource1, "IsDisable", true));
        }

        protected override void InitLoad()
        {
            txtEmployeeCode.TextChanged += this.DataChanged;
            txtEmployeeName.TextChanged += this.DataChanged;
            txtDescription.TextChanged += this.DataChanged;
            chkIsDisable.CheckStateChanged += this.DataChanged;
        }

        protected override ResultMessage GetByID(int id)
        {
            var bl = new EmployeeBL();
            this.Current = bl.GetByID(id);
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Create()
        {
            var bl = new EmployeeBL();
            this.Current = bl.Create();
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Delete()
        {
            var bl = new EmployeeBL();
            var rm = bl.Delete(this.Current);
            if (rm.Result == false)
            {
                Utility.ShowError(string.Format("{0}'{1}'{2}", this.Title, this.Current.EmployeeName, rm.Message), this);
            }

            return rm;
        }

        protected override ResultMessage Save_Create()
        {
            var bl = new EmployeeBL();
            int newID = 0;
            var rm = bl.Insert(this.Current, out newID);
            if (rm.Result)
            {
                this.Current.EmployeeID = newID;
                this.Original = CopyEntity(this.Current);
            }

            return rm;
        }

        protected override ResultMessage Save_Update()
        {
            var bl = new EmployeeBL();
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
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage CheckValid()
        {
            var result = string.IsNullOrEmpty(txtEmployeeName.Text);
            var message = result ? "" : string.Format("{0}未填写，不能保存", txtEmployeeName.LabelText);

            if (result)
            {
                txtEmployeeName.Focus();
                //Utility.ShowError(string.Format("{0}未填写，不能保存", txtEmployeeName.LabelText), this);
                return new ResultMessage(result, message);
            }

            var bl = new EmployeeBL();
            return bl.CheckValid(this.Current);
        }
    }
}
