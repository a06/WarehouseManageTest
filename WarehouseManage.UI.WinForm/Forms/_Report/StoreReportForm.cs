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
    public partial class StoreReportForm : ReportForm
    {
        //--Constructor
        public StoreReportForm()
        {
            InitializeComponent();
        }

        protected override void InitLoad()
        {
            this.Title = "现有库存";

            this.ReportState = ReportState.CanExport; //BrowseState.CanAddItem & BrowseState.CanEditItem;
        }

        protected override void Reset()
        {
            //dtpBillDate2.Value = DateTime.Today;
            //dtpBillDate1.Value = dtpBillDate2.Value.AddMonths(-1);
            //txtSupplierName.Text = string.Empty;
        }

        protected override IEnumerable GetItems()
        {
            var filter = string.Empty;
            //var filter = "BillDate BETWEEN '" + dtpBillDate1.Value.Date.ToString() + "' AND dateadd(day, 1, '" + dtpBillDate2.Value.Date.ToString() + "')";
            //var s = txtSupplierName.Text.Trim();
            //if (s != "")
            //    filter += " AND SupplierName LIKE '%" + s + "%'";

            var bl = new StoreReportBL();
            var list = bl.GetViews(filter);

            return list;
        }

        //protected override bool CreateItem()
        //{
        //    //var f = new StoreBillForm();
        //    //f.BeginCreate();
        //    //return (f.ShowDialog() == DialogResult.OK);
        //    return false;
        //}

        private int _currentItemID
        {
            get
            {
                //return (dataGridView1.CurrentRow == null || !(dataGridView1.CurrentRow.DataBoundItem is StoreHeadView))
                //           ? 0
                //           : (dataGridView1.CurrentRow.DataBoundItem as StoreHeadView).StoreID;
                return 0;
            }
        }

        //protected override bool EditItem()
        //{
        //    //var f = new StoreBillForm();
        //    //f.BeginEdit(this._currentItemID);
        //    //return (f.ShowDialog() == DialogResult.OK);
        //    return false;
        //}

        //protected override bool DeleteItem()
        //{
        //    //var f = new StoreBillForm();
        //    //f.BeginDelete(this._currentItemID);
        //    //return (f.ShowDialog() == DialogResult.OK);
        //    return false;
        //}

        protected override bool ViewItem()
        {
            //var f = new StoreBillForm();
            //f.BeginView(this._currentItemID);
            //return (f.ShowDialog() == DialogResult.OK);
            return false;
        }

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
                    DefaultCellStyle = CellStyle.ReadonlyCellStyle,
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
                    Name = "colBeginSum",
                    DataPropertyName = "BeginSum",
                    HeaderText = "期初",
                    ReadOnly = true,
                    DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                    Width = 60,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colPurchaseSum",
                    DataPropertyName = "PurchaseSum",
                    HeaderText = "进货",
                    ReadOnly = true,
                    DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                    Width = 60,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colPurchaseReturnSum",
                    DataPropertyName = "PurchaseReturnSum",
                    HeaderText = "退货",
                    ReadOnly = true,
                    DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                    Width = 60,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colSaleSum",
                    DataPropertyName = "SaleSum",
                    HeaderText = "销售",
                    ReadOnly = true,
                    DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                    Width = 60,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colSaleReturnSum",
                    DataPropertyName = "SaleReturnSum",
                    HeaderText = "返还",
                    ReadOnly = true,
                    DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                    Width = 60,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colEndSum",
                    DataPropertyName = "EndSum",
                    HeaderText = "期末",
                    ReadOnly = true,
                    DefaultCellStyle = CellStyle.ReadonlyDecimalCellStyle,
                    Width = 60,
                },
            };
        }

        #endregion
    }
}
