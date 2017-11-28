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
    public partial class CustomerSelectForm : SelectForm
    {
        public Customer SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                _selectedItem = value;
            }
        }
        private Customer _selectedItem;

        //--Constructor
        public CustomerSelectForm()
        {
            InitializeComponent();

            this.Title = "客户";
            cmbAreaName.LabelText = "区域";
            _getAreaNameItems();
            txtCustomerName.LabelText = "客户名称";
        }

        //--override
        protected override void InitLoad()
        {
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
        }

        protected override bool SelectItem()
        {
            var item = dataGridView1.CurrentRow.DataBoundItem;
            if (item is Customer)
            {
                this.SelectedItem = (item as Customer);
                return true;
            }
            return false;
        }

        protected override IEnumerable GetItems()
        {
            var filters = string.Empty;
            filters = "IsDisable = 0";

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

                filters = "CustomerName LIKE '%" + s + "%'";
            }

            var bl = new CustomerBL();
            var list = bl.GetList(filters);

            return list;
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
             };
        }

        #endregion
    }
}
