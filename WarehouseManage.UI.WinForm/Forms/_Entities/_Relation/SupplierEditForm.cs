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
    public partial class SupplierEditForm : EditForm
    {
        protected Supplier Original { get; private set; }

        protected Supplier Current
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
        private Supplier _current;

        protected Supplier CopyEntity(Supplier toCopy)
        {
            return new Supplier()
            {
                SupplierID = toCopy.SupplierID,
                SupplierCode = toCopy.SupplierCode,
                SupplierName = toCopy.SupplierName,
                IsDisable = toCopy.IsDisable,
                Description = toCopy.Description,
            };
        }

        //--Constructor
        public SupplierEditForm()
        {
            InitializeComponent();

            this.Title = "供应商";

            txtSupplierCode.LabelText = "编号";
            txtSupplierName.LabelText = "供应商名称";
            txtDescription.LabelText = "备注";
            chkIsDisable.Text = "停用";

            txtSupplierCode.DataBindings.Add(new Binding("Text", bindingSource1, "SupplierCode", false));
            txtSupplierName.DataBindings.Add(new Binding("Text", bindingSource1, "SupplierName", false));
            txtDescription.DataBindings.Add(new Binding("Text", bindingSource1, "Description", false));
            chkIsDisable.DataBindings.Add(new Binding("CheckState", bindingSource1, "IsDisable", true));
        }

        protected override void InitLoad()
        {
            txtSupplierCode.TextChanged += this.DataChanged;
            txtSupplierName.TextChanged += this.DataChanged;
            txtDescription.TextChanged += this.DataChanged;
            chkIsDisable.CheckStateChanged += this.DataChanged;
        }

        protected override ResultMessage GetByID(int id)
        {
            var bl = new SupplierBL();
            this.Current = bl.GetByID(id);
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Create()
        {
            var bl = new SupplierBL();
            this.Current = bl.Create();
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Delete()
        {
            var bl = new SupplierBL();
            var rm = bl.Delete(this.Current);
            if (rm.Result == false)
            {
                Utility.ShowError(string.Format("{0}'{1}'{2}", this.Title, this.Current.SupplierName, rm.Message), this);
            }
            return rm;
        }

        protected override ResultMessage Save_Create()
        {
            var bl = new SupplierBL();
            int newID = 0;

            var rm = bl.Insert(this.Current, out newID);
            if (rm.Result)
            {
                this.Current.SupplierID = newID;
                this.Original = CopyEntity(this.Current);
            }

            return rm;
        }

        protected override ResultMessage Save_Update()
        {
            var bl = new SupplierBL();

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
            var result = txtSupplierName.Text == string.Empty;
            var message = string.Format("{0}未填写，不能保存", txtSupplierName.LabelText);
            if (result)
            {
                txtSupplierName.Focus();
                Utility.ShowError(message, this);
                return new ResultMessage(result, message);
            }

            var bl = new SupplierBL();
            return bl.CheckValid(this.Current);
        }
    }
}
