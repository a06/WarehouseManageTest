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
    public partial class ProductBrowseForm : BrowseForm
    {
        //--Constructor
        public ProductBrowseForm()
        {
            InitializeComponent();
        }

        protected override void InitLoad()
        {
            this.Title = "商品";
            txtProductName.LabelText = "商品名称";
            cmbIsDisable.LabelText = "停用";
            cmbIsDisable.Items[0] = "全部";
            cmbIsDisable.Items[1] = "使用中";
            cmbIsDisable.Items[2] = "停用";

            this.BrowseState = BrowseState.CanAddItem & BrowseState.CanEditItem;
        }

        protected override void Reset()
        {
            txtProductName.Text = string.Empty;
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

            var s = txtProductName.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters += "ProductName LIKE '%" + s + "%'";
            }

            var bl = new ProductBL();
            var list = bl.GetList(filters);

            return list;
        }

        protected override ExportInfo GetExportInfo()
        {
            var filters = string.Empty;

            if (txtProductName.Text != string.Empty)
            {
                filters += txtProductName.LabelText + ":" + txtProductName.Text;
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
            var f = new ProductEditForm();
            f.BeginCreate();
            return (f.ShowDialog() == DialogResult.OK);
        }

        private int _currentItemID
        {
            get
            {
                return (dataGridView1.CurrentRow == null)
                           ? 0
                           : (dataGridView1.CurrentRow.DataBoundItem as Product).ProductID;
            }
        }

        private Product _currentItem
        {
            get
            {
                return (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem is Product)
                           ? null
                           : (dataGridView1.CurrentRow.DataBoundItem as Product);

            }
        }

        protected override bool EditRow()
        {
            var f = new ProductEditForm();
            f.BeginEdit(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool DeleteRow()
        {
            var f = new ProductEditForm();
            f.BeginDelete(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool ViewRow()
        {
            var f = new ProductEditForm();
            f.BeginView(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        #region Helper

        protected override DataGridViewColumn[] GetColumns()
        {
            return new DataGridViewColumn[]
            {
               new DataGridViewTextBoxColumn()
               {
                   Name = "colProductID",
                   DataPropertyName = "ProductID",
                   ReadOnly = true,
                   Visible = false,
               },
               new DataGridViewTextBoxColumn()
               {
                   Name = "colProductCode",
                   DataPropertyName = "ProductCode",
                   HeaderText = "编号",
                   Width = 100,
               },
               new DataGridViewTextBoxColumn()
               {
                   Name = "colProductName",
                   DataPropertyName = "ProductName",
                   HeaderText = "商品名称",
                   Width = 200,
               },
               new DataGridViewTextBoxColumn()
               {
                   Name = "colUnit",
                   DataPropertyName = "Unit",
                   HeaderText = "单位",
                   Width = 100,
               },
               new DataGridViewTextBoxColumn()
               {
                   Name = "colDescription",
                   DataPropertyName = "Description",
                   HeaderText = "备注",
                   Width = 100,
               },
               new DataGridViewCheckBoxColumn()
               {
                   Name = "colIsDisable",
                   DataPropertyName = "IsDisable",
                   HeaderText = "停用",
                   Width = 40,
               },
            };
        }

        #endregion
    }
}
