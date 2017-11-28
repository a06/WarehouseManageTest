using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.BusinessLogic;
using WarehouseManage.Common.Bills;
using WarehouseManage.Common.Entities;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class PurchaseBillSeleForm : BillSeleForm
    {
        public PurchaseBill Selected
        {
            get { return _selected; }
            private set
            {
                _selected = value;
            }
        }
        private PurchaseBill _selected;

        //--Constructor
        public PurchaseBillSeleForm()
        {
            InitializeComponent();
        }

        //--override
        protected override void InitLoad()
        {
            this.Title = "进货单";
            txtSupplierName.LabelText = "供应商名称";
        }

        protected override void Reset()
        {
            dtpBillDate2.Value = DateTime.Today;
            dtpBillDate1.Value = dtpBillDate2.Value.AddMonths(-1);
            txtSupplierName.Text = string.Empty;
        }

        protected override bool SelectItem()
        {
            var item = dataGridView1.CurrentRow.DataBoundItem;
            if (item is PurchaseBill)
            {
                this.Selected = (item as PurchaseBill);
                return true;
            }
            return false;
        }

        protected override IEnumerable GetList()
        {
            var filters = "BillDate >= '" + dtpBillDate1.Value.Date.ToString() + "' AND BillDate < dateadd(day, 1, '" + dtpBillDate2.Value.Date.ToString() + "')";

            var s = txtSupplierName.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters += "SupplierName LIKE '%" + s + "%'";
            }

            var sorts = "BillDate DESC, BillCode, SupplierName";

            var bl = new PurchaseBillBL();
            var list = bl.GetList(filters, sorts);

            return list;
        }

        protected override IEnumerable GetItemList(int rowIndex)
        {
            int id = 0;
            if ((dataGridView1.RowCount > 0) && (rowIndex < dataGridView1.RowCount) && (dataGridView1.Rows[rowIndex].DataBoundItem is PurchaseBill))
            {
                id = (dataGridView1.Rows[rowIndex].DataBoundItem as PurchaseBill).PurchaseID;
            }

            var bl = new PurchaseBillBL();
            var list = bl.GetItemList(id);

            return list;
        }

        #region GetColumns

        protected override DataGridViewColumn[] GetColumns()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "colBillDate",
                    DataPropertyName = "BillDate",
                    HeaderText = "日期",
                    Width = 120,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colBillCode",
                    DataPropertyName = "BillCode",
                    HeaderText = "单号",
                    Width = 80,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colSupplierName",
                    DataPropertyName = "SupplierName",
                    HeaderText = "供应商名称",
                    Width = 200,
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

        #region GetItemColumns

        protected override DataGridViewColumn[] GetItemColumns()
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

    }
}
