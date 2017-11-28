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
    public partial class PurchaseBrowseForm : BrowseForm
    {
        //--Constructor
        public PurchaseBrowseForm()
        {
            InitializeComponent();
        }

        protected override void InitLoad()
        {
            this.Title = "进货单";

            this.BrowseState = BrowseState.CanAddItem & BrowseState.CanEditItem;
        }

        protected override void Reset()
        {
            dtpBillDate2.Value = DateTime.Today;
            dtpBillDate1.Value = dtpBillDate2.Value.AddMonths(-1);
            txtSupplierName.Text = string.Empty;
        }

        protected override IEnumerable GetRows()
        {
            var where = "BillDate BETWEEN '" + dtpBillDate1.Value.Date.ToString() + "' AND dateadd(day, 1, '" + dtpBillDate2.Value.Date.ToString() + "')";
            var s = txtSupplierName.Text.Trim();
            if (s != "")
                where += " AND SupplierName LIKE '%" + s + "%'";

            var orderby = "BillDate ASC";

            var bl = new PurchaseBillBL();
            var list = bl.GetList(where, orderby);

            return list;
        }

        protected override ExportInfo GetExportInfo()
        {
            var filters = dtpBillDate1.LabelText + ":" + dtpBillDate1.Value.ToShortDateString()
                  + " " + dtpBillDate2.LabelText + ":" + dtpBillDate2.Value.ToShortDateString();

            if (txtSupplierName.Text != string.Empty)
            {
                if (filters != string.Empty) filters += "      ";
                filters += txtSupplierName.LabelText + ":" + txtSupplierName.Text;
            }

            return new ExportInfo()
            {
                Title = this.Text,
                Filter = filters,
                Counter = groupBoxResult.Text,
            };
        }

        protected override bool CreateRow()
        {
            var f = new PurchaseBillForm();
            f.BeginCreate();
            return (f.ShowDialog() == DialogResult.OK);
        }

        private int _currentID
        {
            get
            {
                return (dataGridView1.CurrentRow == null || !(dataGridView1.CurrentRow.DataBoundItem is PurchaseBill))
                           ? 0
                           : (dataGridView1.CurrentRow.DataBoundItem as PurchaseBill).PurchaseID;
            }
        }

        private PurchaseBill _currentRow
        {
            get
            {
                return (dataGridView1.CurrentRow == null || !(dataGridView1.CurrentRow.DataBoundItem is PurchaseBill))
                           ? null
                           : (dataGridView1.CurrentRow.DataBoundItem as PurchaseBill);
            }
        }

        protected override bool EditRow()
        {
            var f = new PurchaseBillForm();
            f.BeginEdit(this._currentID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool DeleteRow()
        {
            var f = new PurchaseBillForm();
            f.BeginDelete(this._currentID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool ViewRow()
        {
            var f = new PurchaseBillForm();
            f.BeginView(this._currentID);
            return (f.ShowDialog() == DialogResult.OK);
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
                    Width = 300,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colDescription",
                    DataPropertyName = "Description",
                    HeaderText = "备注",
                    Width = 200,
                },
            };
        }

        #endregion
    }
}
