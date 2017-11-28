using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.BusinessLogic;
using WarehouseManage.Common.Entities;
using WarehouseManage.UI.WinForm.Controls;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class SupplierBrowseForm : BrowseForm
    {
        //--Constructor
        public SupplierBrowseForm()
        {
            InitializeComponent();
        }

        protected override void InitLoad()
        {
            this.Title = "供应商";
            txtSupplier.LabelText = "供应商名称";
            cmbIsDisable.LabelText = "停用";
            cmbIsDisable.Items[0] = "全部";
            cmbIsDisable.Items[1] = "使用中";
            cmbIsDisable.Items[2] = "停用";

            this.BrowseState = BrowseState.CanAddItem & BrowseState.CanEditItem;
        }

        protected override void Reset()
        {
            txtSupplier.Text = string.Empty;
            cmbIsDisable.SelectedIndex = 0;
        }

        protected override IEnumerable GetRows()
        {
            var filters = string.Empty;
            switch (cmbIsDisable.SelectedIndex)
            {
                case 1:
                    filters = "IsDisable = 0";
                    break;
                case 2:
                    filters = "IsDisable = 1";
                    break;
                default:
                    break;
            };

            var s = txtSupplier.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters += "SupplierName LIKE '%" + s + "%'";
            }

            var bl = new SupplierBL();
            var list = bl.GetList(filters);

            return list;
        }

        protected override ExportInfo GetExportInfo()
        {
            var filters = string.Empty;

            if (txtSupplier.Text != string.Empty)
            {
                filters += txtSupplier.LabelText + ":" + txtSupplier.Text;
            }

            if (filters != string.Empty) filters += "      ";
            filters += cmbIsDisable.LabelText + ":" + cmbIsDisable.Text;

            return new ExportInfo()
            {
                Title = this.Text,
                Filter = filters,
                Counter = groupBoxResult.Text,
            };
        }

        protected override bool CreateRow()
        {
            var f = new SupplierEditForm();
            f.BeginCreate();
            return (f.ShowDialog() == DialogResult.OK);
        }

        private int _currentItemID
        {
            get
            {
                return (dataGridView1.CurrentRow == null)
                           ? 0
                           : (dataGridView1.CurrentRow.DataBoundItem as Supplier).SupplierID;
            }
        }

        private Supplier _currentItem
        {
            get
            {
                return (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem is Supplier)
                           ? null
                           : (dataGridView1.CurrentRow.DataBoundItem as Supplier);

            }
        }

        protected override bool EditRow()
        {
            var f = new SupplierEditForm();
            f.BeginEdit(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool DeleteRow()
        {
            var f = new SupplierEditForm();
            f.BeginDelete(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool ViewRow()
        {
            var f = new SupplierEditForm();
            f.BeginView(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        #region Helper

        protected override DataGridViewColumn[] GetColumns()
        {
            var colSupplierID = new DataGridViewTextBoxColumn()
            {
                Name = "colSupplierID",
                DataPropertyName = "SupplierID",
                HeaderText = "colSupplierID",
                ReadOnly = true,
                Visible = false,
            };
            var colSupplierCode = new DataGridViewTextBoxColumn()
            {
                Name = "colSupplierCode",
                DataPropertyName = "SupplierCode",
                HeaderText = "编号",
                Width = 100,
            };
            var colSupplierName = new DataGridViewTextBoxColumn()
            {
                Name = "colSupplierName",
                DataPropertyName = "SupplierName",
                HeaderText = "供应商名称",
                Width = 200,
            };
            var colDescription = new DataGridViewTextBoxColumn()
            {
                Name = "colDescription",
                DataPropertyName = "Description",
                HeaderText = "备注",
                Width = 100,
            };
            var colIsDisable = new DataGridViewCheckBoxColumn()
            {
                Name = "colIsDisable",
                DataPropertyName = "IsDisable",
                HeaderText = "停用",
                Width = 40,
            };

            return new DataGridViewColumn[]
            {
               colSupplierID,
               colSupplierCode,
               colSupplierName,
               colDescription,
               colIsDisable,
            };
        }

        #endregion
    }
}
