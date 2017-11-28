using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarehouseManage.UI.WinForm.Forms
{
    public partial class BillSeleForm : DialogForm
    {
        //--Property
        protected BindingSource bindingSource1;
        protected BindingSource bindingSource2;

        public virtual string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                this.Text = "选择" + value;
            }
        }
        private string _title;

        public BrowseState BrowseState
        {
            get { return _browseState; }
            set
            {
                _browseState = value;
            }
        }
        private BrowseState _browseState;

        protected DataGridViewColumn[] DataGridView1Columns
        {
            get { return _dataGridView1Columns; }
            set
            {
                _dataGridView1Columns = value;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.AddRange(value);
            }
        }
        private DataGridViewColumn[] _dataGridView1Columns;

        protected DataGridViewColumn[] DataGridView2Columns
        {
            get { return _dataGridView2Columns; }
            set
            {
                _dataGridView2Columns = value;
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.Columns.Clear();
                dataGridView2.Columns.AddRange(value);
            }
        }
        private DataGridViewColumn[] _dataGridView2Columns;


        //--Method(Not Implemented)
        protected virtual void InitLoad() { }
        protected virtual void InitShown() { }

        protected virtual void Reset() { }
        protected virtual bool SelectItem() { return false; }

        protected virtual IEnumerable GetList() { return null; }
        protected virtual IEnumerable GetItemList(int rowIndex) { return null; }
        protected virtual DataGridViewColumn[] GetColumns() { return new DataGridViewColumn[] { }; }
        protected virtual DataGridViewColumn[] GetItemColumns() { return new DataGridViewColumn[] { }; }

        //--Method(Implemented)
        protected virtual void Search()
        {
            this.SuspendLayout();
            var i = dataGridView1.CurrentRow == null ? 0 : dataGridView1.CurrentRow.Index;

            this.bindingSource1.DataSource = GetList();
            dataGridView1.DataSource = this.bindingSource1.DataSource;

            if (i < dataGridView1.RowCount)
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index];

            //todo
            var j = dataGridView2.CurrentRow == null ? 0 : dataGridView2.CurrentRow.Index;

            this.bindingSource2.DataSource = GetItemList(i);
            dataGridView2.DataSource = this.bindingSource2.DataSource;

            if (j < dataGridView2.RowCount)
                dataGridView2.CurrentCell = dataGridView2.Rows[j].Cells[dataGridView2.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index];

            this.ResumeLayout();
        }

        //--Constructor
        public BillSeleForm()
        {
            InitializeComponent();

            this.DataGridView1Columns = GetColumns();
            this.DataGridView2Columns = GetItemColumns();
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle = CellStyle.ReadonlyCellStyle;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.bindingSource1 = new BindingSource();
            this.bindingSource2 = new BindingSource();
            //this.timer1 = new Timer();

            groupBoxFilter.Text = "查询条件";
            groupBoxResult.Text = "查询结果";
            btnSearch.Text = "查找(&F)";
            btnReset.Text = "重置(&R)";
            btnSelect.Text = "选择(&S)";
            btnClose.Text = "关闭(&C)";
        }

        //--Event
        private void SeleBillForm_Load(object sender, EventArgs e)
        {
            InitLoad();
        }

        private void SeleBillForm_Shown(object sender, EventArgs e)
        {
            InitShown();
            btnReset.PerformClick();
            //Reset();
            //Search();
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    if (SelectItem())
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
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

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void SeleBillForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    if (dataGridView1.Focused)
                    {
                        e.Handled = true;
                        btnSelect.PerformClick();
                    }
                    else
                    {
                        e.Handled = true;
                        SendKeys.Send("{TAB}");
                    }
                    break;
                case Keys.Up:
                    if (dataGridView1.CurrentRow != null)
                    {
                        var i = dataGridView1.CurrentRow.Index;
                        if (i > 0)
                        {
                            e.Handled = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i - 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
                        }
                    }
                    break;
                case Keys.Down:
                    if (dataGridView1.CurrentRow != null)
                    {
                        var i = dataGridView1.CurrentRow.Index;
                        if (i < dataGridView1.RowCount - 1)
                        {
                            e.Handled = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i + 1].Cells[dataGridView1.CurrentCell.ColumnIndex];
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.bindingSource1.IsBindingSuspended && dataGridView1.CurrentRow != null)
            {
                //this.SuspendLayout();
                var i = dataGridView2.CurrentRow == null ? 0 : dataGridView2.CurrentRow.Index;

                this.bindingSource2.DataSource = GetItemList(e.RowIndex);
                dataGridView2.DataSource = this.bindingSource2.DataSource;

                if (i < dataGridView2.RowCount)
                    dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[dataGridView2.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index];
                //this.ResumeLayout();
            }
        }

    }
}
