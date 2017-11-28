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
    public partial class ProductSelectForm : SelectForm
    {
        public Product SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                _selectedItem = value;
            }
        }
        private Product _selectedItem;

        //--Constructor
        public ProductSelectForm()
        {
            InitializeComponent();
        }

        //--override
        protected override void InitLoad()
        {
            this.Title = "商品";
            txtProductName.LabelText = "商品名称";
        }

        protected override void Reset()
        {
            txtProductName.Text = string.Empty;
        }

        protected override bool SelectItem()
        {
            var item = dataGridView1.CurrentRow.DataBoundItem;
            if (item is Product)
            {
                this.SelectedItem = (item as Product);
                return true;
            }
            return false;
        }

        protected override IEnumerable GetItems()
        {
            var filters = string.Empty;
            filters = "IsDisable = 0";

            var s = txtProductName.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters = "ProductName LIKE '%" + s + "%'";
            }

            var bl = new ProductBL();
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
                    Name = "colProductID",
                    DataPropertyName = "ProductID",
                    HeaderText = "colProductID",
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
             };
        }

        #endregion
    }
}
