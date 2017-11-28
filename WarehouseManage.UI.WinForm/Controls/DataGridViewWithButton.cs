using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WarehouseManage.UI.WinForm.Controls
{
    public class DataGridViewWithButton : DataGridView
    {
        public event System.EventHandler ButtonClickHandler = null;

        private Button button = null;

        //--Property
        private bool IsBusy
        {
            set
            {
                if (value == true)
                    this.Cursor = Cursors.WaitCursor;
                button.Enabled = (value == false);
                if (value == false)
                    this.Cursor = Cursors.Default;
            }
        }

        //有按钮的列名称
        public IList<string> ShowButtonColumns
        {
            get { return _showButtonColumns; }
            set
            {
                _showButtonColumns = value;
            }
        }
        private IList<string> _showButtonColumns = null;

        //--Contructor
        public DataGridViewWithButton()
        {
            button = new Button()
            {
                Visible = false,
                Parent = this,
                Width = 21,
                Height = 20,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
                Text = "…",
            };
            button.Click += new EventHandler(button_Click);
        }

        //--Override
        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            if (ShowButtonColumns == null)
                return;

            var columnName = this.Columns[e.ColumnIndex].Name;

            if (this.ShowButtonColumns.Contains(columnName))
            {
                var height = this.Rows[e.RowIndex].Height;
                if (button.Height != this.Rows[e.RowIndex].Height)
                {
                    button.Size = new System.Drawing.Size(height, height - 3);
                }


                button.Location = _getButtonLocation();
                button.Visible = true;
            }
            else
            {
                button.Visible = false;
            }

            base.OnCellEnter(e);
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            button.Visible = false;
            base.OnScroll(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                ////if (this.ShowButtonColumns.Contains(this.Columns[this.CurrentCell.ColumnIndex].Name))
                ////{
                ////    button.PerformClick();
                ////}
                SendKeys.Send("{Tab}");
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ////if (this.ShowButtonColumns.Contains(this.Columns[this.CurrentCell.ColumnIndex].Name))
                ////{
                ////    button.PerformClick();
                ////}
                e.Handled = true;
                SendKeys.Send("{Tab}");
            }
            else if (e.KeyData == Keys.Space)
            {
                button.PerformClick();
            }

            base.OnKeyDown(e);
        }

        protected override void Dispose(bool disposing)
        {
            button.Dispose();
            base.Dispose(disposing);
        }

        //--Event
        private void button_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                if (ButtonClickHandler != null) ButtonClickHandler(button, e);
            }
            finally
            {
                this.IsBusy = false;
            }
        }
        
        
        #region Helper

        private Point _getButtonLocation()
        {
            var p = new Point();

            //-- 获取X轴的位置
            if (this.RowHeadersVisible)
            {
                //判断该类是否包含行标题,如果该列包含行标题，按钮的横坐标位置等于当前位置加上行标题
                p.X += this.RowHeadersWidth;
            }
            //FirstDisplayedCell表示左上角第一个单元格
            for (int i = this.FirstDisplayedCell.ColumnIndex; i <= this.CurrentCell.ColumnIndex; i++)
            {
                if (this.Columns[i].Visible)
                {
                    //当前位置=单元格的宽度加上分隔符发宽度
                    p.X += this.Columns[i].Width + this.Columns[i].DividerWidth;
                }
            }

            p.X -= this.FirstDisplayedScrollingColumnHiddenWidth;
            p.X -= button.Width;
            //--

            //-- 获取Y轴位置
            if (this.ColumnHeadersVisible)
            {
                //如果列表题可见，按钮的初始纵坐标位置等于当前位置加上列标题
                p.Y += this.ColumnHeadersHeight;
            }

            //获取或设置某一列的索引，该列是显示在 DataGridView 上的第一列
            for (int i = this.FirstDisplayedScrollingRowIndex; i < this.CurrentCell.RowIndex; i++)
            {
                if (this.Rows[i].Visible)
                {
                    p.Y += this.Rows[i].Height + this.Rows[i].DividerHeight;
                }
            }
            //--

            return new Point(p.X - 0, p.Y + 2);
        }

        #endregion
    }
}
