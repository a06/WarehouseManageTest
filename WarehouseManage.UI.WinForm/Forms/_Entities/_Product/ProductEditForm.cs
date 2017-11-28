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
    public partial class ProductEditForm : EditForm
    {
        protected Product Original { get; private set; }

        protected Product Current
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
        private Product _current;

        protected Product CopyEntity(Product toCopy)
        {
            return new Product()
            {
                ProductID = toCopy.ProductID,
                ProductCode = toCopy.ProductCode,
                ProductName = toCopy.ProductName,
                Unit = toCopy.Unit,
                IsDisable = toCopy.IsDisable,
                Description = toCopy.Description,
            };
        }

        //--Constructor
        public ProductEditForm()
        {
            InitializeComponent();

            this.Title = "商品";

            txtProductCode.LabelText = "编号";
            txtProductName.LabelText = "商品名称";
            txtUnit.LabelText = "单位";
            txtDescription.LabelText = "备注";
            chkIsDisable.Text = "停用";

            txtProductCode.DataBindings.Add(new Binding("Text", bindingSource1, "ProductCode", false));
            txtProductName.DataBindings.Add(new Binding("Text", bindingSource1, "ProductName", false));
            txtUnit.DataBindings.Add(new Binding("Text", bindingSource1, "Unit", false));
            txtDescription.DataBindings.Add(new Binding("Text", bindingSource1, "Description", false));
            chkIsDisable.DataBindings.Add(new Binding("CheckState", bindingSource1, "IsDisable", true));
        }

        protected override void InitLoad()
        {
            txtProductCode.TextChanged += this.DataChanged;
            txtProductName.TextChanged += this.DataChanged;
            txtUnit.TextChanged += this.DataChanged;
            txtDescription.TextChanged += this.DataChanged;
            chkIsDisable.CheckStateChanged += this.DataChanged;
        }

        protected override ResultMessage GetByID(int id)
        {
            var bl = new ProductBL();
            this.Current = bl.GetByID(id);
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Create()
        {
            var bl = new ProductBL();
            this.Current = bl.Create();
            this.Original = CopyEntity(this.Current);

            var result = this.Current != null;
            var message = result ? "" : "err";

            return new ResultMessage(result, message);
        }

        protected override ResultMessage Delete()
        {
            var bl = new ProductBL();
            var rm = bl.Delete(this.Current);
            if (rm.Result == false)
            {
                Utility.ShowError(string.Format("{0}'{1}'{2}", this.Title, this.Current.ProductName, rm.Message), this);
            }
            return rm;
        }

        protected override ResultMessage Save_Create()
        {
            var bl = new ProductBL();
            int newID = 0;

            var rm = bl.Insert(this.Current, out newID);
            if (rm.Result)
            {
                this.Current.ProductID = newID;
                this.Original = CopyEntity(this.Current);
            }

            return rm;
        }

        protected override ResultMessage Save_Update()
        {
            var bl = new ProductBL();

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
            var result = false;
            var message = "";

            if (txtProductName.Text == "")
            {
                message = string.Format("{0}未填写，不能保存", txtProductName.LabelText);
                txtProductName.Focus();
                return new ResultMessage(false, message);
            }
            if (txtUnit.Text == "")
            {
                message = string.Format("{0}未填写，不能保存", txtUnit.LabelText);
                txtUnit.Focus();
                return new ResultMessage(result, message);
            }

            var bl = new ProductBL();
            return bl.CheckValid(this.Current);
        }
    }
}
