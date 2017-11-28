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
    public partial class EmployeeBrowseForm : BrowseForm
    {
        //--Constructor
        public EmployeeBrowseForm()
        {
            InitializeComponent();
        }

        protected override void InitLoad()
        {
            this.Title = "员工";
            txtEmployeeName.LabelText = "员工名称";
            cmbIsDisable.LabelText = "停用";

            cmbIsDisable.Items[0] = "全部";
            cmbIsDisable.Items[1] = "使用中";
            cmbIsDisable.Items[2] = "停用";

            this.BrowseState = BrowseState.CanAddItem & BrowseState.CanEditItem;
        }

        protected override void Reset()
        {
            txtEmployeeName.Text = string.Empty;
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


            var s = txtEmployeeName.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters += "EmployeeName LIKE '%" + s + "%'";
            }

            var bl = new EmployeeBL();
            var list = bl.GetList(filters);

            return list;
        }

        protected override ExportInfo GetExportInfo()
        {
            var filters = string.Empty;

            if (txtEmployeeName.Text != string.Empty)
            {
                filters += txtEmployeeName.LabelText + ":" + txtEmployeeName.Text;
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
            var f = new EmployeeEditForm();
            f.BeginCreate();
            return (f.ShowDialog() == DialogResult.OK);
        }

        private int _currentItemID
        {
            get
            {
                return (dataGridView1.CurrentRow == null)
                           ? 0
                           : (dataGridView1.CurrentRow.DataBoundItem as Employee).EmployeeID;
            }
        }

        private Employee _currentItem
        {
            get
            {
                return (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem is Employee)
                           ? null
                           : (dataGridView1.CurrentRow.DataBoundItem as Employee);

            }
        }

        protected override bool EditRow()
        {
            var f = new EmployeeEditForm();
            f.BeginEdit(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool DeleteRow()
        {
            var f = new EmployeeEditForm();
            f.BeginDelete(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool ViewRow()
        {
            var f = new EmployeeEditForm();
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
                    Name = "colEmployeeID",
                    DataPropertyName = "EmployeeID",
                    HeaderText = "colEmployeeID",
                    ReadOnly = true,
                    Visible = false,
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
                    HeaderText = "员工名称",
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
