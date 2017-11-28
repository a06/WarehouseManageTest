using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.BusinessLogic;
using WarehouseManage.Common.Entities;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class UserBrowseForm : BrowseForm
    {
        //--Constructor
        public UserBrowseForm()
        {
            InitializeComponent();
        }

        protected override void InitLoad()
        {
            this.Title = "用户";
            txtUserName.LabelText = "用户名称";
            cmbIsDisable.LabelText = "停用";
            cmbIsDisable.Items[0] = "全部";
            cmbIsDisable.Items[1] = "停用";
            cmbIsDisable.Items[2] = "已失效";

            this.BrowseState = BrowseState.CanAddItem & BrowseState.CanEditItem;
        }

        protected override void Reset()
        {
            txtUserName.Text = "";
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

            var s = txtUserName.Text.Trim();
            if (s != string.Empty)
            {
                if (filters != string.Empty) filters += "  AND ";

                filters += "UserName LIKE '%" + s + "%'";
            }

            var bl = new UserBL();
            var list = bl.GetList(filters);

            return list;
        }

        protected override ExportInfo GetExportInfo()
        {
            var filters = string.Empty;

            if (txtUserName.Text != string.Empty)
            {
                filters += txtUserName.LabelText + ":" + txtUserName.Text;
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
            var f = new UserEditForm();
            f.BeginCreate();
            return (f.ShowDialog() == DialogResult.OK);
        }

        private int _currentItemID
        {
            get
            {
                return (dataGridView1.CurrentRow == null)
                           ? 0
                           : (dataGridView1.CurrentRow.DataBoundItem as User).UserID;
            }
        }

        private User _currentItem
        {
            get
            {
                return (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem is User)
                           ? null
                           : (dataGridView1.CurrentRow.DataBoundItem as User);
            }
        }

        protected override bool EditRow()
        {
            var f = new UserEditForm();
            f.BeginEdit(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool DeleteRow()
        {
            var f = new UserEditForm();
            f.BeginDelete(this._currentItemID);
            return (f.ShowDialog() == DialogResult.OK);
        }

        protected override bool ViewRow()
        {
            var f = new UserEditForm();
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
                    Name = "colUserID",
                    DataPropertyName = "UserID",
                    HeaderText = "colUserID",
                    ReadOnly = true,
                    Visible = false,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colUserCode",
                    DataPropertyName = "UserCode",
                    HeaderText = "编号",
                    Width = 100,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "colUserName",
                    DataPropertyName = "UserName",
                    HeaderText = "名称",
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
