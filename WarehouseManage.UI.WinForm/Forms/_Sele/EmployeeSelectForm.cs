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
    public partial class EmployeeSelectForm : SelectForm
    {
        public Employee SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                _selectedItem = value;
            }
        }
        private Employee _selectedItem;

        //--Constructor
        public EmployeeSelectForm()
        {
            InitializeComponent();

            this.Title = "员工";
            txtEmployeeName.LabelText = "员工名称";

            dataGridView1.ReadOnly = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name != "colSelect") column.ReadOnly = true;
            }
        }

        //--override
        protected override void InitLoad()
        {
        }

        protected override void Reset()
        {
            txtEmployeeName.Text = string.Empty;
        }

        protected override bool SelectItem()
        {
            var item = dataGridView1.CurrentRow.DataBoundItem;
            if (item is Employee)
            {
                this.SelectedItem = (item as Employee);
                return true;
            }
            return false;
        }

        protected override IEnumerable GetItems()
        {
            var filters = string.Empty;
            filters = "IsDisable = 0";

            var s = txtEmployeeName.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters = "EmployeeName LIKE '%" + s + "%'";
            }

            var bl = new EmployeeBL();
            var list = bl.GetList(filters);

            return list;
        }

        #region GetColumns

        protected override DataGridViewColumn[] GetColumns()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewCheckBoxColumn()
                {
                    Name = "colSelect",
                    DataPropertyName = "0",
                    HeaderText = "Select",
                    Width = 60,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colEmployeeCode",
                    DataPropertyName = "EmployeeCode",
                    HeaderText = "编号",
                    Width = 100,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colEmployeeName",
                    DataPropertyName = "EmployeeName",
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
