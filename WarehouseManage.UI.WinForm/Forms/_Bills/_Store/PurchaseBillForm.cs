using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.BusinessLogic;
using WarehouseManage.Common;
using WarehouseManage.Common.Bills;
using WarehouseManage.Common.Entities;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class PurchaseBillForm : BillForm
    {
        protected PurchaseBill Original { get; private set; }

        protected PurchaseBill Current
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

                    bindingSource2.SuspendBinding();
                    bindingSource2.DataSource = value.Items;
                    dataGridView2.DataSource = bindingSource2;
                    bindingSource2.ResumeBinding();
                }
            }
        }
        private PurchaseBill _current;

        protected PurchaseBill CopyBill(PurchaseBill toCopy)
        {
            var list = new List<PurchaseItem>();
            foreach (var item in toCopy.Items)
            {
                list.Add(new PurchaseItem()
                {
                    PurchaseItemID = item.PurchaseItemID,
                    PurchaseID = item.PurchaseID,
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Unit = item.Unit,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    Description = item.Description,
                });
            }

            return new PurchaseBill()
            {
                PurchaseID = toCopy.PurchaseID,
                BillDate = toCopy.BillDate,
                BillCode = toCopy.BillCode,
                SupplierID = toCopy.SupplierID,
                SupplierName = toCopy.SupplierName,
                Description = toCopy.Description,

                Items = list,
            };
        }

        //--Constructor
        public PurchaseBillForm()
        {
            InitializeComponent();

            this.Title = "进货单";
            dtpBillDate.LabelText = "日期";
            txtBillCode.LabelText = "单号";
            txtSupplier.LabelText = "供应商";
            txtSupplier.ReadOnly = true;
            txtDescription.LabelText = "备注";

            dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
            dataGridView2.ButtonClickHandler += new EventHandler(dataGridView2_ButtonClick);
            dataGridView2.ShowButtonColumns = new List<string> { "colProductName" };
        }

        void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var colName = dataGridView2.Columns[e.ColumnIndex].Name;
            if (colName == "colUnitPrice" || colName == "colQuantity")
            {
                var row = dataGridView2.Rows[e.RowIndex];
                var unitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);
                var quantity = Convert.ToDecimal(row.Cells["colQuantity"].Value);

                row.Cells["colAmount"].Value = unitPrice * quantity;
            }
        }

        void dataGridView2_ButtonClick(object sender, EventArgs e)
        {
            var f = new ProductSelectForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                var rowIndex = dataGridView2.SelectedCells[0].RowIndex;

                if (rowIndex == dataGridView2.NewRowIndex)
                {
                    dataGridView2.DataSource = null;
                    bindingSource2.Add(new PurchaseItem()
                    {
                        ProductID = f.SelectedItem.ProductID,
                        ProductName = f.SelectedItem.ProductName,
                        Unit = f.SelectedItem.Unit,
                    });
                    dataGridView2.DataSource = bindingSource2;
                }
                else if (bindingSource2.Current is PurchaseItem)
                {
                    var itemView = (bindingSource2.Current as PurchaseItem);
                    itemView.ProductID = f.SelectedItem.ProductID;
                    itemView.ProductName = f.SelectedItem.ProductName;
                    itemView.Unit = f.SelectedItem.Unit;
                }

                dataGridView2.Focus();
                dataGridView2.CurrentCell = dataGridView2.Rows[rowIndex].Cells["colUnitPrice"];
                this.DataChanged(sender, e);
            }
        }

        //--override
        protected override void InitLoad()
        {
            dtpBillDate.DataBindings.Add(new Binding("Text", bindingSource1, "BillDate", false));
            txtBillCode.DataBindings.Add(new Binding("Text", bindingSource1, "BillCode", false));
            txtSupplier.DataBindings.Add(new Binding("Text", bindingSource1, "SupplierName", false));
            txtDescription.DataBindings.Add(new Binding("Text", bindingSource1, "Description", false));

            dtpBillDate.TextChanged += this.DataChanged;
            txtBillCode.TextChanged += this.DataChanged;
            txtSupplier.TextChanged += this.DataChanged;
            txtDescription.TextChanged += this.DataChanged;

            dataGridView2.CellValueChanged += this.DataChanged;
            dataGridView2.RowsAdded += this.DataChanged;
            dataGridView2.RowsRemoved += this.DataChanged;
        }

        protected override bool GetByID(int id)
        {
            var bl = new PurchaseBillBL();
            this.Current = bl.GetByID(id);
            this.Original = CopyBill(this.Current);
            return this.Current != null;
        }

        protected override bool Create()
        {
            var bl = new PurchaseBillBL();
            this.Current = bl.Create();
            this.Original = CopyBill(this.Current);
            return this.Current != null;
        }

        protected override ResultMessage Delete()
        {
            var bl = new PurchaseBillBL();
            var rm = bl.Delete(this.Current);

            if (rm.Result)
            {
                //this.Original = CopyEntity(this.Current);
            }

            return rm;
        }

        protected override ResultMessage Save_Create()
        {
            before_Save();

            var bl = new PurchaseBillBL();
            int newID = 0;
            var rm = bl.Insert(this.Current, out newID);

            if (rm.Result)
            {
                this.Current.PurchaseID = newID;
                this.Original = CopyBill(this.Current);
            }

            return rm;
        }

        protected override ResultMessage Save_Update()
        {
            before_Save();

            var bl = new PurchaseBillBL();
            var rm = bl.Update(this.Original, this.Current);

            if (rm.Result)
            {
                this.Original = CopyBill(this.Current);
            }

            return rm;
        }

        protected override void Undo()
        {
            this.Current = CopyBill(this.Original);
        }

        #region CheckValid

        protected override ResultMessage CheckValid()
        {
            if (txtSupplier.Text == string.Empty)
            {
                var message = string.Format("'{0}'未填写，不能保存", txtSupplier.LabelText);
                txtSupplier.Focus();
                return new ResultMessage(false, message);
            }
            //else if (txtBillCode.Text == string.Empty)
            //{
            //    txtBillCode.Focus();
            //    Utility.ShowError(string.Format("'{0}'未填写，不能保存", txtBillCode.LabelText), this);
            //    return false;
            //}
            //else if (BillDate)
            //{
            //}
            else if (dataGridView2.RowCount == 1)
            {
                var message = "'单据明细'未填写，不能保存";
                if (dataGridView2.CanFocus) dataGridView2.Focus();
                return new ResultMessage(false, message);
            }
            else
            {
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    var row = dataGridView2.Rows[i];
                    if (Convert.ToString(row.Cells["colProductName"].Value) == string.Empty)
                    {
                        var message = string.Format("明细第{0}行 '商品名称'未填写，不能保存", i + 1);
                        dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells["colProductName"];
                        return new ResultMessage(false, message);
                    }
                    else if (Convert.ToDecimal(row.Cells["colUnitPrice"].Value) <= 0)
                    {
                        var message = string.Format("明细第{0}行 '单价'小于零或等于零，不能保存", i + 1);
                        dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells["colUnitPrice"];
                        return new ResultMessage(false, message);
                    }
                    else if (Convert.ToDecimal(row.Cells["colQuantity"].Value) <= 0)
                    {
                        var message = string.Format("明细第{0}行 '数量'小于零或等于零，不能保存", i + 1);
                        dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells["colQuantity"];
                        return new ResultMessage(false, message);
                    }
                }
            }

            var bl = new PurchaseBillBL();
            return bl.CheckValid(this.Current);
        }

        #endregion

        #region GetColumns

        protected override DataGridViewColumn[] GetColumns()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "colProductName",
                    DataPropertyName = "ProductName",
                    HeaderText = "商品名称",
                    ReadOnly = true,
                    Width = 200,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colUnit",
                    DataPropertyName = "Unit",
                    HeaderText = "单位",
                    ReadOnly = true,
                    DefaultCellStyle = CellStyle.ReadonlyCellStyle,
                    Width = 60,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colUnitPrice",
                    DataPropertyName = "UnitPrice",
                    HeaderText = "单价",
                    DefaultCellStyle = CellStyle.MoneyCellStyle,
                    Width = 100,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colQuantity",
                    DataPropertyName = "Quantity",
                    HeaderText = "数量",
                    DefaultCellStyle = CellStyle.DecimalCellStyle,
                    Width = 100,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colAmount",
                    DataPropertyName = "Amount",
                    HeaderText = "金额",
                    ReadOnly = true,
                    DefaultCellStyle = CellStyle.ReadonlyMoneyCellStyle,
                    Width = 100,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colDescription",
                    DataPropertyName = "Description",
                    HeaderText = "备注",
                    Width = 100,
                },
            };
        }

        #endregion

        private void txtSupplier_ButtonClick(object sender, EventArgs e)
        {
            var f = new SupplierSelectForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Current.SupplierID = f.SelectedItem.SupplierID;
                this.Current.SupplierName = f.SelectedItem.SupplierName;
                this.txtSupplier.Text = f.SelectedItem.SupplierName;
            }
        }

        private void before_Save()
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (dataGridView2.Rows[i].DataBoundItem is PurchaseItem)
                {
                    (dataGridView2.Rows[i].DataBoundItem as PurchaseItem).SortID = i + 1;
                }
            }
        }
    }
}
