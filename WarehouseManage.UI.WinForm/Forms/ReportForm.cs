using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WarehouseManage.UI.WinForm.Controls;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class ReportForm : MdiChildForm
    {
        protected BindingSource bindingSource1;

        //--Property
        public override string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                this.Text = value + "列表";
            }
        }
        private string _title;

        public ReportState ReportState
        {
            get { return _ReportState; }
            set
            {
                _ReportState = value;
            }
        }
        private ReportState _ReportState;

        protected DataGridViewColumn[] DataGridViewColumns
        {
            get { return _dataGridViewColumns; }
            set
            {
                _dataGridViewColumns = value;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.AddRange(value);
            }
        }
        private DataGridViewColumn[] _dataGridViewColumns;

        //--Method(Not Implemented)
        protected virtual void InitLoad() { }
        protected virtual void InitShown() { }

        protected virtual void Reset() { }

        //protected virtual bool CreateItem() { throw new NotImplementedException(""); }
        //protected virtual bool EditItem() { throw new NotImplementedException(""); }
        //protected virtual bool DeleteItem() { throw new NotImplementedException(""); }
        protected virtual bool ViewItem() { throw new NotImplementedException(""); }

        protected virtual IEnumerable GetItems() { return null; }

        protected virtual DataGridViewColumn[] GetColumns() { return new DataGridViewColumn[] { }; }

        protected virtual ExportInfo GetExportInfo() { return new ExportInfo(); }

        //--Method(Implemented)
        public virtual void OnFilterChanged(object sender, EventArgs e)
        {
            //
        }

        protected virtual void Search()
        {
            this.SuspendLayout();
            var i = dataGridView1.CurrentRow == null ? 0 : dataGridView1.CurrentRow.Index;

            this.bindingSource1.DataSource = GetItems();
            dataGridView1.DataSource = this.bindingSource1.DataSource;
            groupBoxResult.Text = string.Format("查询结果: {0} 个记录", dataGridView1.RowCount);

            if (i < dataGridView1.RowCount)
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index];
            this.ResumeLayout();
        }

        protected virtual bool Export()
        {
            var exportInfo = GetExportInfo();
            return ExportToExcel.DataGridViewToExcel(exportInfo, dataGridView1);
        }

        protected virtual bool Setting()
        {
            return true;
        }

        //--Constructor
        public ReportForm()
        {
            InitializeComponent();

            this.DataGridViewColumns = GetColumns();
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle = CellStyle.ReadonlyCellStyle;


            this.bindingSource1 = new BindingSource();

            lblTitleMessage.Text = "";
            groupBoxFilter.Text = "查询条件";
            groupBoxResult.Text = "查询结果";
            btnSearch.Text = "查询(&F)";
            btnReset.Text = "重置(&R)";
            btnExport.Text = "导出(&X)";
            btnSetting.Text = "设定(&S)";
            btnClose.Text = "关闭(&C)";

            btnViewItem.Visible = false;
            btnSetting.Visible = false;
            toolStrip1.Visible = false;
        }

        //--Event
        private void ReportForm_Load(object sender, EventArgs e)
        {
            InitLoad();
        }

        private void ReportForm_Shown(object sender, EventArgs e)
        {
            InitShown();
            Reset();
            Search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                Search();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                Reset();
                Search();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                Export();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                Setting();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                this.Close();
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        //private void btnCreateItem_Click(object sender, EventArgs e)
        //{
        //    this.IsBusy = true;
        //    try
        //    {
        //        if (CreateItem())
        //        {
        //            Search();
        //        }
        //    }
        //    finally
        //    {
        //        this.IsBusy = false;
        //    }
        //}

        //private void btnEditItem_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.RowCount == 0)
        //        return;
        //    this.IsBusy = true;
        //    var sm = dataGridView1.SelectionMode;
        //    var ci = dataGridView1.CurrentCell.ColumnIndex;
        //    try
        //    {
        //        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //        dataGridView1.CurrentRow.Selected = true;
        //        if (EditItem())
        //        {
        //            Search();
        //        }
        //    }
        //    finally
        //    {
        //        dataGridView1.SelectionMode = sm;
        //        if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[ci].Selected = true;
        //        this.IsBusy = false;
        //    }
        //}

        //private void btnDeleteItem_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.RowCount == 0)
        //        return;
        //    this.IsBusy = true;
        //    var sm = dataGridView1.SelectionMode;
        //    var ci = dataGridView1.CurrentCell.ColumnIndex;
        //    try
        //    {
        //        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //        dataGridView1.CurrentRow.Selected = true;
        //        if (DeleteItem())
        //        {
        //            Search();
        //        }
        //    }
        //    finally
        //    {
        //        dataGridView1.SelectionMode = sm;
        //        if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[ci].Selected = true;
        //        this.IsBusy = false;
        //    }
        //}

        private void btnViewItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;
            this.IsBusy = true;
            var sm = dataGridView1.SelectionMode;
            var ci = dataGridView1.CurrentCell.ColumnIndex;
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.CurrentRow.Selected = true;
                if (ViewItem())
                {
                    //Search();
                }
            }
            finally
            {
                dataGridView1.SelectionMode = sm;
                if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[ci].Selected = true;
                this.IsBusy = false;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (btnViewItem.Visible && btnViewItem.Enabled)
            {
                btnViewItem.PerformClick();
            }
        }

    }
}
