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
    public partial class SupplierSelectForm : SelectForm
    {
        public Supplier SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                _selectedItem = value;
            }
        }
        private Supplier _selectedItem;

        //--Constructor
        public SupplierSelectForm()
        {
            InitializeComponent();
        }

        //--override
        protected override void InitLoad()
        {
            this.Title = "供应商";
            txtSupplierName.LabelText = "供应商名称";
        }

        protected override void Reset()
        {
            txtSupplierName.Text = string.Empty;
        }

        protected override bool SelectItem()
        {
            var item = dataGridView1.CurrentRow.DataBoundItem;
            if (item is Supplier)
            {
                this.SelectedItem = (item as Supplier);
                return true;
            }
            return false;
        }

        protected override IEnumerable GetItems()
        {
            var filters = string.Empty;
            filters = "IsDisable = 0";

            var s = txtSupplierName.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters += "SupplierName LIKE '%" + s + "%'";
            }

            var bl = new SupplierBL();
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
                    Name = "colSupplierCode",
                    DataPropertyName = "SupplierCode",
                    HeaderText = "编号",
                    Width = 100,
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

    }
}
