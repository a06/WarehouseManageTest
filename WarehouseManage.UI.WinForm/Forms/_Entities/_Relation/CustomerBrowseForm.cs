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
    public partial class CustomerBrowseForm : BrowseForm
    {
        //--Constructor
        public CustomerBrowseForm()
        {
            InitializeComponent();
        }

        protected override void InitLoad()
        {
            this.Title = "客户";
            cmbAreaName.LabelText = "区域";
            _getAreaNameItems();
            txtCustomerName.LabelText = "客户名称";
            cmbIsDisable.LabelText = "停用";

            cmbIsDisable.Items[0] = "全部";
            cmbIsDisable.Items[1] = "使用中";
            cmbIsDisable.Items[2] = "停用";

            this.BrowseState = BrowseState.CanAddItem & BrowseState.CanEditItem;
        }

        private void _getAreaNameItems()
        {
            cmbAreaName.Items.Add("全部");
            cmbAreaName.SelectedIndex = 0;

            var bl = new CustomerBL();
            var list = bl.GetAreaNameList();
            foreach (var item in list)
            {
                cmbAreaName.Items.Add(item);
            }
        }

        protected override void Reset()
        {
            cmbAreaName.SelectedIndex = 0;
            txtCustomerName.Text = string.Empty;
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

            if (cmbAreaName.SelectedIndex != 0)
            {
                var a = cmbAreaName.Text;
                if (a != string.Empty)
                {
                    if (filters != string.Empty) filters += "  AND ";

                    filters += "AreaName = '" + a + "'";
                }
            }


            var s = txtCustomerName.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters += "CustomerName LIKE '%" + s + "%'";
            }

            var bl = new CustomerBL();
            var list = bl.GetList(filters);

            return list;
        }

        protected override ExportInfo GetExportInfo()
        {
            var filters = string.Empty;

            filters += cmbAreaName.LabelText + ":" + cmbAreaName.Text;

            if (txtCustomerName.Text != string.Empty)
            {
                if (filters != string.Empty) filters += "      ";
                filters += txtCustomerName.LabelText + ":" + txtCustomerName.Text;
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
            var f = new CustomerEditForm();
            f.BeginCreate();
            return (f.ShowDialog() == DialogResult.OK);
        }

        private int _currentItemID
        {
            get
            {
                return (dataGridView1.CurrentRow == null)
                           ? 0
                           : (dataGridView1.CurrentRow.DataBoundItem as Customer).CustomerID;
            }
        }

        private Customer _currentItem
        {
            get
            {
                return (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem is Customer)
                           ? null
                           : (dataGridView1.CurrentRow.DataBoundItem as Customer);

            }
        }

        protected override bool EditRow()
        {
            var f = new CustomerEditForm();
            f.BeginEdit(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool DeleteRow()
        {
            var f = new CustomerEditForm();
            f.BeginDelete(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool ViewRow()
        {
            var f = new CustomerEditForm();
            f.BeginView(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        #region GetColumns

        protected override DataGridViewColumn[] GetColumns()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "colCustomerID",
                    DataPropertyName = "CustomerID",
                    Visible = false,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colAreaName",
                    DataPropertyName = "AreaName",
                    HeaderText = "区域",
                    Width = 100,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colCustomerCode",
                    DataPropertyName = "CustomerCode",
                    HeaderText = "编号",
                    Width = 100,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colCustomerName",
                    DataPropertyName = "CustomerName",
                    HeaderText = "客户名称",
                    Width = 200,
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
