using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WarehouseManage.UI.WinForm.Controls
{
    public partial class PanelOkCancel : UserControl
    {
        public event System.EventHandler btnOkClick = null;
        public event System.EventHandler btnCancelClick = null;

        //--Property
        protected bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy) this.Cursor = Cursors.WaitCursor;
                this.Enabled = !_isBusy;
                btnOk.Enabled = !_isBusy;
                btnCancel.Enabled = !_isBusy;
                if (!_isBusy) this.Cursor = Cursors.Default;
            }
        }
        private bool _isBusy;

        //--Contructor
        public PanelOkCancel()
        {
            InitializeComponent();
            this.btnOk.Text = "确定(&O)";
            this.btnCancel.Text = "取消(&C)";
        }

        //--Event
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                if (btnOkClick != null) btnOkClick(btnOk, e);
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            try
            {
                if (btnCancelClick != null) btnCancelClick(btnCancel, e);
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
